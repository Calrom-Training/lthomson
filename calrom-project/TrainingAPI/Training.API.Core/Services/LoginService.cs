// <copyright file="LoginService.cs" company="PlaceholderCompany">
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
    public class LoginService : ILoginService
    {
        private readonly IDatabaseContext databaseContext;

        /// <summary>Initializes a new instance of the <see cref="LoginService" /> class.</summary>
        /// <param name="databaseContext">The database context.</param>
        public LoginService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if sucessful, false otherwise.
        /// </returns>
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty");
            }

            var user = this.databaseContext.GetUser(username, password);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
