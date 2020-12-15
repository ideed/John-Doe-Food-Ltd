using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace John_Doe_Food_Ltd.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> AllCustomers { get; set; }
        private List<int> _selectedCustomers;
        public IEnumerable<SelectListItem> AllCatalouges { get; set; }
        private List<int> _selectedCatalouges;

        public List<int> SelectedCustomers
        {
            get
            {
                if(_selectedCustomers==null)
                {
                    _selectedCustomers = new List<int>();
                    if(Order.Customer != null)
                    {
                        _selectedCustomers = Order.Customer.Select(c => c.CustomerId).ToList();
                    }
                }
                return _selectedCustomers;
            }
            set
            {
                _selectedCustomers = value;
            }
        }
        public List<int> SelectedCatalouges
        {
            get
            {
                if(_selectedCatalouges==null)
                {
                    _selectedCatalouges = new List<int>();
                    if (Order.Product != null)
                    {
                        _selectedCatalouges = Order.Product.Select(p => p.FoodId).ToList();
                    }
                }
                return _selectedCatalouges;
            }
            set
            {
                _selectedCatalouges = value;
            }
        }
    }
}