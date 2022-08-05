using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(MyNamespace.Startup))]

namespace GetAzurePricingInfo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING");
            builder.Services.AddDbContext<AzurePricingContext>(
              options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
    public class AzurePricingFunction
    {
        private readonly AzurePricingContext dbContext;

        public AzurePricingFunction(AzurePricingContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [FunctionName("Function1")]
        public static async Task Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            //Establish connection to SQL Database storage
            string sqlConnectionString = Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING");


      
            //Create a HTTP request to get the HTTP sizes
            string baseurl = "https://prices.azure.com/api/retail/prices?";
            string selection = "&$filter=serviceName eq \'Virtual Machines\' and armRegionName eq \'westeurope\'";
            string url = baseurl + selection;

            log.LogInformation(url);

            HttpClient client = new HttpClient();
            bool ReceivedAllResults = false;

            do
            {   
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                HttpResponseMessage response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode.ToString() != "OK")
                {
                    log.LogInformation($"{DateTime.Now} Error connecting to pricing API. Statuscode: {response.StatusCode}");
                    break;
                }
                else
                {
                    PricingInformation p = new PricingInformation();
                    p = JsonConvert.DeserializeObject<PricingInformation>(content);
                   

                    //INSERT DATA TO DATABASE





                    log.LogInformation("Name {0}", p.Items[1].armSkuName);
                    log.LogInformation($"There are {p.Count} items.");
                    
                    if (p.Count < 100)
                    {
                        ReceivedAllResults = true;
                    }
                    else
                    {
                        url = p.NextPageLink.ToString();
                        log.LogInformation(url);
                    }
                }
                

            } while (!ReceivedAllResults);

            
      


        }
    }
}
