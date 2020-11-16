using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace John_Doe_Food_Ltd.Models
{
    public class Catalouge
    {
        
        private ICollection<Customer> _customers;
        
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public Boolean CommericalGood { get; set; }        
        
        //One-to-Many
        public virtual List<Customer>Customers
        {
            get { return _customers.ToList(); }
            set { _customers = value; }
        }
        //Many-to-Many
        public List<Supplier> Suppliers { get; set; }
        public Catalouge()
        {
            this.Suppliers = new List<Supplier>();
        }
    }
}