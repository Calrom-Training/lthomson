// <copyright file="PasswordServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.UnitTests
{
    using System;
    using Moq;
    using NUnit.Framework;
    using Training.API.Core.Services;
    using Training.API.DatabaseLibrary;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>Collection of user controller tests.</summary>
    public class PasswordServiceTests
    {
        private const string UserNameParam = "username";

        private const string PasswordParam = "password";

        private const string NewPasswordParam = "newPassword";

        private string testUsername;

        private string testPassword;

        private string newPassword;

        private User testUser;

        private Mock<IDatabaseContext> mockDatabaseContext;

        /// <summary>Setup before test execution.</summary>
        [SetUp]
        public void Setup()
        {
            this.testUsername = "test";
            this.testPassword = "123456";
            this.newPassword = "abcdef";
            this.testUser = new User(1, this.testUsername, this.testPassword);
            this.mockDatabaseContext = new Mock<IDatabaseContext>();
        }

        /// <summary>Tests the user can get messages for a valid user.</summary>
        [Test]
        [Category("MockTest")]
        public void ServiceReturnsTrueForValidCredentials()
        {
            //// Arrange
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.GetUser(this.testUsername, this.testPassword)).Returns(this.testUser);
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.ChangePasswordForUser(this.testUser, this.newPassword)).Returns(true);
            var sut = new PasswordService(this.mockDatabaseContext.Object);

            //// Act
            var result = sut.ChangePassword(this.testUsername, this.testPassword, this.newPassword);

            //// Assert
            Assert.IsTrue(result);
        }

        /// <summary>Tests the user can get messages for a valid user.</summary>
        [Test]
        [Category("MockTest")]
        public void ServiceReturnsFalseForInvalidCredentials()
        {
            //// Arrange
            User notFoundUser = (User)null;
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.GetUser(this.testUsername, this.testPassword)).Returns(notFoundUser);
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.ChangePasswordForUser(notFoundUser, this.newPassword)).Returns(false);
            var sut = new PasswordService(this.mockDatabaseContext.Object);

            //// Act
            var result = sut.ChangePassword(this.testUsername, this.testPassword, this.newPassword);

            //// Assert
            Assert.IsFalse(result);
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
            var sut = new PasswordService(this.mockDatabaseContext.Object);

            //// Assert
            Assert.Throws(typeof(ArgumentException), () => sut.ChangePassword(this.testUsername, this.testPassword, this.newPassword));
        }

        /// <summary>Post execution assertions common to all tests.</summary>
        [TearDown]
        public void PostExecution()
        {
            this.mockDatabaseContext.VerifyAll();
        }
    }
}