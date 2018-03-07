using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.MasterGroupTest
{
    public class MasterGroupMockData
    {
        public static string GetMockDataMasterGroupList()
        {
            return "[{'Id':109,'GroupName':'Super Admin','GroupDescription':'Super Admin','IsValid':'Yes','Name':'Amol Wabale','CreatedOn':'01/03/2018'},{'Id':111,'GroupName':'User','GroupDescription':'User','IsValid':'Yes','Name':'Amol Wabale','CreatedOn':'06/03/2018'}]";
        }

        public static IdentityGroup GetMockDataMasterGroup()
        {
            var data = new IdentityGroup();
            data.Id = 1;
            data.GroupName = "Super Admin";
            data.GroupDescription = "Super Admin";
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            return data;
        }
    }
}
