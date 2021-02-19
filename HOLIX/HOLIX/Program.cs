using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HOLIX
{
    /// <summary>
    /// Program startup class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Startup main method.
        /// </summary>
        /// <param name="args">Firt input arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Host builder method.
        /// </summary>
        /// <param name="args">Program args.</param>
        /// <returns>Host builder instance.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
