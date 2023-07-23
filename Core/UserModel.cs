﻿namespace Core
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public UserModel(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public override string? ToString()
        {
            return $"Name: {Name} Password:{Password}";
        }
    }
}