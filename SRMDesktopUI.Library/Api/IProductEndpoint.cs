using System.Collections.Generic;
using System.Threading.Tasks;
using SRMDesktopUI.Library.Models;

namespace SRMDesktopUI.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}