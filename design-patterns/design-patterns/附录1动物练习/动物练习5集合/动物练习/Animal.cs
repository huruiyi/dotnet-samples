namespace 动物练习
{
    internal abstract class Animal
    {
        private string name = "";

        protected Animal(string name)
        {
            this.name = name;
        }

        public Animal()
        {
            this.name = "无名";
        }

        private int shoutNum = 3;

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

        public string Shout()
        {
            string result = "";
            for (int i = 0; i < shoutNum; i++)
                result += getShoutSound() + "，";

            return "我的名字叫" + name + " " + result;
        }

        protected abstract string getShoutSound();
    }
}