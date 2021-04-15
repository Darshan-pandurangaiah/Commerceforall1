using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccessLayer.Models
{
    public partial class Orderdetail
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public int Userid { get; set; }
        public int? Quantity { get; set; }
        public string Gpslocation { get; set; }
        public string Verification { get; set; }
        public string Quotation { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
