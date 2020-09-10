
using SRMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace SRMDesktopUI.Library.Api
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}