
using SRMDesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SRMDesktopUI.Library.Api
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
        void LogOffUser();

        HttpClient ApiClient { get; }
    }
}