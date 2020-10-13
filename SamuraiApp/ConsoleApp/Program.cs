using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            //context.Database.EnsureCreated();
            //GetSamurais("Before Add:");
            //AddMultipleSamurais();
            //AddMultiptleTypes();
            //AddSamurai();
            //GetSamurais("After Add:");
            
            //context.Database.EnsureDeleted();
            Console.WriteLine("Press Any key...");
            Console.ReadKey();
        }



        private static void AddMultiptleTypes()
        {
            var sam1 = new Samurai(){Name = "New1"};
            var clan = new Clan() {ClanName = "New Clan"};

            context.AddRange(sam1, clan);

            context.SaveChanges();
        }

        private static void AddMultipleSamurais()
        {
            var sam1 = new Samurai() {Name = "New1"};
            var sam2 = new Samurai() {Name = "New2"};
            var sam3 = new Samurai() {Name = "New3"};
            var sam4 = new Samurai() {Name = "New4"};

            context.Samurais.AddRange(sam1, sam2);

            context.SaveChanges();
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

        //private static void GetSamurais2()
        //{
        //    var samurais = context.Samurais.Where(s=>EF.).ToList();
        //}

        private static void QueryAndUpdateBattle_Disconnecte()
        {
            var battle = context.Battles.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(1560, 06, 30);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }

    }
}
