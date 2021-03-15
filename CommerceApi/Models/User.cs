using System;
using System.Collections.Generic;

#nullable disable

namespace CommerceApi.Models
{
    public partial class User
    {
        public User()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public int Roleid { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
