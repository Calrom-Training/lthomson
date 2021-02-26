// <copyright file="MongoDbConstants.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.DatabaseLibrary
{
    /// <summary>Mongo Db Constants.</summary>
    public static class MongoDbConstants
    {
        /// <summary>The test mongo database.</summary>
        public const string TestMongoDb = "TestTrainingApiDb";

        /// <summary>The mongo messages collection.</summary>
        public const string MongoMessagesCollection = "Messages";

        /// <summary>The mongo users collection.</summary>
        public const string MongoUsersCollection = "Users";

        /// <summary>The mongo database connection string.</summary>
        public static string MongoDbConnectionString = $"mongodb://training_mongo:27017/{TestMongoDb}";
    }
}
