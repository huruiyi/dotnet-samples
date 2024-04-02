using System;

namespace _006_019_LINQ___Projection_Operators
{
    public class Order
    {
        public Order(int orderID, DateTime orderDate, decimal total)
        {
            OrderID = orderID;
            OrderDate = orderDate;
            Total = total;
        }

        public Order()
        {
        }

        public int OrderID;
        public DateTime OrderDate;
        public decimal Total;
    }
}