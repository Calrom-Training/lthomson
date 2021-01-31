// <copyright file="UserController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Training.API.Core.IServices;

    /// <summary>
    ///   The user controller.
    /// </summary>
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ILoginService loginService;
        private readonly IPasswordService passwordService;

        /// <summary>Initializes a new instance of the <see cref="UserController" /> class.</summary>
        /// <param name="loginService">The login service.</param>
        /// <param name="passwordService">The password service.</param>
        public UserController(ILoginService loginService, IPasswordService passwordService)
        {
            this.loginService = loginService;
            this.passwordService = passwordService;
        }

        /// <summary>Logins the request.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   True, if login is sucessful. False, otherwise.
        /// </returns>
        [HttpPost("login")]
        public bool LoginRequest(string username, string password)
        {
            return this.loginService.Login(username, password);
        }

        /// <summary>Changes the password.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>True, on success. False, otherwise.</returns>
        [HttpPost("changepassword")]
        public bool ChangePassword(string username, string currentPassword, string newPassword)
        {
            return this.passwordService.ChangePassword(username, currentPassword, newPassword);
        }
    }
}
