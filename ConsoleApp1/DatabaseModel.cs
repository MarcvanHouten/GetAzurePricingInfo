using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



public class PricingContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:sql-server-26867153.database.windows.net, 1433; Initial Catalog=azurepricingdb26867153; Persist Security Info=False; User ID=azureuser; Password=Pa9w0rD-26867153; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;");
    }
  
    public DbSet<Item>? PricingItems { get; set; }
}
