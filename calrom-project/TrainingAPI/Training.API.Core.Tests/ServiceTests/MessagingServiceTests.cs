// <copyright file="MessagingServiceTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Training.API.Core.Services;
    using Training.API.DatabaseLibrary;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>Collection of user controller tests.</summary>
    public class MessagingServiceTests
    {
        /// <summary>The test username.</summary>
        private string testUsername;

        private List<Message> testMessages = new List<Message>();

        /// <summary>The mock login service.</summary>
        private Mock<IDatabaseContext> mockDatabaseContext;

        /// <summary>Setup before test execution.</summary>
        [SetUp]
        public void Setup()
        {
            this.testUsername = "test";
            this.mockDatabaseContext = new Mock<IDatabaseContext>();
            this.testMessages.Add(new Message(
                    Guid.NewGuid(),
                    "Test",
                    DateTime.Now,
                    "This is a test message.",
                    "Toby Test",
                    "Harry Test"));
        }

        /// <summary>Tests the user can get messages for a valid user.</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async Task GetMessagesWhenUserPresentInDatabaseTest()
        {
            //// Arrange
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.GetMessagesForUser(this.testUsername)).ReturnsAsync(this.testMessages).Verifiable();
            var sut = new MessagingService(this.mockDatabaseContext.Object);

            //// Act
            var result = await sut.GetMessages(this.testUsername);

            //// Assert
            Assert.AreEqual(this.testMessages, result);
        }

        /// <summary>Gets no messages when user present in database test.</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async Task GetNoMessagesWhenUserPresentInDatabaseTestAsync()
        {
            //// Arrange
            this.mockDatabaseContext.Setup(databaseContext => databaseContext.GetMessagesForUser(this.testUsername)).ReturnsAsync((List<Message>)null).Verifiable();
            var sut = new MessagingService(this.mockDatabaseContext.Object);

            //// Act
            var result = await sut.GetMessages(this.testUsername);

            //// Assert
            Assert.IsNull(result);
        }

        /// <summary>Test for null user parameter.</summary>
        [Test]
        [Category("MockTest")]
        public void NullUserParameterForMessagingServiceTest()
        {
            //// Arrange
            this.testUsername = string.Empty;
            var sut = new MessagingService(this.mockDatabaseContext.Object);

            //// Assert
            Assert.ThrowsAsync(typeof(ArgumentException), () => sut.GetMessages(this.testUsername));
        }

        /// <summary>Post execution assertions common to all tests.</summary>
        [TearDown]
        public void PostExecution()
        {
            this.mockDatabaseContext.VerifyAll();
        }
    }
}