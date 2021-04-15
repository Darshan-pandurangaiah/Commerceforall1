using System;
using DataAccessLayer.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class EFCore_DataAccessLayer
    {
        CommerceforallContext DbContext;

        public EFCore_DataAccessLayer()
        {
            DbContext = new CommerceforallContext();
        }
        public List<Product> GetProducts()
        {
            var productsList = (from products
                               in DbContext.Products
                                select products).ToList();

            return productsList;
        }
        public string GetProduct(string productname)
        {
            var productsList = (from Products
                               in DbContext.Products
                                where (Products.Productname == productname)
                                select Products.Productid).First();

            return productsList.ToString();
        }
        public Boolean ValidateUser(User userinput)
        {
            var User = (from Users
                               in DbContext.Users
                        where (Users.Name == userinput.Name && Users.Password == userinput.Password)
                        select Users).ToList();
            if (User.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
        public Boolean InsertUser(User userinput)
        {
            
            DbContext.Users.Add(userinput);            
            DbContext.SaveChanges();
            return true;

        }
    }
}

