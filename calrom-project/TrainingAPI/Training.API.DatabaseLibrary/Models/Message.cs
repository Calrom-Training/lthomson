// <copyright file="Message.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary.Models
{
    using System;
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>
    ///  Messages data model.
    /// </summary>
    public class Message
    {
        /// <summary>Initializes a new instance of the <see cref="Message" /> class.</summary>
        /// <param name="messageId">The message identifier.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="sentDate">The sent date.</param>
        /// <param name="body">The body.</param>
        /// <param name="sentBy">The sent by.</param>
        /// <param name="sentTo">The sent to.</param>
        public Message(Guid messageId, string subject, DateTime sentDate, string body, string sentBy, string sentTo)
        {
            this.MessageId = messageId;
            this.Subject = subject;
            this.SentDate = sentDate;
            this.Body = body;
            this.SentBy = sentBy;
            this.SentTo = sentTo;
        }

        /// <summary>Gets or sets the message identifier.</summary>
        /// <value>The message identifier.</value>
        [BsonId]
        public Guid MessageId { get; set; }

        /// <summary>Gets or sets the subject.</summary>
        /// <value>The subject.</value>
        [BsonElement("subject")]
        public string Subject { get; set; }

        /// <summary>Gets or sets the sent date.</summary>
        /// <value>The sent date.</value>
        [BsonElement("sentDate")]
        public DateTime SentDate { get; set; }

        /// <summary>Gets or sets the body.</summary>
        /// <value>The body.</value>
        [BsonElement("body")]
        public string Body { get; set; }

        /// <summary>Gets or sets the sent by.</summary>
        /// <value>The sent by.</value>
        [BsonElement("sentBy")]
        public string SentBy { get; set; }

        /// <summary>Gets or sets the sent to.</summary>
        /// <value>The sent to.</value>
        [BsonElement("sentTo")]
        public string SentTo { get; set; }
    }
}
