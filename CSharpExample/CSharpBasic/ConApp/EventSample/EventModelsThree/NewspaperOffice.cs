using System;

namespace ConApp.EventSample.EventModelsThree
{
    public class NewspaperOffice
    {
        public event EventHandler<NewspaperEventArgs> OnNewspaperPrint;

        public void PrintNewspaper(string content)
        {
            if (OnNewspaperPrint != null)
            {
                OnNewspaperPrint(this, new NewspaperEventArgs(content));
            }
        }

        public string Name { get; set; }

        public NewspaperOffice(string name)
        {
            Name = name;
        }
    }
}