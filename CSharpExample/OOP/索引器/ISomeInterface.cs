using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 索引器
{
    public interface ISomeInterface
    {
        int this[int index]
        {
            get;
            set;
        }
    }
}
