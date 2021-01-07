using GenericsDemo.Models;
using GenericsDemo.WithoutGenerics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> ages = new List<int>();
            //ages.Add(23);

            Console.ReadLine();

            DemonstrateTextFileStorage();

            Console.WriteLine("Press enter to shut down...");
            Console.ReadLine();
        }

        private static void DemonstrateTextFileStorage()
        {
            List<PersonModel> people = new List<PersonModel>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"C:\Temp\people.csv";
            string logFile = @"C:\Temp\logs.csv";

            PopulateLists(people, logs);

            /*New way of doing things - With Generics*/



            /*Old way of doing things - Without Generics*/
            //OriginalTextFileProcessor.SavePeople(people, peopleFile);

            //var newPerson = OriginalTextFileProcessor.LoadPeople(peopleFile);

            //foreach (var p in newPerson)
            //{
            //    Console.WriteLine($"{ p.FirstName } { p.LastName } (IsAlive = { p.IsAlive })");
            //}

            //OriginalTextFileProcessor.SaveLogs(logs, logFile);

            //var newLog = OriginalTextFileProcessor.LoadLogs(logFile);

            //foreach (var log in newLog)
            //{
            //    Console.WriteLine($"{ log.ErrorCode }: { log.Message } at { log.TimeOfEvent.ToShortTimeString() }");
            //}
        }

        private static void PopulateLists(List<PersonModel> people, List<LogEntry> logs)
        {
            people.Add(new PersonModel { FirstName = "Alistair", LastName = "Devine" });
            people.Add(new PersonModel { FirstName = "Testing", LastName = "Environment", IsAlive = false });
            people.Add(new PersonModel { FirstName = "Devine", LastName = "Ali" });

            logs.Add(new LogEntry { Message = "I blew up", ErrorCode = 9999 });
            logs.Add(new LogEntry { Message = "I worked great", ErrorCode = 1337 });
            logs.Add(new LogEntry { Message = "Too tired", ErrorCode = 2222 });
        }
    }
}
