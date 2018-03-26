using System;

namespace ConApp.EventSample.EventModelsTwo
{
    public class NewspaperOffice
    {
        public event Action<string> OnNewspaperPrint;

        public void PrintNewspaper(string content)
        {
            //OnNewspaperPrint?.Invoke(content);
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