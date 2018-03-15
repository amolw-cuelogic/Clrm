using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.MockData
{
    public class MasterOrganizationRoleMockData
    {
        public static string GetMockDataMasterOrganizationRoleList()
        {
            return "[{'Id':20,'Role':'Software Engineer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':21,'Role':'Sr. Software Engineer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':22,'Role':'Devops','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':23,'Role':'Trainee Software Engineer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':24,'Role':'Principle Engineer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':25,'Role':'Project Manager','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':26,'Role':'Sr. Project Manager','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':27,'Role':'Rails Developer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/03/06','UpdatedBy':1,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'}]";
        }

        public static MasterOrganizationRole GetMockDataMasterOrganizationRole()
        {
            var data = new MasterOrganizationRole();
            data.Id = 1;
            data.Role = "Developer";
            data.IsValid = true;
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            return data;
        }
    }
}
