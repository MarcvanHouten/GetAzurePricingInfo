using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace DevFunction
{
    public class DevContext : DbContext
    {

        public DevContext(DbContextOptions<DevContext> options)
            :base(options) {}

        public DbSet<Person> Personen { get; set; }
    }


    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


    }
}

/*

CREATE TABLE [dbo].[Personen]
(
[Id] [int] IDENTITY(1,1) PRIMARY KEY,
[Name] [varchar](150) NOT NULL,
[Age] [int] NOT NULL
)
GO

 */

