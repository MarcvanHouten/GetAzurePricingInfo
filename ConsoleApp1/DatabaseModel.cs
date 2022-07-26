using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



public class PricingContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"");
    }

 
    //public DbSet<Item>? PricingItems { get; set; }
}