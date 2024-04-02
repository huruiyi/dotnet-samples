using System.Collections.Generic;

namespace WebAppSearch.Models
{
    public class personList
    {
        public personList()
        {
            this.list = new List<person>();
        }
        public int hits { get; set; }
        public int took { get; set; }
        public List<person> list { get; set; }
    }
}