namespace 商场管理软件
{
    internal class CashContext
    {
        private CashSuper cs;

        public void setBehavior(CashSuper csuper)
        {
            this.cs = csuper;
        }

        public double GetResult(double money)
        {
            return cs.acceptCash(money);
        }
    }
}