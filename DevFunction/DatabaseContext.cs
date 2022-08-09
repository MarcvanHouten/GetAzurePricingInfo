using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DevFunction
{
    public class DevContext : DbContext
    {

        public DevContext(DbContextOptions<DevContext> options)
            :base(options) {}

        public DbSet<Person> Persons { get; set; }
    }


    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


    }
}


