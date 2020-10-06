using SRMDataManager.Library.Internal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;

namespace SRMDataManager.Library.DataAccess
{
    public class UserData
    {
        private readonly IConfiguration _config;

        public UserData(IConfiguration config)
        {
            _config = config;
        }
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var p = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "SRMData");

            return output;
        }
    }
}
