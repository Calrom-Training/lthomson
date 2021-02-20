// <copyright file="MongoDbQueries.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary
{
    using MongoDB.Driver;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>Mongo Db Queries.</summary>
    public class MongoDbQueries
    {
        private static FilterDefinitionBuilder<User> userFilterBuilder = Builders<User>.Filter;

        private static FilterDefinitionBuilder<Message> messageFilterBuilder = Builders<Message>.Filter;

        /// <summary>Finds the user.</summary>
        /// <param name="username">The username.</param>
        /// <returns>A filter to find the specified username.</returns>
        public static FilterDefinition<User> FindUser(string username)
        {
            return userFilterBuilder.Eq(user => user.Username, username);
        }

        /// <summary>Gets the user messages.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   A filter to find messages for a user.
        /// </returns>
        public static FilterDefinition<Message> GetUserMessages(string username)
        {
            return messageFilterBuilder.Eq(message => message.SentTo, username);
        }
    }
}
