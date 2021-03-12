// <copyright file="UserController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Training.API.Core.DataContracts;
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
        /// <param name="loginRequest">The login request.</param>
        /// <returns>True, if login is sucessful. False, otherwise.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> LoginRequest([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var loginResult = await this.loginService.Login(loginRequest.Username, loginRequest.Password);
                if (loginResult)
                {
                    return this.Ok();
                }
                else
                {
                    return this.Forbid();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"The following error has occured: {ex.Message}");
            }
        }

        /// <summary>Changes the password.</summary>
        /// <param name="changePasswordRequest">The change password request.</param>
        /// <returns>True, on success. False, otherwise.</returns>
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            try
            {
                var changePasswordResult = await this.passwordService.ChangePassword(changePasswordRequest.Username, changePasswordRequest.Password, changePasswordRequest.NewPassword);
                if (changePasswordResult)
                {
                    return this.Ok();
                }
                else
                {
                    return this.Forbid();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"The following error has occured: {ex.Message}");
            }
        }
    }
}
