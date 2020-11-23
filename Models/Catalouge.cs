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
        
        [Key]
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
        public Boolean CommericalGood { get; set; }        
                 
        public virtual ICollection<Order> Orders { get; set; }  
    }
}