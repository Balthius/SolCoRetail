using System.Collections.Generic;
using SRMDataManager.Library.Models;

namespace SRMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts();
    }
}