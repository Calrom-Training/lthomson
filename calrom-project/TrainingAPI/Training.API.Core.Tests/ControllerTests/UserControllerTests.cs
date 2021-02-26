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
        [Test]
        [Category("MockTest")]
        public void LoginWithValidCredentialsTest()
        {
            //// Arrange
            this.loginRequest = new LoginRequest(this.testUsername, this.testPassword);
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Returns(true).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.loginRequest) as OkResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        /// <summary>Tests the user cannot login with invalid credentials.</summary>
        [Test]
        [Category("MockTest")]
        public void LoginWithInvalidCredentialsTest()
        {
            //// Arrange
            this.loginRequest = new LoginRequest(this.testUsername, this.testPassword);
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Returns(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.loginRequest) as ForbidResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        /// <summary>Tests the user cannot login with one of the parameters empty.</summary>
        /// <param name="nameOfEmptyParameter">The parameter to be set as empty.</param>
        [Test]
        [TestCase(UserNameParam)]
        [TestCase(PasswordParam)]
        [Category("MockTest")]
        public void LoginWithEmptyParameters(string nameOfEmptyParameter)
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
            var result = sut.LoginRequest(this.loginRequest) as ObjectResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        /// <summary>Tests the user can change the password with valid credentials.</summary>
        [Test]
        [Category("MockTest")]
        public void ChangePasswordWithCorrectPassword()
        {
            //// Arrange
            this.changePasswordRequest = new ChangePasswordRequest(this.testUsername, this.testPassword, this.newPassword);
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).Returns(true).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.ChangePassword(this.changePasswordRequest) as OkResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        /// <summary>Tests the user cannot change the password with invalid credentials.</summary>
        [Test]
        [Category("MockTest")]
        public void ChangePasswordWithInorrectPassword()
        {
            //// Arrange
            this.changePasswordRequest = new ChangePasswordRequest(this.testUsername, this.testPassword, this.newPassword);
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).Returns(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.ChangePassword(this.changePasswordRequest) as ForbidResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        /// <summary>Tests the user cannot change the password if one of the parameters is empty.</summary>
        /// <param name="nameOfEmptyParameter">The parameter to be set as empty.</param>
        [Test]
        [TestCase(UserNameParam)]
        [TestCase(PasswordParam)]
        [TestCase(NewPasswordParam)]
        [Category("MockTest")]
        public void ChangePasswordWithEmptyParameters(string nameOfEmptyParameter)
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
            var result = sut.ChangePassword(this.changePasswordRequest) as ObjectResult;

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