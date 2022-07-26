using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GetAzurePricingInfo
{
    public class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            //Establish connection to SQL Database storage
            string sqlConnectionString = Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING");
           



            //Create a HTTP request to get the HTTP sizes
            string baseurl = "https://prices.azure.com/api/retail/prices?";
            string selection = "&$filter=serviceName eq \'Virtual Machines\' and armRegionName eq \'westeurope\'";

            log.LogInformation(baseurl+selection);

            HttpClient client = new HttpClient();
            bool ReceivedAllResults = false;

            do
            {   
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseurl + selection);
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
                    
                    
                    if (p.Count < 100)
                    {
                        ReceivedAllResults = true;
                    }
                    else
                    {
                        string url = p.NextPageLink.ToString();
                    }
                }
                

            } while (!ReceivedAllResults);

            
            /*
            var request = new HttpRequestMessage(HttpMethod.Get, baseurl + selection);

            

            

            if (response.StatusCode.ToString() == "OK")
            {
                
                         foreach (Item i in p.Items)
                {
                    log.LogInformation("Name {0}", i.armSkuName);
                }
                log.LogInformation($"Number of items {p.Count} ");

            }
            else
            {
                log.LogInformation("Request is failing: " + response.StatusCode);
            }
            
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            */


        }
    }
}
