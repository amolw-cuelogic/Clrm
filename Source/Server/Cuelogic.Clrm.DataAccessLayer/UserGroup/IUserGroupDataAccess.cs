﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.UserGroup
{
    public interface IUserGroupDataAccess
    {
        DataSet GetGroupList();
        DataSet GetEmployeeList(string employeeName);
        DataSet GetIdentityGroupMembers(int gId);
    }
}