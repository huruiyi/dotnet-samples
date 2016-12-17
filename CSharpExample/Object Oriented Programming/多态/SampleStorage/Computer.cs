namespace 多态.SampleStorage
{
    public class Computer
    {
        private MobileStorage storage;

        public MobileStorage Storage
        {
            get { return storage; }
            set { storage = value; }
        }

        public Computer()
        {
        }

        public Computer(MobileStorage s)
        {
            this.storage = s;
        }

        public void cRead()
        {
            storage.Read();
        }

        public void cWrite()
        {
            storage.Write();
        }
    }
}