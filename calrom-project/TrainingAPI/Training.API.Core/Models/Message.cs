// <copyright file="Message.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Models
{
    using System;

    /// <summary>
    ///  Messages model.
    /// </summary>
    public class Message
    {
        private readonly Guid messageId;

        private readonly string subject;

        private readonly DateTime sentDate;

        private readonly string body;

        private readonly string sentBy;

        private readonly string sentTo;

        /// <summary>Initializes a new instance of the <see cref="Message" /> class.</summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="sentDate">The sent date.</param>
        /// <param name="body">The body.</param>
        /// <param name="sentBy">The sent by.</param>
        public Message(Guid messageId, string subject, DateTime sentDate, string body, string sentBy, string sentTo)
        {
            this.messageId = messageId;
            this.subject = subject;
            this.sentDate = sentDate;
            this.body = body;
            this.sentBy = sentBy;
            this.sentTo = sentTo;
        }
    }
}
