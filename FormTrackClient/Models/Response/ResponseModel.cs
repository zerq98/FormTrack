namespace FormTrackClient.Models.Response
{
    public class ResponseModel<T>
    {
        public T Data { get; set; }
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
    }
}