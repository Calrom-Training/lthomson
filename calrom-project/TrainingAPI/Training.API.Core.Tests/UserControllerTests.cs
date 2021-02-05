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

    /// <summary>Collection of user tests.</summary>
    public class UserControllerTests
    {
        /// <summary>The test username.</summary>
        private string testUsername;

        /// <summary>The test password.</summary>
        private string testPassword;

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
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, this.testPassword)).Returns(false).Verifiable();
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.testUsername, this.testPassword) as ForbidResult;

            //// Assert
            Assert.IsNotNull(result);
        }

        /// <summary>Tests the user cannot login without a password.</summary>
        [Test]
        [Category("MockTest")]
        public void LoginWithoutPasswordTest()
        {
            this.mockLoginService.Setup(loginService => loginService.Login(this.testUsername, string.Empty)).Throws(new ArgumentNullException());
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(this.testUsername, string.Empty) as ObjectResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        /// <summary>Tests the user cannot login without a username.</summary>
        [Test]
        [Category("MockTest")]
        public void LoginWithoutUsernameTest()
        {
            this.mockLoginService.Setup(loginService => loginService.Login(string.Empty, this.testPassword)).Throws(new ArgumentNullException());
            var sut = new UserController(this.mockLoginService.Object, this.mockPasswordService.Object);

            //// Act
            var result = sut.LoginRequest(string.Empty, this.testPassword) as ObjectResult;

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