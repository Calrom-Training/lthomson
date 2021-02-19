// <copyright file="PasswordService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Services
{
    using System;
    using Training.API.Core.IServices;
    using Training.API.DatabaseLibrary;

    /// <summary>
    ///  Login service interface.
    /// </summary>
    public class PasswordService : IPasswordService
    {
        private readonly IDatabaseContext databaseContext;

        /// <summary>Initializes a new instance of the <see cref="PasswordService" /> class.</summary>
        /// <param name="databaseContext">The database context.</param>
        public PasswordService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentPassword">Current password.</param>
        /// <param name="newPassword">New password to change to.</param>
        /// <returns>True if sucessful, false otherwise.</returns>
        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty", nameof(username));
            }

            if (string.IsNullOrEmpty(currentPassword))
            {
                throw new ArgumentException($"'{nameof(currentPassword)}' cannot be null or empty", nameof(currentPassword));
            }

            if (string.IsNullOrEmpty(newPassword))
            {
                throw new ArgumentException($"'{nameof(newPassword)}' cannot be null or empty", nameof(newPassword));
            }

            return this.databaseContext.ChangePasswordForUser(username, currentPassword, newPassword);
        }
    }
}
