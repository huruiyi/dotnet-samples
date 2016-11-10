using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class SampleEventArgs
    {
        public SampleEventArgs(string s)
        {
            Text = s;
        }

        public string Text
        {
            get;
            private set;
        }
    }
}