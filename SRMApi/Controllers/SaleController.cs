using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SRMDataManager.Library.DataAccess;
using SRMDataManager.Library.Models;

namespace SRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SaleController(IConfiguration config)
        {
            _config = config;
        }
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData(_config);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// RequestContext.Principal.Identity.GetUserId();
            data.SaveSale(sale, userId);


        }

        [Authorize(Roles = "Admin, Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            //RequestContext.Principal.IsInRole("Admin"); can be used in an if statement to lock down portions of a method to certain roles

            SaleData data = new SaleData();

            return data.GetSaleReport();
        }
    }
}
