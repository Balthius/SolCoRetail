using System.Collections.Generic;
using SRMDataManager.Library.Models;

namespace SRMDataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        List<InventoryModel> GetInventory();
        void SaveInventoryRecord(InventoryModel item);
    }
}