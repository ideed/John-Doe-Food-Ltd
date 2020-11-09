using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace John_Doe_Food_Ltd.Models
{
    public class Catalouge
    {
        private ICollection<Catalouge> _catalouges;

        public Catalouge()
        {
            _catalouges = new List<Catalouge>();
        }        
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public string Acess { get; set; }

        public virtual ICollection<Catalouge> Catalouges
        {
            get { return _catalouges; }
            set { _catalouges = value; }
        }
    }
}