﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.UserGroup;
using Cuelogic.Clrm.Common;

namespace Cuelogic.Clrm.Repository.UserGroup
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IUserGroupDataAccess _userGroupDataAcces;

        public UserGroupRepository()
        {
            _userGroupDataAcces = new UserGroupDataAccess();
        }
        public List<Employee> GetEmployeeList(string employeeName)
        {
            var ds = _userGroupDataAcces.GetEmployeeList(employeeName);
            List<Employee> list = new List<Employee>();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<Employee>();
            return list;
        }

        public List<IdentityGroup> GetGroupList()
        {
            var ds = _userGroupDataAcces.GetGroupList();
            List<IdentityGroup> list = new List<IdentityGroup>();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<IdentityGroup>();
            return list;
        }

        public List<Employee> GetIdentityGroupMembers(int gId)
        {
            var ds = _userGroupDataAcces.GetIdentityGroupMembers(gId);
            List<Employee> list = new List<Employee>();
            if (ds.Tables[0].Rows.Count > 0)
                list = ds.Tables[0].ToList<Employee>();
            return list;
        }
    }
}
