using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现接口属性
{
    class Student : ISpewak
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        private string _Sex;
        public string Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }
    }
}
