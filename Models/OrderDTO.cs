using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace John_Doe_Food_Ltd.Models
{
    public class OrderDTO
    {

        public int OrderId { get; set; }

        public DateTime DateOrdered { get; set; }

        public virtual ICollection<CatalougeDTO> Product { get; set; }
        public virtual ICollection<CustomerDTO> Customer { get; set; }
    }
}