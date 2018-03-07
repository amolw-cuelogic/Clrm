using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.ProjectTest
{
    public class ProjectMockData
    {
        public static string GetMockDataProjectList()
        {
            return "[{'Id':15,'ProjectName':'Kantar','Type':'Billable','StartDate':'2017/07/01','EndDate':null,'IsComplete':'No','IsValid':'Yes'},{'Id':16,'ProjectName':'Tiny Torch','Type':'Billable','StartDate':'2017/01/01','EndDate':null,'IsComplete':'No','IsValid':'Yes'},{'Id':17,'ProjectName':'Cuelogic Resource Management','Type':'In House','StartDate':'2018/01/15','EndDate':null,'IsComplete':'No','IsValid':'Yes'},{'Id':18,'ProjectName':'Big Data Charting System','Type':'Billable','StartDate':'2018/03/01','EndDate':null,'IsComplete':'No','IsValid':'Yes'}]";
        }

        public static Project GetMockDataProject()
        {
            var data = new Project();
            data.Id = 1;
            data.ProjectName = "Kantar";
            data.CurrencyId = 1;
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
