using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.MasterDepartmentTest
{
    public class MasterDepartmentMockData
    {
        public static string GetMockDataMasterDepartmentList()
        {
            return "[{'Id':20,'DepartmentName':'Delivery','DepartmentHead':'Vivek Phadke','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':21,'DepartmentName':'HR','DepartmentHead':'Uma Ramani','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':22,'DepartmentName':'Sales','DepartmentHead':'Neel Vartikar','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':23,'DepartmentName':'Management','DepartmentHead':'Nikhil Ambekar','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':24,'DepartmentName':'Technical','DepartmentHead':'Vikrant Labde','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/01/01','UpdatedBy':null,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'},{'Id':25,'DepartmentName':'Admin','DepartmentHead':'Admin','IsValid':'Yes','CreatedBy':1,'CreatedOn':'2018/03/06','UpdatedBy':1,'UpdatedBy1':null,'CreatedByName':'Amol Wabale'}]";
        }

        public static MasterDepartment GetMockDataMasterDepartment()
        {
            var data = new MasterDepartment();
            data.Id = 1;
            data.DepartmentName = "Delivery";
            data.DepartmentHead = "Vivek Phadke";
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            return data;
        }
    }
}
