using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;

public class PricingContext : DbContext
{

    private string _connectionstring;

    public PricingContext(string connectionstring)
    {
        _connectionstring = connectionstring;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_connectionstring);
    }
    
    /*
    public PricingContext(DbContextOptions<PricingContext> options)
        :base(options) {}

    */
    
    public DbSet<Student> ?Students { get; set; }

    //public DbSet<Item>? PricingItems { get; set; }
}