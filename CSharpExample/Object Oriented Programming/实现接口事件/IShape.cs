using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现接口事件
{
    public interface IShape
    {
        // Raise this event after drawing
        // the shape.
        event EventHandler OnDraw;

    }
}
