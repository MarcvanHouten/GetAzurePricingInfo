using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSite.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.ResponseCaching;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public async Task<IActionResult> Index()
        {
            string baseurl = "https://prices.azure.com/api/retail/prices?";
            string selection = "&$filter=serviceName eq \'Virtual Machines\' and armRegionName eq \'westeurope\'";
            string url = baseurl + selection;

            HttpClient client = new HttpClient();
          
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await client.SendAsync(request);
             
            var content = await response.Content.ReadAsStringAsync();


            if (response.StatusCode.ToString() == "OK")
            {
                PricingModel pricing = new PricingModel();
                pricing = JsonConvert.DeserializeObject<PricingModel>(content);
                
                ViewModel model = new ViewModel();
                model.Pricingskus = pricing.Items;
                
                return View(model);
            }

            return View();
        }

        public IActionResult Select()
        {
                     
            return View("Selection", Request.RouteValues["id"].ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}