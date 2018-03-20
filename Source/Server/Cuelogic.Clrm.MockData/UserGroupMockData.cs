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
    public class UserGroupMockData
    {
        public static DataSet GetEmployeeListDataset()
        {
            var ds = new DataSet();
            var data = GetEmployeeList();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }
        public static List<Employee> GetEmployeeList()
        {
            var dummyJsonString = "[{'Id':1,'FullName':'Amol Maruti Wabale','OrgEmpId':'CUE355','JoiningDate':'2018/02/28','Email':'amol.wabale@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':17,'FullName':'Abhijeet  Jivan Sawant','OrgEmpId':'CUE238','JoiningDate':'2018/03/15','Email':'abhijeet.sawant@cuelogic.co.in','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':18,'FullName':'Pranav Ravindra Shinde','OrgEmpId':'CUE672','JoiningDate':'2018/01/05','Email':'pranav.shinde@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':19,'FullName':'Debujit Shrikant Suryavanshi','OrgEmpId':'CUE295','JoiningDate':'2017/08/04','Email':'debujit.suryavanshi@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':20,'FullName':'Pandurang Tukaram Deshpande','OrgEmpId':'CUE674','JoiningDate':'2017/08/04','Email':'panduranf.tukaram@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':21,'FullName':'Bharat  Puranik','OrgEmpId':'CUE456','JoiningDate':'2018/02/21','Email':'bharat.puranik@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'}]";
            var data = Helper.JsonToObject<List<Employee>>(dummyJsonString);
            return data;
        }

        public static DataSet GetGroupListDataset()
        {
            var ds = new DataSet();
            var data = GetGroupList();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }
        public static List<IdentityGroup> GetGroupList()
        {
            var dummyJsonString = "[{'Id':109,'GroupName':'Super Admin','GroupDescription':'Super Admin','IsValid':'true','Name':'Amol Wabale','CreatedOn':'01/03/2018'},{'Id':111,'GroupName':'User','GroupDescription':'User','IsValid':'true','Name':'Amol Wabale','CreatedOn':'06/03/2018'}]";
            var data = Helper.JsonToObject<List<IdentityGroup>>(dummyJsonString);
            return data;
        }

        public static DataSet GetIdentityGroupMemberListDataset()
        {
            var ds = new DataSet();
            var data = GetIdentityGroupMemberList();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static List<Employee> GetIdentityGroupMemberList()
        {
            var dummyJsonString = "[{'Id':1,'FullName':'Amol Maruti Wabale','OrgEmpId':'CUE355','JoiningDate':'2018/02/28','Email':'amol.wabale@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':17,'FullName':'Abhijeet  Jivan Sawant','OrgEmpId':'CUE238','JoiningDate':'2018/03/15','Email':'abhijeet.sawant@cuelogic.co.in','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':18,'FullName':'Pranav Ravindra Shinde','OrgEmpId':'CUE672','JoiningDate':'2018/01/05','Email':'pranav.shinde@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':19,'FullName':'Debujit Shrikant Suryavanshi','OrgEmpId':'CUE295','JoiningDate':'2017/08/04','Email':'debujit.suryavanshi@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':20,'FullName':'Pandurang Tukaram Deshpande','OrgEmpId':'CUE674','JoiningDate':'2017/08/04','Email':'panduranf.tukaram@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'},{'Id':21,'FullName':'Bharat  Puranik','OrgEmpId':'CUE456','JoiningDate':'2018/02/21','Email':'bharat.puranik@cuelogic.com','IsValid':'true','CreatedByName':'Amol Wabale'}]";
            var data = Helper.JsonToObject<List<Employee>>(dummyJsonString);
            return data;
        }

        public static List<IdentityEmployeeGroup> GetIdentityEmployeeGroupList()
        {
            var dummyXmlString = "<?xml version='1.0' encoding='utf-16'?> <ArrayOfIdentityEmployeeGroup xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <IdentityEmployeeGroup> <Id>0</Id> <GroupId>113</GroupId> <GroupName>temp</GroupName> <EmployeeId>18</EmployeeId> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <CreatedByName>temp</CreatedByName> <UpdatedByName>temp</UpdatedByName> </IdentityEmployeeGroup> <IdentityEmployeeGroup> <Id>0</Id> <GroupId>113</GroupId> <GroupName>temp</GroupName> <EmployeeId>19</EmployeeId> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <CreatedByName>temp</CreatedByName> <UpdatedByName>temp</UpdatedByName> </IdentityEmployeeGroup> </ArrayOfIdentityEmployeeGroup>";
            var data = Helper.XmlToObject(dummyXmlString, typeof(List<IdentityEmployeeGroup>)) as List<IdentityEmployeeGroup>;
            return data;
        }
    }
}
