using SRMDataManager.Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SRMDataManager.Library.Models;

namespace SRMDataManager.Controllers
{   
    [Authorize(Roles = "Cashier")]
    public class ProductController : ApiController
    {
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();

            return data.GetProducts();
        }
    }
}
