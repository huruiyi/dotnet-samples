namespace 动物练习
{
    internal class Animal
    {
        protected string name = "";

        public Animal(string name)
        {
            this.name = name;
        }

        public Animal()
        {
            this.name = "无名";
        }

        protected int shoutNum = 3;

        public int ShoutNum
        {
            get
            {
                return shoutNum;
            }
            set
            {
                shoutNum = value;
            }
        }

        public virtual string Shout()
        {
            return "";
        }
    }
}