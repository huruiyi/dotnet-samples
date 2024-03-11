using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;
using System.Threading.Tasks;

namespace NongHang
{
    [Export(typeof(ICard))]
    public class NHCard : ICard
    {
        public string GetCountInfo()
        {
            return "Nong Ye Yin Hang";
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
