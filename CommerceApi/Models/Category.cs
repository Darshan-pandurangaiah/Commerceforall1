using System;
using System.Collections.Generic;

#nullable disable

namespace CommerceApi.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Productname { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
