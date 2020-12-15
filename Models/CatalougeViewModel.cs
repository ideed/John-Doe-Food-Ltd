using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace John_Doe_Food_Ltd.Models
{
    public class CatalougeViewModel
    {
        public Catalouge Catalouge { get; set; }
        public IEnumerable<SelectListItem> AllSuppliers { get; set; }
        private List<int> _selectedSuppliers;
        public List<int> SelectedSuppliers
        {
            get
            {
                if(_selectedSuppliers == null)
                {
                    _selectedSuppliers = new List<int>();
                    if(Catalouge.Supplier != null)
                    {
                        _selectedSuppliers = Catalouge.Supplier.Select(s => s.SupplierId).ToList();
                    }
                }
                return _selectedSuppliers;
            }
            set
            {

            }
        }
    }
}