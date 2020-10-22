using System.Collections.Generic;
using SRMDataManager.Library.Models;

namespace SRMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}