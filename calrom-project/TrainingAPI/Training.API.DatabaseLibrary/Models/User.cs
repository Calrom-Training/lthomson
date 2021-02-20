// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    /// <summary>The user data model.</summary>
    public class User
    {
        /// <summary>Initializes a new instance of the <see cref="User" /> class.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public User(int userId, string username, string password)
        {
            this.UserId = userId;
            this.Username = username;
            this.Password = password;
        }

        /// <summary>Gets or sets the user identifier.</summary>
        /// <value>The user identifier.</value>
        [BsonId]
        public int UserId { get; set; }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        [BsonElement("Username")]
        public string Username { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
