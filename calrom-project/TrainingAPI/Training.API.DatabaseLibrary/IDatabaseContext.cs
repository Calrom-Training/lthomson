// <copyright file="IDatabaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary
{
    using System.Collections.Generic;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>Database context interface.</summary>
    public interface IDatabaseContext
    {
        bool CheckUserCredentials(string username, string password);

        List<Message> GetMessagesForUser(string username);

        bool ChangePasswordForUser(string username, string currentPassword, string newPassword);
    }
}
