using GMUzbekistan.Enums;
using System;

namespace GMUzbekistan.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string ClientName { get; set; }

        public long Amount { get; set; }

        public string CarName { get; set; }

        public OrderPurchaseStatus PurchaseStatus { get; set; }

        public DateTime Date { get; set; }

    }
}
