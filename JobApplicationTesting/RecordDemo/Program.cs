using System;
using System.Collections.Generic;

/*
 * Benefits of Records:
 *  - Simple to set up
 *  - Thread-safe
 *  Easy/safe to share
 *  
 * When to use Records:
 *  - Capturing external data that doesn't change - Blazor WeatherService, SWAPI.dev
 *  - API calls
 *  - Processing data
 *  - Working with Read-only data
 *   
 * When not ot use Records:
 *  - When you need to change the data (Entity Framework)
 */

namespace RecordDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RecordOne r1a = new("Alistair", "Devine");
            RecordOne r1b = new("Alistair", "Devine");
            RecordOne r1c = new("Sue", "Storm");

            ClassOne c1a = new("Alistair", "Devine");
            ClassOne c1b = new("Alistair", "Devine");
            ClassOne c1c = new("Sue", "Storm");

            Console.WriteLine("Record Type: ");
            Console.WriteLine($"To String: { r1a }");
            Console.WriteLine($"Are the two objects equal: { Equals(r1a, r1b) }");
            Console.WriteLine($"Are the two objects reference equal: { ReferenceEquals(r1a, r1b) }");
            Console.WriteLine($"Are the two objects ==: { r1a == r1b }");
            Console.WriteLine($"Are the two objects !=: { r1a != r1c }");
            Console.WriteLine($"Hash code of object A: { r1a.GetHashCode() }");
            Console.WriteLine($"Hash code of object B: { r1b.GetHashCode() }");
            Console.WriteLine($"Hash code of object C: { r1c.GetHashCode() }");

            Console.WriteLine();
            Console.WriteLine("***********************************");
            Console.WriteLine();

            Console.WriteLine("Class Type: ");
            Console.WriteLine($"To String: { c1a }");
            Console.WriteLine($"Are the two objects equal: { Equals(c1a, c1b) }");
            Console.WriteLine($"Are the two objects reference equal: { ReferenceEquals(c1a, c1b) }");
            Console.WriteLine($"Are the two objects ==: { c1a == c1b }");
            Console.WriteLine($"Are the two objects !=: { c1a != c1c }");
            Console.WriteLine($"Hash code of object A: { c1a.GetHashCode() }");
            Console.WriteLine($"Hash code of object B: { c1b.GetHashCode() }");
            Console.WriteLine($"Hash code of object C: { c1c.GetHashCode() }");

            Console.WriteLine();

            var (fn, ln) = r1a;
            Console.WriteLine($"This value of fn is { fn } and the value of ln is { ln }");

            RecordOne r1d = r1a with
            {
                FirstName = "Ali"
            };
            Console.WriteLine($"Ali's record: { r1d }");

            Console.WriteLine();
            RecordTwo r2a = new("Ali", "Devine");
            Console.WriteLine($"r2a value: { r2a }");
            Console.WriteLine($"r2a fn: { r2a.FirstName } and ln: { r2a.LastName }");
            Console.WriteLine(r2a.SayHello());
        }

        //a Record is just a fancy class
        //Immutable - the values cannot be changed (readonly class)

        public record RecordOne(string FirstName, string LastName);
        //Inhertance with records
        public record UserOne(int userId, string FirstName, string LastName) : RecordOne(FirstName, LastName);

        public class DiscoveryModel
        {
            public UserOne LookupUser { get; set; }
            public int IncidentsFound { get; set; }
            public List<string> Incidents { get; set; }
        }

        public record RecordTwo(string FirstName, string LastName)
        {
            private string _firstName = FirstName;

            public string FirstName
            {
                get { return _firstName.Substring(0, 1); }
                init { }
            }

            //internal does not display FirstName property value
            //public string FirstName { get; init; } = FirstName;

            public string FullName { get => $"{ FirstName } { LastName }"; }

            public string SayHello()
            {
                return $"Hello { FirstName }";
            }
        }

        public class ClassOne
        {
            public string FirstName { get; init; }
            public string LastName { get; init; }

            public ClassOne(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
            //out variable, tupel.
            public void Deconstruct(out string FirstName, out string LastName)
            {
                FirstName = this.FirstName;
                LastName = this.LastName;
            }
        }

        //**************************
        //DO NOT DO ANY OF THE BELOW
        //**************************

        public record RecordThree   //No constructor so no deconstructor
        {
            public string FirstName { get; set; }   //The set makes this record mutable (Bad!)
            public string LastName { get; set; }    //The set makes this record mutable (Bad!)
        }

        //Don't just make clones all over to update state. 
        //Use a class when wanting to make multiple changes.
    }
}
