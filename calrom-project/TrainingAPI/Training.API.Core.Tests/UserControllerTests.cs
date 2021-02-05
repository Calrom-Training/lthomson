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
    using Training.API.Core.IServices;

    /// <summary>Collection of user controller tests.</summary>
    public class UserControllerTests
    {
        /// <summary>The user name parameter.</summary>
        private const string UserNameParam = "username";

        /// <summary>The password parameter.</summary>
        private const string PasswordParam = "password";

        /// <summary>The new password parameter.</summary>
        private const string NewPasswordParam = "newPassword";

        /// <summary>The test username.</summary>
        private string testUsername;

        /// <summary>The test password.</summary>
        private string testPassword;

        /// <summary>The new password.</summary>
        private string newPassword;

        /// <summary>The mock login service.</summary>
        private Mock<ILoginService> mockLoginService;

        /// <summary>The mock password service.</summary>
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
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Returns(true).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.testUsername, this.testPassword) as OkResult;

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
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Returns(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.testUsername, this.testPassword) as ForbidResult;

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

            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Throws(new ArgumentNullException());
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.testUsername, this.testPassword) as ObjectResult;

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
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).Returns(true).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.ChangePassword(this.testUsername, this.testPassword, this.newPassword) as OkResult;

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
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).Returns(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.ChangePassword(this.testUsername, this.testPassword, this.newPassword) as ForbidResult;

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
        public void ChangePasswordWithCorrectPassword(string nameOfEmptyParameter)
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
            this.mockPasswordService.Setup(passwordService => passwordService.ChangePassword(this.testUsername, this.testPassword, this.newPassword)).Throws(new ArgumentNullException()).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.ChangePassword(this.testUsername, this.testPassword, this.newPassword) as ObjectResult;

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