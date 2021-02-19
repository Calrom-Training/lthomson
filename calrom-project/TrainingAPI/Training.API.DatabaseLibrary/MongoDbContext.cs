// <copyright file="MongoDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary
{
    using System.Collections.Generic;
    using Training.API.DatabaseLibrary.Models;

    public class MongoDbContext : IDatabaseContext
    {
        public bool ChangePasswordForUser(string username, string currentPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckUserCredentials(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public List<Message> GetMessagesForUser(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
