using System.Collections.Generic;
using SRMDataManager.Library.Models;

namespace SRMDataManager.Library.DataAccess
{
    public interface ISaleData
    {
        List<SaleReportModel> GetSaleReport();
        decimal GetTaxRate();
        void SaveSale(SaleModel saleInfo, string cashierId);
    }
}