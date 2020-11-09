using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace John_Doe_Food_Ltd.Models
{
    public class Supplier
    {
        private ICollection<Supplier> _suppliers;

        public Supplier()
        {
            _suppliers = new List<Supplier>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }
        public string TelephoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Supplier> Suppliers
        {
            get { return _suppliers; }
            set { _suppliers = value; }
        }
    }
}