// <copyright file="IMessagingService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.IServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Training.API.DatabaseLibrary.Models;

    /// <summary>
    ///  Messaging service interface.
    /// </summary>
    public interface IMessagingService
    {
        /// <summary>Gets the messages.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///  A list of messages for the user.
        /// </returns>
        Task<List<Message>> GetMessages(string username);
    }
}
