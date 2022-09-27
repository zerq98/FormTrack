using Android.Service.Autofill;
using FormTrackClient.Models.Dtos;
using FormTrackClient.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FormTrackClient.Api
{
    public class ApiClient
    {
        private readonly HttpClient webClient;
        private readonly JsonSerializer serializer;
        private string BASE_ADDRESS = DeviceInfo.Platform == DevicePlatform.Android? "https://10.0.2.2:7057/api/": "https://localhost:7057/api/";

        public ApiClient()
        {
            var clientHandlerService = new HttpsClientHandlerService();
            webClient = new HttpClient(clientHandlerService.GetPlatformMessageHandler());
            webClient.BaseAddress = new Uri(BASE_ADDRESS);
            webClient.DefaultRequestHeaders.Add("accept", "*/*");
            serializer = new JsonSerializer();
        }

        public ApiClient(string token)
        {
            webClient = new HttpClient();
            webClient.BaseAddress = new Uri(BASE_ADDRESS);
            webClient.DefaultRequestHeaders.Add("accept", "*/*");
            webClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            serializer = new JsonSerializer();
        }

        public async Task<ResponseModel<LoginResponse>> LoginAsync(LoginDto dto)
        {
            try
            {
                HttpResponseMessage response = await webClient.PostAsync($"account/login", new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json")).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                var contentStream = await response.Content.ReadAsStreamAsync();

                var streamReader = new StreamReader(contentStream);
                var jsonReader = new JsonTextReader(streamReader);

                return serializer.Deserialize<ResponseModel<LoginResponse>>(jsonReader);
            }
            catch (WebException ex)
            {
                return null;
            }
        }
    }

    public class HttpsClientHandlerService
    {
        public HttpMessageHandler GetPlatformMessageHandler()
        {
#if ANDROID
            var handler = new CustomAndroidMessageHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert != null && cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
#elif IOS
            var handler = new NSUrlSessionHandler
            {
                TrustOverrideForUrl = IsHttpsLocalhost
            };
            return handler;
#elif WINDOWS || MACCATALYST
            return null;
#else
         throw new PlatformNotSupportedException("Only Android, iOS, MacCatalyst, and Windows supported.");
#endif
        }

#if ANDROID
        internal sealed class CustomAndroidMessageHandler : Xamarin.Android.Net.AndroidMessageHandler
        {
            protected override Javax.Net.Ssl.IHostnameVerifier GetSSLHostnameVerifier(Javax.Net.Ssl.HttpsURLConnection connection)
                => new CustomHostnameVerifier();

            private sealed class CustomHostnameVerifier : Java.Lang.Object, Javax.Net.Ssl.IHostnameVerifier
            {
                public bool Verify(string hostname, Javax.Net.Ssl.ISSLSession session)
                {
                    return Javax.Net.Ssl.HttpsURLConnection.DefaultHostnameVerifier.Verify(hostname, session) ||
                        hostname == "10.0.2.2" && session.PeerPrincipal?.Name == "CN=localhost";
                }
            }
        }
#elif IOS
        public bool IsHttpsLocalhost(NSUrlSessionHandler sender, string url, Security.SecTrust trust)
        {
            if (url.StartsWith("https://localhost"))
                return true;
            return false;
        }
#endif
    }
}
