using System;
using System.ComponentModel;
using System.Net.Cache;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


[assembly: FunctionsStartup(typeof(DevFunction.Startup))]

namespace DevFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING");
            builder.Services.AddDbContext<DevContext>(
              options => options.UseSqlServer(connectionString));
        }
    }

    public class Function1
    {

        public readonly DevContext _MyContext;

        public Function1(DevContext context)
        {
            this._MyContext = context;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");


            Person p = new Person
            {
                Name = "Jack",
                Age = 44
            };


            log.LogInformation($"Id is: {p.PersonId}");

            //_MyContext.Persons.Attach(person);
            //_MyContext.Entry(person).State = EntityState.Added;
           
            _MyContext.Persons.Add(p); 
            _MyContext.SaveChanges();


        }
    }
}
