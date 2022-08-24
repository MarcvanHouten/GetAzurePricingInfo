using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSite.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient apiclient; 
        private List<SelectListItem> ListofCurrency;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            apiclient = new HttpClient();

            ListofCurrency = new List<SelectListItem>()
            {   new SelectListItem() { Text = "US Dollar ($)", Value = "USD"},
                new SelectListItem() { Text = "Euro (€)", Value = "EUR"},
                new SelectListItem() { Text = "British Pound (£)", Value = "GBP"}
            };
        }

        public async Task<PricingModel> GetPricingInformation(string Currency)
        {
            PricingModel model = new PricingModel();

            string baseurl = $"https://prices.azure.com/api/retail/prices?currencyCode={Currency}";
            string selection = "&$filter=serviceName eq \'Virtual Machines\' and armRegionName eq \'westeurope\'";
            string url = baseurl + selection;

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await apiclient.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();


            if (response.StatusCode.ToString() == "OK")
            {
                model = JsonConvert.DeserializeObject<PricingModel>(content);

            }

            return model;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PricingModel pricing = await GetPricingInformation("USD");

            ViewModel model = new ViewModel();
            model.Pricingskus = pricing.Items;

            //Create value for dropdownlist

            foreach (var item in ListofCurrency)
            {
                if (item.Value == "EUR")
                {
                    item.Selected = true;
                }
            }
            model.ListofCurrency = ListofCurrency;
                            
            return View(model);
          
        }

        [HttpPost]
        public async Task<IActionResult> Index(ViewModel m)
        {
            PricingModel pricing = await GetPricingInformation(m.SelectedCurrency);

            m.Pricingskus = pricing.Items;

            //Create value for dropdownlist

            foreach (var item in ListofCurrency)
            {
                if (item.Value == m.SelectedCurrency)
                {
                    item.Selected = true;
                }
            }
            
            m.ListofCurrency = ListofCurrency;

            return View(m);

        }

        [HttpPost]
        public IActionResult Select(ViewModel m)
        {

            return View("Selection", m.SelectedCurrency);
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