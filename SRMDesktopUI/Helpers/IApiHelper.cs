using SRMDesktopUI.Models;
using System.Threading.Tasks;

namespace SRMDesktopUI.Helpers
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}