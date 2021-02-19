// <copyright file="LoginServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.UnitTests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using Training.API.Core.Services;
    using Training.API.DatabaseLibrary;

    /// <summary>Collection of user controller tests.</summary>
    public class LoginServiceTests
    {
        private const string UserNameParam = "username";

        private const string PasswordParam = "password";

        private string testUsername;

        private string testPassword;

        private Mock<IDatabaseContext> mockDatabaseContext;

        /// <summary>Setup before test execution.</summary>
        [SetUp]
        public void Setup()
        {
            this.testUsername = "test";
            this.testPassword = "123456";
            this.mockDatabaseContext = new Mock<IDatabaseContext>();
        }

        /// <summary>Tests the user can get messages for a valid user.</summary>
        [Test]
        [Category("MockTest")]
        public void ServiceReturnsTrueForValidCredentials()
        {
            //// Arrange
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.CheckUserCredentials(this.testUsername, this.testPassword)).Returns(true);
            var sut = new LoginService(this.mockDatabaseContext.Object);

            //// Act
            var result = sut.Login(this.testUsername, this.testPassword);

            //// Assert
            Assert.IsTrue(result);
        }

        /// <summary>Tests the user can get messages for a valid user.</summary>
        [Test]
        [Category("MockTest")]
        public void ServiceReturnsFalseForInvalidCredentials()
        {
            //// Arrange
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.CheckUserCredentials(this.testUsername, this.testPassword)).Returns(false);
            var sut = new LoginService(this.mockDatabaseContext.Object);

            //// Act
            var result = sut.Login(this.testUsername, this.testPassword);

            //// Assert
            Assert.IsFalse(result);
        }

        /// <summary>Tests the user cannot change the password if one of the parameters is empty.</summary>
        /// <param name="nameOfEmptyParameter">The parameter to be set as empty.</param>
        [Test]
        [TestCase(UserNameParam)]
        [TestCase(PasswordParam)]
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
            }

            //// Arrange
            var sut = new LoginService(this.mockDatabaseContext.Object);

            //// Assert
            Assert.Throws(typeof(ArgumentException), () => sut.Login(this.testUsername, this.testPassword));
        }

        /// <summary>Post execution assertions common to all tests.</summary>
        [TearDown]
        public void PostExecution()
        {
            this.mockDatabaseContext.VerifyAll();
        }
    }
}