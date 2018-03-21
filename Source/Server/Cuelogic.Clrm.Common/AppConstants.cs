using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class AppConstants
    {
        public const string TargetDatabase = "TargetDatabase";

        public static class TableName
        {
            public const string Employee = "Employee";
            public const string MasterRole = "MasterRole";
            public const string Project = "Project";
            public const string IdentityGroup = "IdentityGroup";
            public const string MasterDepartment = "MasterDepartment";
            public const string MasterSkill = "MasterSkill";
            public const string MasterOrganizationRole = "MasterOrganizationRole";
            public const string IdentityEmployeeGroup = "IdentityEmployeeGroup";
            public const string EmployeeDepartment = "EmployeeDepartment";
            public const string EmployeeSkill = "EmployeeSkill";
            public const string EmployeeOrganizationRole = "EmployeeOrganizationRole";
            public const string ProjectRole = "ProjectRole";
            public const string MasterClient = "MasterClient";
            public const string MasterCurrency = "MasterCurrency";
        }
        public static class StoreProcedure
        {
            #region COMMON 

            public const string Employee_GetByEmailId = "Employee_GetByEmailId";
            public const string EmployeeAllocation_GetList = "EmployeeAllocation_GetList";
            public const string EmployeeRights_Get = "EmployeeRights_Get";
            public const string Employee_GetByOrgEmpId = "Employee_GetByOrgEmpId";
            public const string Common_LogLoginTime = "Common_LogLoginTime";

            #endregion

            #region EMPLOYEE

            public const string Employee_GetById = "Employee_GetById";
            public const string Employee_GetList = "Employee_GetList";
            public const string Employee_GetMasterValidList = "Employee_GetMasterValidList";
            public const string Employee_GetChildValidList = "Employee_GetChildValidList";
            public const string Employee_AddOrUpdate = "Employee_AddOrUpdate";
            public const string EmployeeSkill_BulkAddOrUpdate = "EmployeeSkill_BulkAddOrUpdate";
            public const string EmployeeDepartment_BulkAddOrUpdate = "EmployeeDepartment_BulkAddOrUpdate";
            public const string EmployeeOrganizationRole_BulkAddOrUpdate = "EmployeeOrganizationRole_BulkAddOrUpdate";
            public const string EmployeeGroup_BulkAddOrUpdate = "EmployeeGroup_BulkAddOrUpdate";
            public const string Employee_GetLatestId = "Employee_GetLatestId";
            public const string Employee_MarkInvalid = "Employee_MarkInvalid";
            
            #endregion

            #region PROJECT

            public const string Project_AddOrUpdate = "Project_AddOrUpdate";
            public const string Project_Get = "Project_Get";
            public const string Project_GetList = "Project_GetList";
            public const string Project_MarkInvalid = "Project_MarkInvalid";
            public const string Project_GetLatestId = "Project_GetLatestId";
            public const string Project_GetSelectList = "Project_GetSelectList";
            public const string Project_BulkInsertRoles = "Project_BulkInsertRoles";
            

            #endregion

            #region ALLOCATION

            public const string Allocation_AddOrUpdate = "Allocation_AddOrUpdate";
            public const string Allocation_GetList = "Allocation_GetList";
            public const string Allocation_Get = "Allocation_Get";
            public const string Allocation_GetSelectList = "Allocation_GetSelectList";
            public const string Allocation_MarkInvalid = "Allocation_MarkInvalid";
            public const string Allocation_GetAllocationSum = "Allocation_GetAllocationSum";
            public const string Allocation_GetRoleByProject = "Allocation_GetRoleByProject";
            
            #endregion

            #region USER GROUP 

            public const string UserGroup_GetEmployees = "UserGroup_GetEmployees";
            public const string UserGroup_GetIdentityGroup = "UserGroup_GetIdentityGroup";
            public const string UserGroup_GetIdentityGroupMembers = "UserGroup_GetIdentityGroupMembers";
            public const string UserGroup_InsertGroupUser = "UserGroup_InsertGroupUser";

            #endregion

            #region MASTER GROUP 

            public const string IdentityGroup_GetList = "IdentityGroup_GetList";
            public const string IdentityGroup_Get = "IdentityGroup_Get";
            public const string IdentityGroupRight_Get = "IdentityGroupRight_Get";
            public const string IdentityGroup_Update = "IdentityGroup_Update";
            public const string IdentityGroupRight_BulkUpdate = "IdentityGroupRight_BulkUpdate";
            public const string IdentityGroup_Insert = "IdentityGroup_Insert";
            public const string IdentityGroupRight_BulkInsert = "IdentityGroupRight_BulkInsert";
            public const string IdentityGroup_MarkInvalid = "IdentityGroup_MarkInvalid";
            public const string IdentityRight_Get = "IdentityRight_Get";

            #endregion
            
            #region MASTER DEPARTMENT 

            public const string MasterDepartment_GetList = "MasterDepartment_GetList";
            public const string MasterDepartment_Get = "MasterDepartment_Get";
            public const string MasterDepartment_MarkInvalid = "MasterDepartment_MarkInvalid";
            public const string MasterDepartment_Update = "MasterDepartment_Update";
            public const string MasterDepartment_Insert = "MasterDepartment_Insert";

            #endregion

            #region MASTER ORGANIZATION ROLE

            public const string MasterOrganizationRole_GetList = "MasterOrganizationRole_GetList";
            public const string MasterOrganizationRole_Get = "MasterOrganizationRole_Get";
            public const string MasterOrganizationRole_Insert = "MasterOrganizationRole_Insert";
            public const string MasterOrganizationRole_Update = "MasterOrganizationRole_Update";
            public const string MasterOrganizationRole_MarkInvalid = "MasterOrganizationRole_MarkInvalid";

            #endregion

            #region MASTER SKILLS

            public const string MasterSkill_Get = "MasterSkill_Get";
            public const string MasterSkill_GetList = "MasterSkill_GetList";
            public const string MasterSkill_Insert = "MasterSkill_Insert";
            public const string MasterSkill_MarkInvalid = "MasterSkill_MarkInvalid";
            public const string MasterSkill_Update = "MasterSkill_Update";

            #endregion
            
            #region MASTER ROLE

            public const string MasterRole_AddOrUpdate = "MasterRole_AddOrUpdate";
            public const string MasterRole_Get = "MasterRole_Get";
            public const string MasterRole_GetList = "MasterRole_GetList";
            public const string MasterRole_MarkInvalid = "MasterRole_MarkInvalid";

            #endregion

            #region MASTER PROJECT TYPE

            public const string MasterProjectType_AddOrUpdate = "MasterProjectType_AddOrUpdate";
            public const string MasterProjectType_Get = "MasterProjectType_Get";
            public const string MasterProjectType_GetList = "MasterProjectType_GetList";
            public const string MasterProjectType_MarkInvalid = "MasterProjectType_MarkInvalid";
            public const string MasterProjectType_GetValidList = "MasterProjectType_GetValidList";

            #endregion

            #region MASTER CLIENT

            public const string MasterClient_AddOrUpdate = "MasterClient_AddOrUpdate";
            public const string MasterClient_Get = "MasterClient_Get";
            public const string MasterClient_GetList = "MasterClient_GetList";
            public const string MasterClient_MarkInvalid = "MasterClient_MarkInvalid";
            public const string MasterClient_GetCountryList = "MasterClient_GetCountryList";
            public const string MasterClient_GetCityList = "MasterClient_GetCityList";

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
            public const int AdminGroup = 200;
            public const int AdminUserGroup = 201;
            public const int AdminEmployee = 202;

            //300 Series for Master level sections
            public const int MasterSkill = 300;
            public const int MasterDepartment = 301;
            public const int MasterOrganizationRole = 302;
            public const int MasterProjectRole = 303;
            public const int MasterProjectType = 304;
            public const int MasterClient = 305;

            //400 Series for root level sections
            public const int Dashboard = 400;
            public const int MyProfile = 401;
            public const int Project = 402;
            public const int Allocation = 403;
            
        }

        public static class AuthorizeFlag
        {
            public const int Read = 1;
            public const int Write = 2;
            public const int Delete = 3;
        }

        public static class DatabaseType
        {
            public const string MySql = "MySql";
        }
        
        public static class CustomError
        {
            public const string NoConcreteImplementation = "Concrete implentation not implemented for given database";
            public const string InValidId = "In Valid Id";
        }
    }
}
