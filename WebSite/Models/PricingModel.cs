using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class PricingModel
    {
        public string BillingCurrency { get; set; }
        public string CustomerEntityId { get; set; }
        public string CustomerEntityType { get; set; }
        public List<PricingItem> Items { get; set; }
        public object NextPageLink { get; set; }
        public int Count { get; set; }
    }

    public class PricingItem
    {
        public int Id { get; set; }
        public string currencyCode { get; set; }
        public float tierMinimumUnits { get; set; }
        public float retailPrice { get; set; }
        public float unitPrice { get; set; }
        public string armRegionName { get; set; }
        public string location { get; set; }
        public DateTime effectiveStartDate { get; set; }
        public string meterId { get; set; }
        public string meterName { get; set; }
        public string productId { get; set; }
        public string skuId { get; set; }
        public string productName { get; set; }
        public string skuName { get; set; }
        public string serviceName { get; set; }
        public string serviceId { get; set; }
        public string serviceFamily { get; set; }
        public string unitOfMeasure { get; set; }
        public string type { get; set; }
        public bool isPrimaryMeterRegion { get; set; }
        public string armSkuName { get; set; }
        public string reservationTerm { get; set; }
    }

}
