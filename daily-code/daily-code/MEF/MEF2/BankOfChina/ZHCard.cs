using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Threading.Tasks;

namespace BankOfChina
{
    [Export(typeof(ICard))]
    public class ZHCard : ICard
    {
        public string GetCountInfo()
        {
            return "Bank Of China";
        }

        public void SaveMoney(double money)
        {
            this.Money += money;
        }

        public void CheckOutMoney(double money)
        {
            this.Money -= money;
        }

        public double Money { get; set; }
    }
}
