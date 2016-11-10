using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现接口事件
{
    public class Subscriber2
    {

        public Subscriber2(Shape shape)
        {
            IShape d = (IShape)shape;
            d.OnDraw += new EventHandler(d_OnDraw);
        }

        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Sub2 receives the IShape event.");
        }

    }
}
