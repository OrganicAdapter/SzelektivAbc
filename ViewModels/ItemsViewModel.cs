using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SzelektivABC.Models;

namespace SzelektivABC.ViewModels
{
    public class ItemsViewModel
    {
        public Item Item { get; set; }
        public IEnumerable<SelectListItem> AllPictograms { get; set; }

        private List<int> _selectedPictograms;
        public List<int> SelectedPictograms
        {
            get 
            {
                if (_selectedPictograms == null)
                    _selectedPictograms = Item.Pictograms.Select((x) => x.Id).ToList();

                return _selectedPictograms; 
            }
            set { _selectedPictograms = value; }
        }
    }
}