﻿namespace ISIParkAPI.Model
{
    public class User
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}

