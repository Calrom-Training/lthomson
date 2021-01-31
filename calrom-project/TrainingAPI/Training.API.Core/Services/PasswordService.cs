// <copyright file="PasswordService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Services
{
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
            if (username == "test" && currentPassword == "123456")
            {
                // no implementation for actually changing password yet
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
