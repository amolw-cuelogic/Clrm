using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class AppConstants
    {
        public static class StoreProcedure
        {
            #region MASTER GROUP 

            public const string spIdentityGroup_GetList = "spIdentityGroup_GetList";
            public const string spIdentityGroup_Get = "spIdentityGroup_Get";
            public const string spIdentityGroupRight_Get = "spIdentityGroupRight_Get";
            public const string spIdentityGroup_Update = "spIdentityGroup_Update";
            public const string spIdentityGroupRight_BulkUpdate = "spIdentityGroupRight_BulkUpdate";
            public const string spIdentityGroup_Insert = "spIdentityGroup_Insert";
            public const string spIdentityGroupRight_BulkInsert = "spIdentityGroupRight_BulkInsert";
            public const string spIdentityGroup_MarkInvalid = "spIdentityGroup_MarkInvalid";
            public const string spIdentityRight_Get = "spIdentityRight_Get";

            #endregion

            #region COMMON 

            public const string spEmployee_GetByEmailId = "spEmployee_GetByEmailId";
            public const string spEmployeeAllocation_GetList = "spEmployeeAllocation_GetList";
            public const string spEmployeeRights_Get = "spEmployeeRights_Get";
            public const string spEmployee_GetByOrgEmpId = "spEmployee_GetByOrgEmpId";

            #endregion

            #region MASTER DEPARTMENT 

            public const string spMasterDepartment_GetList = "spMasterDepartment_GetList";
            public const string spMasterDepartment_Get = "spMasterDepartment_Get";
            public const string spMasterDepartment_MarkInvalid = "spMasterDepartment_MarkInvalid";
            public const string spMasterDepartment_Update = "spMasterDepartment_Update";
            public const string spMasterDepartment_Insert = "spMasterDepartment_Insert";

            #endregion

            #region MASTER ORGANIZATION ROLE

            public const string spMasterOrganizationRole_GetList = "spMasterOrganizationRole_GetList";
            public const string spMasterOrganizationRole_Get = "spMasterOrganizationRole_Get";
            public const string spMasterOrganizationRole_Insert = "spMasterOrganizationRole_Insert";
            public const string spMasterOrganizationRole_Update = "spMasterOrganizationRole_Update";
            public const string spMasterOrganizationRole_MarkInvalid = "spMasterOrganizationRole_MarkInvalid";

            #endregion

            #region MASTER SKILLS

            public const string spMasterSkill_Get = "spMasterSkill_Get";
            public const string spMasterSkill_GetList = "spMasterSkill_GetList";
            public const string spMasterSkill_Insert = "spMasterSkill_Insert";
            public const string spMasterSkill_MarkInvalid = "spMasterSkill_MarkInvalid";
            public const string spMasterSkill_Update = "spMasterSkill_Update";

            #endregion

            #region EMPLOYEE

            public const string spEmployee_GetById = "spEmployee_GetById";
            public const string spEmployee_GetList = "spEmployee_GetList";
            public const string spEmployee_GetMasterValidList = "spEmployee_GetMasterValidList";
            public const string spEmployee_GetChildValidList = "spEmployee_GetChildValidList";
            public const string spEmployee_AddOrUpdate = "spEmployee_AddOrUpdate";
            public const string spEmployeeSkill_BulkAddOrUpdate = "spEmployeeSkill_BulkAddOrUpdate";
            public const string spEmployeeDepartment_BulkAddOrUpdate = "spEmployeeDepartment_BulkAddOrUpdate";
            public const string spEmployeeOrganizationRole_BulkAddOrUpdate = "spEmployeeOrganizationRole_BulkAddOrUpdate";
            public const string spEmployeeGroup_BulkAddOrUpdate = "spEmployeeGroup_BulkAddOrUpdate";
            public const string spEmployee_GetLatestId = "spEmployee_GetLatestId";
            public const string spEmployee_MarkInvalid = "spEmployee_MarkInvalid";

            public static class spEmployee_GetMasterValidList_Tables
            {
                public const string IdentityGroup = "IdentityGroup";
                public const string MasterDepartment = "MasterDepartment";
                public const string MasterSkill = "MasterSkill";
                public const string MasterOrganizationRole = "MasterOrganizationRole";
            }

            #endregion

            #region MASTER PROJECT ROLE

            public const string spMasterProjectRole_AddOrUpdate = "spMasterProjectRole_AddOrUpdate";
            public const string spMasterProjectRole_Get = "spMasterProjectRole_Get";
            public const string spMasterProjectRole_GetList = "spMasterProjectRole_GetList";
            public const string spMasterProjectRole_MarkInvalid = "spMasterProjectRole_MarkInvalid";

            #endregion

            #region MASTER PROJECT TYPE

            public const string spMasterProjectType_AddOrUpdate = "spMasterProjectType_AddOrUpdate";
            public const string spMasterProjectType_Get = "spMasterProjectType_Get";
            public const string spMasterProjectType_GetList = "spMasterProjectType_GetList";
            public const string spMasterProjectType_MarkInvalid = "spMasterProjectType_MarkInvalid";
            public const string spMasterProjectType_GetValidList = "spMasterProjectType_GetValidList";

            #endregion

            #region MASTER CLIENT

            public const string spMasterClient_AddOrUpdate = "spMasterClient_AddOrUpdate";
            public const string spMasterClient_Get = "spMasterClient_Get";
            public const string spMasterClient_GetList = "spMasterClient_GetList";
            public const string spMasterClient_MarkInvalid = "spMasterClient_MarkInvalid";
            public const string spMasterClient_GetCountryList = "spMasterClient_GetCountryList";
            public const string spMasterClient_GetCityList = "spMasterClient_GetCityList";

            #endregion

            #region PROJECT

            public const string spProject_AddOrUpdate = "spProject_AddOrUpdate";
            public const string spProject_Get = "spProject_Get";
            public const string spProject_GetList = "spProject_GetList";
            public const string spProject_MarkInvalid = "spProject_MarkInvalid";
            public const string spProject_GetLatestId = "spProject_GetLatestId";
            public const string spProject_GetSelectList = "spProject_GetSelectList";

            public class spProject_GetSelectList_Tables
            {
                public const string MasterClient = "MasterClient";
                public const string MasterCurrency = "MasterCurrency";
            }

            #endregion

            #region ALLOCATION

            public const string spAllocation_AddOrUpdate = "spAllocation_AddOrUpdate";
            public const string spAllocation_GetList = "spAllocation_GetList";
            public const string spAllocation_Get = "spAllocation_Get";
            public const string spAllocation_GetSelectList = "spAllocation_GetSelectList";
            public const string spAllocation_MarkInvalid = "spAllocation_MarkInvalid";
            public const string spAllocation_GetAllocationSum = "spAllocation_GetAllocationSum";

            public class spAllocation_GetSelectList_Tables
            {
                public const string Employee = "Employee";
                public const string MasterProjectRole = "MasterProjectRole";
                public const string Project = "Project";
            }

            #endregion

            #region USER GROUP 

            public const string spUserGroup_GetEmployees = "spUserGroup_GetEmployees";
            public const string spUserGroup_GetIdentityGroup = "spUserGroup_GetIdentityGroup";
            public const string spUserGroup_GetIdentityGroupMembers = "spUserGroup_GetIdentityGroupMembers";

            #endregion
        }

        public class MessageType
        {
            public static string Error = "Error";
            public static string Success = "Success";
            public static string Warning = "Warning";
            public static string Information = "Information";
        }

        //IdentityRights Class should be compulsarily in sync with IdentityRights table in database
        public static class IdentityRights
        {
            //200 Series for Admin level sections 
            public const int Group = 200;

            //300 Series for Master level sections
            public const int MasterSkill = 300;
            public const int MasterDepartment = 301;
            public const int MasterOrganizationRole = 302;
            public const int MasterProjectRole = 303;
            public const int MasterProjectType = 304;
            public const int MasterClient = 305;

            //400 Series for root level sections
            public const int MyProfile = 400;
            public const int Employee = 401;
            public const int Project = 402;
            public const int Allocation = 403;
            public const int Dashboard = 404;
        }

        public static class AuthorizeFlag
        {
            public const int Read = 1;
            public const int Write = 2;
            public const int Delete = 3;
        }
    }
}
