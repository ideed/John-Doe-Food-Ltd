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
        private ICollection<Supplier> _Supplier;
        public Catalouge()
        {
            _Supplier = new List<Supplier>();
        }
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public Boolean CommericalGood { get; set; }
        public virtual ICollection<Supplier> Supplier
        {
            get { return _Supplier; }
            set { _Supplier = value; }
        }

        //public int SupplierId { get; set; }
        //public virtual Supplier Supplier { get; set; }
    }
}