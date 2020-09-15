using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRMDataManager.Library.Models
{
    public class ProductModel
    {
        /// <summary>
        /// Unique Id for a given product
        /// </summary>
        public int Id { get; set; }
        
        public string ProductName { get; set; }
        /// <summary>
        /// Description of given Product, used to give specifics
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// price paid by the customer, not the price the item was bought at wholesale
        /// </summary>
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// A rough estimate (since it has the possibility of getting off-kilter) of amount in stock
        /// </summary>
        public int QuantityInStock { get; set; }
    }
}
