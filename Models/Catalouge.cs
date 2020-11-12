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
        private ICollection<Catalouge> _catalouges;

        //public Catalouge()
        //{
        //    _catalouges = new List<Catalouge>();
        //}
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public string Acess { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set;} 
        //public virtual ICollection<Catalouge> Catalouges
        //{
        //    get { return _catalouges; }
        //    set { _catalouges = value; }
        //}
    }
}