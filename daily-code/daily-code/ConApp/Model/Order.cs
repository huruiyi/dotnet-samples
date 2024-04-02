using System;

namespace ConApp.Model
{
    public class Order
    {
        public DateTime TheDate { get; set; }
        public string Customer { get; set; }
        public decimal Amount { get; set; }
        public bool Discount { get; set; }
    }
}
