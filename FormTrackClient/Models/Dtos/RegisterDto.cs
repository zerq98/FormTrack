﻿namespace FormTrackClient.Models.Dtos
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool IsNormalUser { get; set; }
    }
}