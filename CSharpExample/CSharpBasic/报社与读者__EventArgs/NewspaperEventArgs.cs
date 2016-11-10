using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 报社与读者__EventArgs
{
    public class NewspaperEventArgs : EventArgs
    {
        public string Content { get; set; }

        public NewspaperEventArgs()
        {
        }

        public NewspaperEventArgs(string content)
        {
            Content = content;
        }
    }
}
