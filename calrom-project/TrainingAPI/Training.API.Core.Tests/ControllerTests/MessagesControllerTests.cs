// <copyright file="MessagesControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using Training.API.Core.Controllers;
    using Training.API.Core.IServices;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>Collection of user controller tests.</summary>
    public class MessagesControllerTests
    {
        private readonly List<Message> testMessages = new List<Message>();

        private string testUsername;

        private Mock<IMessagingService> mockMessagingService;

        /// <summary>Setup before test execution.</summary>
        [SetUp]
        public void Setup()
        {
            this.testUsername = "test";
            this.mockMessagingService = new Mock<IMessagingService>();
            this.testMessages.Add(new Message(
                    Guid.NewGuid(),
                    "Test",
                    DateTime.Now,
                    "This is a test message.",
                    "Toby Test",
                    "Harry Test"));
        }

        /// <summary>Gets the messages when user present test.</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async Task GetMessagesWhenUserPresentTest()
        {
            //// Arrange
            this.mockMessagingService.Setup(messagingService => messagingService.GetMessages(this.testUsername)).ReturnsAsync(this.testMessages).Verifiable();
            var sut = new MessagesController(this.mockMessagingService.Object);

            //// Act
            var result = await sut.GetMessages(this.testUsername) as OkObjectResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(this.testMessages, result.Value);
        }

        /// <summary>Tests an OK response is still returned when no messages are found.</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async Task NoMessagesForUserTest()
        {
            //// Arrange
            this.mockMessagingService.Setup(messagingService => messagingService.GetMessages(this.testUsername)).ReturnsAsync((List<Message>)null).Verifiable();
            var sut = new MessagesController(this.mockMessagingService.Object);

            //// Act
            var result = await sut.GetMessages(this.testUsername) as OkObjectResult;

            //// Assert
            Assert.IsNull(result.Value);
            Assert.AreEqual(200, result.StatusCode);
        }

        /// <summary>Tests an error is thrown when the user supplied is empty.</summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        [Category("MockTest")]
        public async Task EmptyParameterTest()
        {
            //// Arrange
            this.testUsername = string.Empty;
            this.mockMessagingService.Setup(messagingService => messagingService.GetMessages(this.testUsername)).Throws(new ArgumentNullException()).Verifiable();
            var sut = new MessagesController(this.mockMessagingService.Object);

            //// Act
            var result = await sut.GetMessages(this.testUsername) as ObjectResult;

            //// Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
        }

        /// <summary>Post execution assertions common to all tests.</summary>
        [TearDown]
        public void PostExecution()
        {
            this.mockMessagingService.VerifyAll();
        }
    }
}