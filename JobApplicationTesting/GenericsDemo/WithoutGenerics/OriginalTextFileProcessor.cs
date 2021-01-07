using GenericsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsDemo.WithoutGenerics
{
    public static class OriginalTextFileProcessor
    {
        public static List<PersonModel> LoadPeople(string filePath)
        {
            List<PersonModel> output = new List<PersonModel>();
            PersonModel p;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            //Remove the header row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                p = new PersonModel();

                p.FirstName = vals[0];
                p.IsAlive = bool.Parse(vals[1]);
                p.LastName = vals[2];

                output.Add(p);
            }
            return output;
        }

        public static List<LogEntry> LoadLogs(string filePath)
        {
            List<LogEntry> output = new List<LogEntry>();
            LogEntry l;
            var lines = System.IO.File.ReadAllLines(filePath).ToList();

            //Remove the header row
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var vals = line.Split(',');
                l = new LogEntry();

                l.ErrorCode = int.Parse(vals[0]);
                l.Message = vals[1];
                l.TimeOfEvent = DateTime.Parse(vals[2]);

                output.Add(l);
            }
            return output;
        }

        public static void SavePeople(List<PersonModel> people, string filePath)
        {
            List<string> lines = new List<string>();

            //Add header row
            lines.Add("FirstName,IsAlive,LastName");

            foreach (var p in people)
            {
                lines.Add($"{p.FirstName},{p.IsAlive},{p.LastName}");
            }
            System.IO.File.WriteAllLines(filePath, lines);
        }

        public static void SaveLogs(List<LogEntry> logs, string filePath)
        {
            List<string> lines = new List<string>();

            //Add header row
            lines.Add("ErrorCode,Message,TimeOfEvent");

            foreach (var log in logs)
            {
                lines.Add($"{log.ErrorCode},{log.Message},{log.TimeOfEvent}");
            }
            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
