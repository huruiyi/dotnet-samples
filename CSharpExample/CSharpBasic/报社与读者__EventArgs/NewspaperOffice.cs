using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 报社与读者__EventArgs
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