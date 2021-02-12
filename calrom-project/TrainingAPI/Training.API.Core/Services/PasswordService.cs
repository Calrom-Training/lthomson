// <copyright file="PasswordService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Services
{
    using System;
    using Training.API.Core.IServices;

    /// <summary>
    ///  Login service interface.
    /// </summary>
    public class PasswordService : IPasswordService
    {
        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentPassword">Current password.</param>
        /// <param name="newPassword">New password to change to.</param>
        /// <returns>True if sucessful, false otherwise.</returns>
        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
