using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp.Class
{
    public class Publisher
    {
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        public event SampleEventHandler SampleEvent;

        protected virtual void RaiseSampleEvent()
        {
            if (SampleEvent != null)
                SampleEvent(this, new SampleEventArgs("Hello"));
        }
    }
}