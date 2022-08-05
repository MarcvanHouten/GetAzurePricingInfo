using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;

public class AzurePricingContext : DbContext
{

    private string _connectionstring = "";

    public AzurePricingContext(DbContextOptions options)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("C:\\Users\\mavanhou\\source\\repos\\GetAzurePricingInfo\\ConsoleApp1\\appsettings.json", false, true);
        IConfigurationRoot configuration = builder.Build();
        string _connectionstring = configuration.GetConnectionString("MyDatabaseConnection");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("..");
    }
    
    /*
    public PricingContext(DbContextOptions<PricingContext> options)
        :base(options) {}

    */
    
    //public DbSet<Student> ?Students { get; set; }

    public DbSet<Item> ?PricingItems { get; set; }
}