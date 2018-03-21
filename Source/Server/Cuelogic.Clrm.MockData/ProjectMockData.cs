using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.MockData
{
    public class ProjectMockData
    {
        public static string GetMockDataProjectList()
        {
            return "[{'Id':15,'ProjectName':'Kantar','Type':'Billable','StartDate':'2017/07/01','EndDate':null,'IsComplete':'No','IsValid':'Yes'},{'Id':16,'ProjectName':'Tiny Torch','Type':'Billable','StartDate':'2017/01/01','EndDate':null,'IsComplete':'No','IsValid':'Yes'},{'Id':17,'ProjectName':'Cuelogic Resource Management','Type':'In House','StartDate':'2018/01/15','EndDate':null,'IsComplete':'No','IsValid':'Yes'},{'Id':18,'ProjectName':'Big Data Charting System','Type':'Billable','StartDate':'2018/03/01','EndDate':null,'IsComplete':'No','IsValid':'Yes'}]";
        }

        public static DataSet GetMockDataProjectListDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataProjectList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetLatestId()
        {
            var ds = new DataSet();
            var jsonString = "[{Id:1}]";
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }



        public static DataSet GetMockDataMasterListDataSet()
        {
            var ds = new DataSet();

            var jsonString = MasterClientMockData.GetMockDataMasterClientList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.TableName = TableName.MasterClient;
            ds.Tables.Add(dt);

            jsonString = MasterRoleMockData.GetMockDataMasterProjectRoleList();
            dt = Helper.JsonStringToDatatable(jsonString);
            dt.TableName = TableName.MasterRole;
            ds.Tables.Add(dt);

            var data  = CommonMockData.GetMasterCurrency();
            jsonString = Helper.ObjectToJson(data);
            dt = Helper.JsonStringToDatatable(jsonString);
            dt.TableName = TableName.MasterCurrency;
            ds.Tables.Add(dt);

            return ds;

        }
        public static DataSet GetMockDataProjectDataset()
        {
            var ds = new DataSet();
            var data = GetMockDataProject();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.Columns.Remove("ProjectMasterClientList");
            dt.Columns.Remove("ProjectTypeList");
            dt.Columns.Remove("MasterRoleList");
            dt.Columns.Remove("MasterCurrencyList");
            dt.Columns.Remove("ProjectRoleList");
            dt.TableName = TableName.Project;
            ds.Tables.Add(dt);

            jsonString = MasterRoleMockData.GetMockDataMasterProjectRoleList();
            dt = Helper.JsonStringToDatatable(jsonString);
            dt.TableName = TableName.ProjectRole;
            ds.Tables.Add(dt);

            return ds;
        }

        public static Project GetMockDataProject()
        {
            var data = new Project();
            data.Id = 1;
            data.ProjectName = "Kantar";
            data.ProjectTypeId = 1;
            data.StartDate = "2018-02-02";
            data.IsValid = true;
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            return data;
        }
    }
}
