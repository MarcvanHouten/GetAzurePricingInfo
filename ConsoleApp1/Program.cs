// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;


using (var db = new PricingContext())
{
    db.PricingItems
    db.PricingItems.Add(new Item { currencyCode = "EUR" });
    db.SaveChanges();

}

Console.WriteLine("Hello, World!");
