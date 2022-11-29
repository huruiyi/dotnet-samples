using System;

namespace WebApp.Models
{
    public class OrderInfo
    {
        public string OrderId { get; set; }

        public string SerialNumber { get; set; }

        public string ShortNumber { get; set; }

        public string ProductId { get; set; }

        public decimal SalePrice { get; set; }

        public string BookingDate { get; set; }
    }
}