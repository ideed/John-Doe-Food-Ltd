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
        
        [Key]
        public int OrderId { get; set; }

        public DateTime DateOrdered { get; set; }        

        public int CatId { get; set; }
        public int CusId { get; set; }
    }
}