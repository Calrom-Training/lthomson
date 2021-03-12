// <copyright file="IPasswordService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.IServices
{
    using System.Threading.Tasks;

    /// <summary>
    ///  Password service interface.
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>Changes the password.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        ///  True if change password was sucessful, false otherwise.
        /// </returns>
        Task<bool> ChangePassword(string username, string currentPassword, string newPassword);
    }
}
