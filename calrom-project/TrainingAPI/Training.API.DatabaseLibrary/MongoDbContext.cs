// <copyright file="MongoDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary
{
    using System.Collections.Generic;
    using MongoDB.Driver;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>The mongo database context.</summary>
    public class MongoDbContext : IDatabaseContext
    {
        private readonly MongoClient mongoClient;

        private readonly IMongoDatabase mongoDatabase;

        private readonly IMongoCollection<Message> mongoMessageCollection;

        private readonly IMongoCollection<User> mongoUserCollection;

        /// <summary>Initializes a new instance of the <see cref="MongoDbContext" /> class.</summary>
        public MongoDbContext()
        {
            this.mongoClient = new MongoClient(MongoDbConstants.MongoDbConnectionString);
            this.mongoDatabase = this.mongoClient.GetDatabase(MongoDbConstants.TestMongoDb);
            this.mongoMessageCollection = this.mongoDatabase.GetCollection<Message>(MongoDbConstants.MongoMessagesCollection);
            this.mongoUserCollection = this.mongoDatabase.GetCollection<User>(MongoDbConstants.MongoUsersCollection);
        }

        /// <summary>
        /// Changes the password for user.
        /// </summary>
        /// <param name="userToUpdate">The user to update.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        /// True if password change was successful, false otherwise.
        /// </returns>
        public bool ChangePasswordForUser(User userToUpdate, string newPassword)
        {
            if (userToUpdate is null)
            {
                return false;
            }

            userToUpdate.Password = newPassword;
            return this.mongoUserCollection.ReplaceOne(user => user.UserId == userToUpdate.UserId, userToUpdate).IsAcknowledged;
        }

        /// <summary>Checks the user credentials.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public User GetUser(string username, string password)
        {
            return this.mongoUserCollection.Find(user => user.Username == username && user.Password == password).FirstOrDefault();
        }

        /// <summary>Gets the messages for user.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public List<Message> GetMessagesForUser(string username)
        {
            return this.mongoMessageCollection.Find(messages => messages.SentTo == username).ToList<Message>();
        }
    }
}
