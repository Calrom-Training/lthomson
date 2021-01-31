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
        /// <summary>Gets or sets the message identifier.</summary>
        /// <value>The message identifier.</value>
        private readonly Guid messageId;

        /// <summary>The subject.</summary>
        private readonly string subject;

        /// <summary>The sent date.</summary>
        private readonly DateTime sentDate;

        /// <summary>The body.</summary>
        private readonly string body;

        /// <summary>The sent by.</summary>
        private readonly string sentBy;

        /// <summary>Initializes a new instance of the <see cref="Message" /> class.</summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="sentDate">The sent date.</param>
        /// <param name="body">The body.</param>
        /// <param name="sentBy">The sent by.</param>
        public Message(Guid messageId, string subject, DateTime sentDate, string body, string sentBy)
        {
            this.messageId = messageId;
            this.subject = subject;
            this.sentDate = sentDate;
            this.body = body;
            this.sentBy = sentBy;
        }
    }
}
