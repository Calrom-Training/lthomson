// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Training.API.Core.Init
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    ///   Program class.
    /// </summary>
    public class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>Creates the host builder.</summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///   A host builder.
        /// </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
