using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
