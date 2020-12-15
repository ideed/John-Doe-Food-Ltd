using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace John_Doe_Food_Ltd.Models
{
    public class Order
    {
        private ICollection<Catalouge> _Product;
        private ICollection<Customer> _Customer;
        public Order()
        {
            _Customer = new List<Customer>();
            _Product = new List<Catalouge>();
        }
        [Key]
        public int OrderId { get; set; }

        public DateTime DateOrdered { get; set; }

        public virtual ICollection<Catalouge> Product 
        {
            get { return _Product; }
            set { _Product = value; } 
        }
        public virtual ICollection<Customer> Customer 
        {
            get { return _Customer; }
            set { _Customer = value; }         
        }
    }
}