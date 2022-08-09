using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DevFunction
{ 
   public class Person2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        
    }
}

/*

CREATE TABLE [dbo].[Persons]
(
[Id] [varchar](MAX) NOT NULL PRIMARY KEY,
[Name] [varchar](150) NOT NULL,
[Age] [int] NOT NULL
)
GO

 */