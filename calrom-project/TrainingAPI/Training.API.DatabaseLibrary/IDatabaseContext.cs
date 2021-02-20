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
        /// <summary>Checks the user credentials.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        bool CheckUserCredentials(string username, string password);

        /// <summary>Gets the messages for user.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        List<Message> GetMessagesForUser(string username);

        /// <summary>Changes the password for user.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        bool ChangePasswordForUser(string username, string currentPassword, string newPassword);
    }
}
