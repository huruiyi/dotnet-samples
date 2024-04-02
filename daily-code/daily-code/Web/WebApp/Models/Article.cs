using System;

namespace WebApp.Models
{
    public class Article
    {
        public string Id { get; set; }

        public string ClassId { get; set; }

        public string ClassName { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Score { get; set; }

        public DateTime CreateTime { get; set; }
    }
}