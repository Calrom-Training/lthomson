// <copyright file="ILoginService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.IServices
{
    /// <summary>
    ///  Login service interface.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>Logins the specified username.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True if sucessful, false otherwise.
        /// </returns>
        bool Login(string username, string password);
    }
}
