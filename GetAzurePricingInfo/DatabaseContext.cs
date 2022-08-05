using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace GetAzurePricingInfo
{
    public class AzurePricingContext : DbContext
    {

        private string _connectionstring = "";

        public AzurePricingContext(DbContextOptions options)
        {

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

        public DbSet<Item>? PricingItems { get; set; }
    }
}