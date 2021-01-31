// <copyright file="MessagesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Training.API.Core.IServices;
    using Training.API.Core.Models;

    /// <summary>
    ///   The messages controller.
    /// </summary>
    [ApiController]
    [Route("api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagingService messageService;

        /// <summary>Initializes a new instance of the <see cref="MessagesController" /> class.</summary>
        /// <param name="messageService">The message service.</param>
        public MessagesController(IMessagingService messageService)
        {
            this.messageService = messageService;
        }

        /// <summary>Gets the messages.</summary>
        /// <param name="username">The username.</param>
        /// <returns>List of messages for the user.</returns>
        [HttpGet("{username}")]
        public List<Message> GetMessages(string username)
        {
            return this.messageService.GetMessages(username);
        }
    }
}
