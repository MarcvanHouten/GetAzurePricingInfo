// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Data.Common;

/*
using (var db = new PricingContext())
{
    
    Student std = new Student
    {
        Name = "Johant"
    };


    db.Students.Add(std);
    db.SaveChanges();

}
*/




var db = new AzurePricingContext()

db.SaveChanges();




// Write the values to the console.

//Console.WriteLine(conn);
/*

var secret = builder.Configuration["ConnectionStrings.MyDatabaseConnection"];


string conn = Environment.GetEnvironmentVariable("SQLCONN2", EnvironmentVariableTarget.Machine);


IConfigurationRoot configuration = builder.Build();

//string conn = configuration["ConnectionStrings.MyDatabaseConnection"];

//string conn = configuration.GetConnectionString("MyDatabaseConnection");
string conn = Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING");

//Console.WriteLine($"Connectionstring is {0}", conn);

Console.WriteLine(conn);

string conn2 = Environment.GetEnvironmentVariable("LOGONSERVER");

Console.WriteLine(conn2);

//string conn = configuration.GetConnectionString(“MyDatabaseConnection”);




/*

IConfigurationBuilder builder = new ConfigurationBuilder()
IConfigurationRoot configuration = builder.Build();

var c = configuration.GetSection("ConnectionStrings")

Console.WriteLine($"Connectionstring is {0}", c.MyDatabaseConnection);
*/

/*

ConfigurationManager configurationManager = new();
configurationManager.AddJsonFile("appsettings.json", true, reloadOnChange: true);
string serviceName = configurationManager["ServiceName"];
Console.WriteLine(serviceName);


var configuration = new ConfigurationBuilder().Sources()

     .SetBasePath(Directory.GetCurrentDirectory())
     .AddJsonFile($"appsettings.json");
*/

//var connectionString = config.GetConnectionString("ConnectionStrings.MyDatabaseConnection");


