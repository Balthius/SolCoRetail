﻿using Microsoft.AspNet.Identity;
using SRMDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Models;

namespace SRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {

        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();
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
