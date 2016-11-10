using System;

namespace 报社与读者__EventArgs
{
    public class NewspaperReader
    {
        public void SubscribeNewspaper(NewspaperOffice office)
        {
            office.OnNewspaperPrint += Read;
            Console.WriteLine("{0}订阅了{1}报纸", Name, office.Name);
        }

        public void UnSubscribeNewspaper(NewspaperOffice office)
        {
            office.OnNewspaperPrint -= Read;
            Console.WriteLine("{0},退订了{1}报纸", Name, office.Name);
        }

        public void Read(object sender, NewspaperEventArgs e)
        {
            var office = sender as NewspaperOffice;
            if (office != null)
                Console.WriteLine("{0}正在读{1},报纸内容为：{2}", Name, office.Name, e.Content);
        }

        public string Name { get; set; }

        public NewspaperReader(string name)
        {
            Name = name;
        }
    }
}