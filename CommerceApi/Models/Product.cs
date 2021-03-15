using System;
using System.Collections.Generic;

#nullable disable

namespace CommerceApi.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Productid { get; set; }
        public string Productname { get; set; }
        public int Categoryid { get; set; }
        public int? Quantity { get; set; }
        public int Price { get; set; }
        public string Verification { get; set; }
        public string Gpslocation { get; set; }
        public string Userid { get; set; }
        public string Available { get; set; }
        public DateTime? Whichdate { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
