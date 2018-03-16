using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.MockData
{
    public class MasterRoleMockData
    {
        public static string GetMockDataMasterProjectRoleList()
        {
            return "[{'Id':13,'Role':'Developer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':1,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':14,'Role':'Product Developer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':15,'Role':'Technical Analyst','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':1,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':16,'Role':'Ui Engineer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':17,'Role':'Backend Developer','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':1,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':18,'Role':'Trainee Develop','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/03/12','UpdatedBy':1,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'}]";
        }

        public static DataSet GetMockDataMasterProjectRoleDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataMasterProjectRoleList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static MasterRole GetMockDataMasterProjectRole()
        {
            var data = new MasterRole();
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
