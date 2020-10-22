using System.Threading.Tasks;
using SRMDesktopUI.Library.Models;

namespace SRMDesktopUI.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}