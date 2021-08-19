using System;
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
            
        }
    }
}
