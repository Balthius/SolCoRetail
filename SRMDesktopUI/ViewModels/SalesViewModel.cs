using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;

        private string _itemQuantity;
        private BindingList<string> _cart;

        public BindingList<string> Products
        {
            get { return _products; }
            set 
            { 
                _products = value;

                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<string> Cart
        {
            get { return _cart; }
            set 
            {
                _cart = value;

                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            { 
                _itemQuantity = value;

                NotifyOfPropertyChange(() => Products);
            }
        }

        public string SubTotal
        {
            get
            {
                return "$0.00";
            }

        }
        public string Tax
        {
            get
            {
                return "$0.00";
            }

        }
        public string Total
        {
            get
            {
                return "$0.00";
            }

        }

        public void AddToCart()
        {

        }
        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                return output;
            }
        }
        public void RemoveFromCart()
        {

        }
        public bool CanRemoveFromCArt
        {
            get
            {
                bool output = false;

                return output;
            }
        }

        public void CheckOut()
        {

        }
        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                return output;
            }
        }

    }
}
