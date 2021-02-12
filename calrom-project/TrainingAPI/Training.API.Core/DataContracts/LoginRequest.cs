// <copyright file="LoginRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.DataContracts
{
    /// <summary>
    ///   The login request data contract.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>Initializes a new instance of the <see cref="LoginRequest" /> class.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public LoginRequest(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        /// <summary>Gets or sets  the username.</summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>Gets or sets  the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }
    }
}
