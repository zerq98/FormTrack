﻿namespace FormTrackClient.Models.Response
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}