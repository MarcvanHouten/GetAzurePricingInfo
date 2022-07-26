using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



public class PricingContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"")

    public DbSet<Item>? PricingItems { get; set; }
}