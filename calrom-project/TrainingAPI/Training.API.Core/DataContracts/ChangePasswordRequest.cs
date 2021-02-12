// <copyright file="ChangePasswordRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.DataContracts
{
    /// <summary>
    ///   The login request data contract.
    /// </summary>
    public class ChangePasswordRequest
    {
        /// <summary>Initializes a new instance of the <see cref="ChangePasswordRequest" /> class.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="newPassword">The new password.</param>
        public ChangePasswordRequest(string username, string password, string newPassword)
        {
            this.Username = username;
            this.Password = password;
            this.NewPassword = newPassword;
        }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>Gets or sets  the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>Gets or sets  the new password.</summary>
        /// <value>The new password.</value>
        public string NewPassword { get; set; }
    }
}
