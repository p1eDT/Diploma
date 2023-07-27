﻿namespace Core
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override string? ToString()
        {
            return $"Name: {Email} Password:{Password}";
        }
    }
}