using System;
using System.Collections.Generic;
using System.Text;

namespace BookStare.Domain.Models
{
    public class Book : Entity
    { 
        public string Name { get;set; }
        public string Authot { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryID { get; set; }
        public Category Categoty { get; set; }
    }
}
