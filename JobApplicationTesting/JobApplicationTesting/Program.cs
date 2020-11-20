using JobApplicationTesting;
using System;
//To replace the string[] args, normally found in the static void Main()
Console.WriteLine(args);

Console.WriteLine("Hello world!");
Console.WriteLine(Add(2, 3));

PersonModel person1 = new() {Id = 1, FirstName = "Ali", LastName = "Devine" };
PersonModel person2 = new(2, "Alistair", "Devine");
PersonModel person3 = null;

Console.WriteLine($"Hello {person1.FirstName} {person1.LastName} ({person1.Id})");

if (person3 is null)
{
    Console.WriteLine("The value for person three is not set.");
}
else
{
    Console.WriteLine($"Hello {person3.FirstName} {person3.LastName} ({person3.Id})");
}

if (person2 is not null)
{
    Console.WriteLine($"Hello {person2.FirstName} {person2.LastName} ({person2.Id})");
}

//Don't do this!
person3 = new();

static double Add(int x, int y)
{
    return x + y;
}
