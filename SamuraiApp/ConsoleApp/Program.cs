using System;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace ConsoleApp
{
    class Program
    {
        private static SamuraiContext context = new SamuraiContext(); 

        static void Main(string[] args)
        {
            //This is not good practice to use this to create database
            //It is just for testing purposes
            context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            context.Database.EnsureDeleted();
            Console.WriteLine("Press Any key...");
            Console.ReadKey();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai {Name = "Komoda San"};
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
    }
}
