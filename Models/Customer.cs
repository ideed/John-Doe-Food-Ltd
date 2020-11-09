using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace John_Doe_Food_Ltd.Models
{
    public class Customer
    {
        private ICollection<Customer> _customers;

        public Customer()
        {
            _customers = new List<Customer>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

    }
}