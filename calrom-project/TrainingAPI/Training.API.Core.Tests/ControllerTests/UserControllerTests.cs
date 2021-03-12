// <copyright file="UserControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.UnitTests
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using Training.API.Core.Controllers;
    using Training.API.Core.DataContracts;
    using Training.API.Core.IServices;

    /// <summary>Collection of user controller tests.</summary>
    public class UserControllerTests
    {
        private const string UserNameParam = "username";

        private const string PasswordParam = "password";

        private const string NewPasswordParam = "newPassword";

        private ChangePasswordRequest changePasswordRequest;

        private LoginRequest loginRequest;

        private string testUsername;

        private string testPassword;

        private string newPassword;

        private Mock<ILoginService> mockLoginService;

        private Mock<IPasswordService> mockPasswordService;

        /// <summary>Setup before test execution.</summary>
        [SetUp]
        public void Setup()
        {
            this.testUsername = "test";
            this.testPassword = "123456";
            this.mockLoginService = new Mock<ILoginService>();
            this.mockPasswordService = new Mock<IPasswordService>();
        }

        /// <summary>Tests the user can login with valid credentials.</summary>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async System.Threading.Tasks.Task LoginWithValidCredentialsTestAsync()
        {
            //// Arrange
            this.loginRequest = new LoginRequest(this.testUsername, this.testPassword);
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).ReturnsAsync(true).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = await sut.LoginRequest(this.loginRequest) as OkResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        /// <summary>Tests the user cannot login with invalid credentials.</summary>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async System.Threading.Tasks.Task LoginWithInvalidCredentialsTestAsync()
        {
            //// Arrange
            this.loginRequest = new LoginRequest(this.testUsername, this.testPassword);
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).ReturnsAsync(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = await sut.LoginRequest(this.loginRequest) as ForbidResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        /// <summary>Tests the user cannot login with one of the parameters empty.</summary>
        /// <param name="nameOfEmptyParameter">The parameter to be set as empty.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [TestCase(UserNameParam)]
        [TestCase(PasswordParam)]
        [Category("MockTest")]
        public async System.Threading.Tasks.Task LoginWithEmptyParametersAsync(string nameOfEmptyParameter)
        {
            // Arrange
            switch (nameOfEmptyParameter)
            {
                case UserNameParam:
                    this.testUsername = string.Empty;
                    break;
                case PasswordParam:
                    this.testPassword = string.Empty;
                    break;
            }

            this.loginRequest = new LoginRequest(this.testUsername, this.testPassword);
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Throws(new ArgumentNullException());
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = await sut.LoginRequest(this.loginRequest) as ObjectResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        /// <summary>Tests the user can change the password with valid credentials.</summary>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async System.Threading.Tasks.Task ChangePasswordWithCorrectPasswordAsync()
        {
            //// Arrange
            this.changePasswordRequest = new ChangePasswordRequest(this.testUsername, this.testPassword, this.newPassword);
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).ReturnsAsync(true).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = await sut.ChangePassword(this.changePasswordRequest) as OkResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        /// <summary>Tests the user cannot change the password with invalid credentials.</summary>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async System.Threading.Tasks.Task ChangePasswordWithInorrectPasswordAsync()
        {
            //// Arrange
            this.changePasswordRequest = new ChangePasswordRequest(this.testUsername, this.testPassword, this.newPassword);
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).ReturnsAsync(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = await sut.ChangePassword(this.changePasswordRequest) as ForbidResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        /// <summary>Tests the user cannot change the password if one of the parameters is empty.</summary>
        /// <param name="nameOfEmptyParameter">The parameter to be set as empty.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [TestCase(UserNameParam)]
        [TestCase(PasswordParam)]
        [TestCase(NewPasswordParam)]
        [Category("MockTest")]
        public async System.Threading.Tasks.Task ChangePasswordWithEmptyParametersAsync(string nameOfEmptyParameter)
        {
            switch (nameOfEmptyParameter)
            {
                case UserNameParam:
                    this.testUsername = string.Empty;
                    break;
                case PasswordParam:
                    this.testPassword = string.Empty;
                    break;
                case NewPasswordParam:
                    this.newPassword = string.Empty;
                    break;
            }

            //// Arrange
            this.changePasswordRequest = new ChangePasswordRequest(this.testUsername, this.testPassword, this.newPassword);
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).Throws(new ArgumentNullException()).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = await sut.ChangePassword(this.changePasswordRequest) as ObjectResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        /// <summary>Post execution assertions common to all tests.</summary>
        [TearDown]
        public void PostExecution()
        {
            this.mockLoginService.VerifyAll();
            this.mockPasswordService.VerifyAll();
        }
    }
}