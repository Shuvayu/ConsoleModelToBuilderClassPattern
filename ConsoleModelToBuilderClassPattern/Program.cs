using ConsoleModelToBuilderClassPattern.Models;
using ConsoleModelToBuilderClassPattern.Repositories;
using ConsoleModelToBuilderClassPattern.Service;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleModelToBuilderClassPattern
{
    internal class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        private static void Main()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var appSettings = new AppSettings();
            Configuration.GetSection("Settings").Bind(appSettings);

            TextFileRepository.OutputToTxtFile(TemplateService.PopulateClassTemplate<Test>());

            Console.WriteLine("Text File Generated !!!");

            Console.ReadKey();
        }
    }
}