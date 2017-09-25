using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MetaServerServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        Console.BackgroundColor = ConsoleColor.Blue;
	        Console.Title = "AWS Metadata Server";
            BuildWebHost(args).Run();
        }

	    public static IWebHost BuildWebHost(string[] args) =>
		    WebHost.CreateDefaultBuilder(args)
			    .UseUrls("http://169.254.169.254:80/")
			    .UseStartup<Startup>()
			    .UseKestrel()
			    .Build();
    }
}
