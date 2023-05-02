using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DIandMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var s = RemoveInvalidFilenameChars("invali$ddd");

            CreateHostBuilder(args).Build().Run();
        }

        public static string RemoveInvalidFilenameChars(string filename)
        {
            return Regex.Replace(filename, "[:/\\\\?&#*|<>\"\\[\\]]+", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
