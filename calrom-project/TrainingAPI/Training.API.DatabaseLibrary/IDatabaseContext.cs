// <copyright file="IDatabaseContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>Database context interface.</summary>
    public interface IDatabaseContext
    {
        /// <summary>Checks the user credentials.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   User matching the credentials.
        /// </returns>
        Task<User> GetUser(string username, string password);

        /// <summary>Gets the messages for user.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   List of messages for the user.
        /// </returns>
        Task<List<Message>> GetMessagesForUser(string username);

        /// <summary>Changes the password for user.</summary>
        /// <param name="user">The user.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        ///   True if password was changed succesfully, false otherwise.
        /// </returns>
        Task<bool> ChangePasswordForUser(User user, string newPassword);
    }
}
