using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDesktopUI.Models
{
    public class CartItemDisplayModel :INotifyPropertyChanged

    {
        public ProductDisplayModel Product { get; set; }
        private int _quantityInCart;

        public int QuantityInCart
        {
            get { return _quantityInCart; }
            set
            {
                _quantityInCart = value;
                CallPropertyChanged(nameof(QuantityInCart));

                CallPropertyChanged(nameof(DisplayText));
            }
        }


        public string DisplayText
        {
            get
            {
                if (QuantityInCart == 1)
                {
                    return $"{Product.ProductName}";
                }
                else
                {
                    return $"{Product.ProductName} ({QuantityInCart})";
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void CallPropertyChanged(string propertyName)
        {
            //This (and above event) are .net, not caliburn micro, so they can be used w/o needing caliburn micro
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
