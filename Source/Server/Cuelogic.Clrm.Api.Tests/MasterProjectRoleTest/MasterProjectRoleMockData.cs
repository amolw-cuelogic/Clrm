using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.MasterProjectRoleTest
{
    public class MasterProjectRoleMockData
    {
        public static string GetMockDataMasterProjectRoleList()
        {
            return "[{'Id':13,'Role':'Developer','costing':20000,'IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':14,'Role':'Product Developer','costing':30000,'IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':15,'Role':'Technical Analyst','costing':25000,'IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':16,'Role':'Ui Engineer','costing':35000,'IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':17,'Role':'Backend Developer','costing':50000,'IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'}]";
        }

        public static MasterProjectRole GetMockDataMasterProjectRole()
        {
            var data = new MasterProjectRole();
            data.Id = 1;
            data.Role = "Ui Developer";
            data.IsValid = true;
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            return data;
        }
    }
}
