﻿using System;
using System.IO;
using System.Text.Json;
using HelloWorldWeb.Models;
using HelloWorldWeb.Services;

namespace LanguageFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            ITimeService timeService = new TimeService();
            Member member = new Member("Member1", 5, timeService);
            string jsonString = JsonSerializer.Serialize(member);
            Console.WriteLine(jsonString);
            string file = "MemberFile.json";
            File.WriteAllText(file, jsonString);
            var readedMember = File.ReadAllTextAsync(file);
            readedMember.Wait();
            var outputMember = readedMember.Result;

            Member memberDeserealized = JsonSerializer.Deserialize<Member>(outputMember);
            Console.WriteLine(memberDeserealized.ToString());

            Console.Write("Insert your coffee:");
            var type = Console.ReadLine();

            Coffe coffe = MakeCoffe("grain", "milk", "water", "sugar", (type == "FlatWhite") ? (FlatWhite) : (Espresso));
            Console.WriteLine($"Here is your coffee:{coffe}.");
        }


        static Coffe MakeCoffe(string grains, string milk, string water, string sugar, Func<string, string, string, string, Coffe> recipe)
        {
            try
            {
                Console.WriteLine("Start preparing coffee.");
                var coffe = recipe(grains, milk, water, sugar);
                return coffe;
            }
            catch
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        static Coffe Espresso(string grains, string milk, string water, string sugar)
        {

            return new Coffe("Espresso");
        }

        static Coffe FlatWhite(string grains, string milk, string water, string sugar)
        {

            return new Coffe("FlatWhite");
        }
    }
}
