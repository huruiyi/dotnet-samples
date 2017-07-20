using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSDemo.Model
{
    public class City
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }

        public string District { get; set; }

        public long Population { get; set; }
    }
}