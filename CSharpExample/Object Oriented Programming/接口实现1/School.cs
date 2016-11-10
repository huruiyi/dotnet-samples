namespace 接口实现1
{
    public class School : Introduceable
    {
        public string Name { get; set; }

        public School(string name)
        {
            Name = name;
        }

        private PrinterFace printer;

        public void SetPrinter(PrinterFace p)
        {
            printer = p;
        }

        public string detail()
        {
            return string.Format("这里是{0}校区", Name);
        }

        public void print(Introduceable intro)
        {
            printer.print(intro.detail());
        }
    }
}