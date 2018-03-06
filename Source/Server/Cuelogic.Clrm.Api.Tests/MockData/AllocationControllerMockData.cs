﻿using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Api.Tests.MockData
{
    public class AllocationControllerMockData
    {
        public static string GetMockDataAllocationList()
        {
            return "[{'Id':3,'FullName':'Amol Maruti Wabale','Role':'Technical Analyst','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':50,'StartDate':'2018/03/06','EndDate':null,'IsValid':'Yes'},{'Id':1,'FullName':'Amol Maruti Wabale','Role':'Product Developer','ProjectName':'Kantar','IsBillable':'No','PercentageAllocation':50,'StartDate':'2018/03/06','EndDate':null,'IsValid':'Yes'},{'Id':2,'FullName':'Abhijeet  Jivan Sawant','Role':'Product Developer','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':100,'StartDate':'2017/11/10','EndDate':null,'IsValid':'Yes'},{'Id':4,'FullName':'Pranav Ravindra Shinde','Role':'Developer','ProjectName':'Kantar','IsBillable':'No','PercentageAllocation':90,'StartDate':'2017/12/01','EndDate':null,'IsValid':'Yes'},{'Id':5,'FullName':'Pranav Ravindra Shinde','Role':'Ui Engineer','ProjectName':'Tiny Torch','IsBillable':'No','PercentageAllocation':5,'StartDate':'2017/12/08','EndDate':null,'IsValid':'Yes'}]";
        }
    }
}
