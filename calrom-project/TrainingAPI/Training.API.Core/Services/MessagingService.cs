// <copyright file="MessagingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Services
{
    using System;
    using System.Collections.Generic;
    using Training.API.Core.IServices;
    using Training.API.DatabaseLibrary;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>
    ///   Messaging service.
    /// </summary>
    public class MessagingService : IMessagingService
    {
        private readonly IDatabaseContext databaseContext;

        /// <summary>Initializes a new instance of the <see cref="MessagingService" /> class.</summary>
        /// <param name="databaseContext">The database context.</param>
        public MessagingService(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>Gets the messages.</summary>
        /// <param name="username">The username.</param>
        /// <returns>A list of messages for the user.</returns>
        public List<Message> GetMessages(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty");
            }

            return this.databaseContext.GetMessagesForUser(username);
        }
    }
}
