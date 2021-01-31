// <copyright file="MessagingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Services
{
    using System;
    using System.Collections.Generic;
    using Training.API.Core.IServices;
    using Training.API.Core.Models;

    /// <summary>
    ///   Messaging service.
    /// </summary>
    public class MessagingService : IMessagingService
    {
        /// <summary>Gets the messages.</summary>
        /// <param name="username">The username.</param>
        /// <returns>A list of messages for the user.</returns>
        public List<Message> GetMessages(string username)
        {
            var messages = new List<Message>();
            var testMessage = new Message(
                    Guid.NewGuid(),
                    "Rick Roll'd",
                    DateTime.Now,
                    "Never gonna give you up, never gonna let you down.",
                    "Rick Astley");
            if (username == "rickastley")
            {
                messages.Add(testMessage);
            }

            return messages;
        }
    }
}
