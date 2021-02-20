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
        private MongoClient mongoClient;

        private IMongoDatabase mongoDatabase;

        private IMongoCollection<Message> mongoMessageCollection;

        private IMongoCollection<User> mongoUserCollection;

        /// <summary>Initializes a new instance of the <see cref="MongoDbContext" /> class.</summary>
        public MongoDbContext()
        {
            this.mongoClient = new MongoClient(MongoDbConstants.MongoDbConnectionString);
            this.mongoDatabase = this.mongoClient.GetDatabase(MongoDbConstants.TestMongoDb);
            this.mongoMessageCollection = this.mongoDatabase.GetCollection<Message>(MongoDbConstants.MongoMessagesCollection);
            this.mongoUserCollection = this.mongoDatabase.GetCollection<User>(MongoDbConstants.MongoUsersCollection);
        }

        /// <summary>Changes the password for user.</summary>
        /// <param name="username">The username.</param>
        /// <param name="currentPassword">The current password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool ChangePasswordForUser(string username, string currentPassword, string newPassword)
        {
            var user = this.mongoUserCollection.Find(MongoDbQueries.FindUser(username));
            if (user.Any() && user.FirstOrDefault().Password == currentPassword)
            {
                var updatedUser = user.FirstOrDefault();
                updatedUser.Password = newPassword;
                this.mongoUserCollection.ReplaceOne(MongoDbQueries.FindUser(username), updatedUser);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Checks the user credentials.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public bool CheckUserCredentials(string username, string password)
        {
            var user = this.mongoUserCollection.Find(MongoDbQueries.FindUser(username));
            if (user.Any() && user.FirstOrDefault().Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Gets the messages for user.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public List<Message> GetMessagesForUser(string username)
        {
            return this.mongoMessageCollection.Find(MongoDbQueries.GetUserMessages(username)).ToList<Message>();
        }
    }
}
