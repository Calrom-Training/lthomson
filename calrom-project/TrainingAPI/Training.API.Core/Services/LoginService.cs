// <copyright file="LoginService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Services
{
    using Training.API.Core.IServices;

    /// <summary>
    ///  Login service interface.
    /// </summary>
    public class LoginService : ILoginService
    {
        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if sucessful, false otherwise.
        /// </returns>
        public bool Login(string username, string password)
        {
            if (username == "test" && password == "123456")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
