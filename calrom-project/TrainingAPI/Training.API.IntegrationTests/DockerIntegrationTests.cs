// <copyright file="DockerIntegrationTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.IntegrationTests
{
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;
    using Training.API.Core.Controllers;
    using Training.API.Core.Services;
    using Training.API.Core.DataContracts;
    using Training.API.DatabaseLibrary;
    using Training.API.DatabaseLibrary.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>Tests to be ran with mongo in a docker container.</summary>
    public class DockerIntegrationTests
    {
        private MongoDbContext mongoDbContext;

        private LoginService loginService;

        private PasswordService passwordService;

        private MessagingService messagingService;

        private UserController userController;

        private MessagesController messagesController;

        private ChangePasswordRequest invalidChangePasswordRequest;

        private ChangePasswordRequest validChangePasswordRequest;

        private LoginRequest invalidLoginRequest;

        private LoginRequest validLoginRequest;

        private Message expectedMessages;

        private string testUser = "Dick";

        [SetUp]
        public void Setup()
        {
            MongoDbConstants.MongoDbConnectionString = $"mongodb://localhost:27017/{MongoDbConstants.TestMongoDb}";
            this.mongoDbContext = new MongoDbContext();
            this.loginService = new LoginService(this.mongoDbContext);
            this.passwordService = new PasswordService(this.mongoDbContext);
            this.messagingService = new MessagingService(this.mongoDbContext);
            this.messagesController = new MessagesController(messagingService);
            this.userController = new UserController(loginService, passwordService);
            this.validLoginRequest = new LoginRequest("Harry", "mcfc123");
            this.invalidLoginRequest = new LoginRequest("Harry", "aed");
            this.validChangePasswordRequest = new ChangePasswordRequest("Harry", "mcfc123", "ChangeMe1237");
            this.invalidChangePasswordRequest = new ChangePasswordRequest("Harry", "123", "ChangeMe1237");
            this.expectedMessages = new Message(new System.Guid("0cc66d1a-5948-4dc7-9594-456ce37ef07b"), "Hi Dick!", DateTime.Parse("2021-01-15T00:00:00Z"), "This is a test message", "Tom", "Dick");
        }

        [Test]
        [Category("DockerIntegrationTest")]
        public void MessagesReturnedIfExists()
        {
            var result = this.messagesController.GetMessages(this.testUser) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var messages = result.Value as List<Message>;
            Assert.IsNotEmpty(messages);
            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(expectedMessages.MessageId, messages[0].MessageId);
        }

        [Test]
        [Category("DockerIntegrationTest")]
        public void MessagesNotReturnedIfNoneExist()
        {
            var result = this.messagesController.GetMessages("Tom") as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var messages = result.Value as List<Message>;
            Assert.IsEmpty(messages);
        }

        [Test]
        [Category("DockerIntegrationTest")]
        public void UserCanloginWithValidCredentials()
        {
            var result = this.userController.LoginRequest(this.validLoginRequest) as OkResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        [Category("DockerIntegrationTest")]
        public void UserCanChangePasswordWithValidCredentials()
        {
            var result = this.userController.ChangePassword(this.validChangePasswordRequest) as OkResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            result = this.userController.LoginRequest(new LoginRequest(this.validChangePasswordRequest.Username, this.validChangePasswordRequest.NewPassword)) as OkResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var changePasswordBackRequest = new ChangePasswordRequest(this.validChangePasswordRequest.Username, this.validChangePasswordRequest.NewPassword, this.validChangePasswordRequest.Password);
            this.userController.ChangePassword(changePasswordBackRequest);
        }

        [Test]
        [Category("DockerIntegrationTest")]
        public void UserCannotChangePasswordWithInvalidCredentials()
        {
            var result = this.userController.ChangePassword(this.invalidChangePasswordRequest) as ForbidResult;
            Assert.IsNotNull(result);
        }


        [Test]
        [Category("DockerIntegrationTest")]
        public void UserCannotloginWithInvalidCredentials()
        {
            var result = this.userController.LoginRequest(this.invalidLoginRequest) as ForbidResult;
            Assert.IsNotNull(result);
        }

        [TearDown]
        public void PostExecution()
        {

        }
    }
}