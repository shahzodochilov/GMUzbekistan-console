using GMUzbekistan.Enums;
using System;

namespace GMUzbekistan.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int CarId { get; set; }

        public OrderPurchaseStatus PurchaseStatus { get; set; }

        public DateTime Date { get; set; }
    }
}
