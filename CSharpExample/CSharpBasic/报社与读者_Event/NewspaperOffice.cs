using System;

namespace 报社与读者_Event
{
    public class NewspaperOffice
    {
        public event Action<string> OnNewspaperPrint;

        public void PrintNewspaper(string content)
        {
            if (OnNewspaperPrint != null)
            {
                OnNewspaperPrint(content);
            }
        }

        public string Name { get; set; }

        public NewspaperOffice(string name)
        {
            Name = name;
        }
    }
}