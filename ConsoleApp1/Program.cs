// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

string sqlconnectionstring = "Server=tcp:sql-server-26867153.database.windows.net,1433;Initial Catalog=azurepricingdb26867153;Persist Security Info=False;User ID=azureuser;Password=Pa9w0rD-26867153;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

using (var db = new PricingContext())
{
    db.PricingItems.Add(new Item { currencyCode = "EUR" });
    db.SaveChanges();

}

Console.WriteLine("Hello, World!");
