using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace John_Doe_Food_Ltd.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //Many-to-Many
        public List<Catalouge> Supplies { get; set; }
        public Supplier()
        {
            this.Supplies = new List<Catalouge>();
        }
    }
}