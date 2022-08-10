using System;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using Newtonsoft.Json.Linq;

[assembly: FunctionsStartup(typeof(GetAzurePricingInfo.Startup))]

namespace GetAzurePricingInfo
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING");
            builder.Services.AddDbContext<AzurePricingContext>(
              options => options.UseSqlServer(connectionString));
        }
    }
    public class AzurePricingFunction
    {
        public readonly AzurePricingContext _MyContext;

        public AzurePricingFunction(AzurePricingContext context)
        {
            this._MyContext = context;
        }


        [FunctionName("AzurePricingFunction")]
        public async Task Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer, ILogger log)
        {
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
                {   //Deserialize response
                    RootInformation root = new RootInformation();
                    root = JsonConvert.DeserializeObject<RootInformation>(content);
                  
                    await _MyContext.PricingItems.AddRangeAsync(root.Items);
                    await _MyContext.SaveChangesAsync();

                    log.LogInformation($"There are {root.Count} items.");

                    if (root.Count < 100)
                    {
                        ReceivedAllResults = true;
                    }
                    else
                    {
                        url = root.NextPageLink.ToString();
                        log.LogInformation(url);
                    }
                }


            } while (!ReceivedAllResults);

        }
    }
}

/*
ricingItem i = new PricingItem();

foreach (var item in p.Items)
{
i.currencyCode = item.currencyCode;
i.tierMinimumUnits = item.tierMinimumUnits;
i.retailPrice = item.retailPrice;
i.unitPrice = item.unitPrice;
i.armRegionName = item.armRegionName;
i.location = item.location;
i.effectiveStartDate = item.effectiveStartDate;
i.meterId = item.meterId;
i.meterName = item.meterName;
i.productId = item.productId;
i.skuId = item.skuId;
i.productName = item.productName;
i.skuName = item.skuName;
i.serviceName = item.serviceName;
i.serviceId = item.serviceId;
i.serviceFamily = item.serviceFamily;
i.unitOfMeasure = item.unitOfMeasure;
i.type = item.type;
i.isPrimaryMeterRegion = item.isPrimaryMeterRegion;
i.armSkuName = item.armSkuName;
i.reservationTerm = item.reservationTerm;

dbList.Add(i);
}

/*

/*
foreach (var item in p.Items)
{
    _MyContext.PricingItems.Add(item);
}
*/


//INSERT DATA TO DATABASE

/*
Item item = new Item();
{
item.armSkuName = "L43s_45";
item.meterId = "32423-343223-24";

};

await _MyContext.AddAsync(item);

*/


/*




PricingItem i = new PricingItem();
            {
                i.skuId = "skuId";
                i.currencyCode = "EUR";
                i.retailPrice = 5.4f;
                i.location = "westeurope";
                i.armRegionName = "WE";
                i.meterName = "MeterName";
                i.skuName = "D48s";
                i.Pricingtype = "PricingType";
                i.armSkuName = "armSkuName";
                i.reservationTerm = "reservationTerm";
            }
            
            await _MyContext.PricingItems.AddAsync(i);
            await _MyContext.SaveChangesAsync();


/*
                    List<PricingItem> items = new List<PricingItem>();

                    foreach (var item in root.Items)
                    {
                        if (item.type != "DevTestConsumption")
                        {
                            PricingItem i = new PricingItem();
                            {
                                i.skuId = item.skuId;
                                i.currencyCode = item.currencyCode;
                                i.retailPrice = item.retailPrice;
                                i.location = item.location;
                                i.armRegionName = item.armRegionName;
                                i.meterName = item.meterName;
                                i.skuName = item.skuName;
                                i.Pricingtype = item.type;
                                i.armSkuName = item.armSkuName;
                                i.reservationTerm = item.reservationTerm;
                            }
                            items.Add(i);
                        }
                    }
                    */


*/
