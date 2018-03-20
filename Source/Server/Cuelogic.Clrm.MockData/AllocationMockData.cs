using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Cuelogic.Clrm.Common.AppConstants;

namespace Cuelogic.Clrm.MockData
{
    public class AllocationMockData
    {
        public static string GetMockDataAllocationList()
        {
            return "[{'Id':3,'FullName':'Amol Maruti Wabale','Role':'Technical Analyst','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':50,'StartDate':'2018/03/06','EndDate':null,'IsValid':'Yes'},{'Id':1,'FullName':'Amol Maruti Wabale','Role':'Product Developer','ProjectName':'Kantar','IsBillable':'No','PercentageAllocation':50,'StartDate':'2018/03/06','EndDate':null,'IsValid':'Yes'},{'Id':2,'FullName':'Abhijeet  Jivan Sawant','Role':'Product Developer','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':100,'StartDate':'2017/11/10','EndDate':null,'IsValid':'Yes'},{'Id':4,'FullName':'Pranav Ravindra Shinde','Role':'Developer','ProjectName':'Kantar','IsBillable':'No','PercentageAllocation':90,'StartDate':'2017/12/01','EndDate':null,'IsValid':'Yes'},{'Id':5,'FullName':'Pranav Ravindra Shinde','Role':'Ui Engineer','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':5,'StartDate':'2017/12/08','EndDate':null,'IsValid':'Yes'}]";
        }

        public static DataSet GetMockDataAllocationListDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataAllocationList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetMockDataAllocationDataset()
        {
            var ds = new DataSet();
            var data = GetMockDataAllocation();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.Columns.Remove("SelectListEmployee");
            dt.Columns.Remove("SelectListMasterRole");
            dt.Columns.Remove("SelectListProject");
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetMockDataAllocationSelectListDataset()
        {
            var ds = new DataSet();
            var jsonString1 = EmployeeMockData.GetMockDataemployeeList();
            var dt1 = Helper.JsonStringToDatatable(jsonString1);
            dt1.TableName = TableName.Employee;
            ds.Tables.Add(dt1);

            var jsonString2 = ProjectMockData.GetMockDataProjectList();
            var dt2 = Helper.JsonStringToDatatable(jsonString2);
            dt2.TableName = TableName.Project;
            ds.Tables.Add(dt2);

            return ds;
        }

        public static DataSet GetMockDataAllocationIdDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataAllocationList();
            var dt = Helper.JsonStringToDatatable("[{Id:50}]");
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetMockDataMasterRoleListDataset()
        {
            var ds = new DataSet();
            var data = GetMockDataMasterRoleList();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }
        public static Allocation GetMockDataAllocation()
        {
            var data = new Allocation();
            data.Id = 1;
            data.EmployeeId = 1;
            data.ProjectId = 1;
            data.ProjectRoleId = 1;
            data.PercentageAllocation = 50;
            data.StartDate = "2018-02-02";
            data.IsValid = true;
            data.IsBillable = true;
            return data;
        }
        
        public static List<MasterRole> GetMockDataMasterRoleList()
        {
            var list = new List<MasterRole>();
            var data = new MasterRole();
            data.Id = 1;
            data.Role = "Ui Developer";
            data.IsValid = true;
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            list.Add(data);

            var data1 = new MasterRole();
            data1.Id = 1;
            data1.Role = "Ui Developer";
            data1.IsValid = true;
            data1.CreatedBy = 1;
            data1.CreatedOn = "2018-02-02";
            data1.UpdatedBy = 1;
            data1.UpdatedOn = "2018-02-02";
            list.Add(data1);

            return list;
        }

    }
}
