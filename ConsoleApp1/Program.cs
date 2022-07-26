// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

using (var db = new PricingContext())
{
    
    Student std = new Student
    {
        Name = "Johant"
    };


    db.Students.Add(std);
    db.SaveChanges();

}

Console.WriteLine("Hello, World!");
