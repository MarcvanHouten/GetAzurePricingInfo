using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSite.Models
{
    public class ViewModel
    {
        public IEnumerable<PricingItem> Pricingskus { get; set; }
        public SelectionModel selection { get; set; }

        public IEnumerable<SelectListItem> ListofCurrency { get; set; }

        public string SelectedCurrency { get; set; }

    }
}
