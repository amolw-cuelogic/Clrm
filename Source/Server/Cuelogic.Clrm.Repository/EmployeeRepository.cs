using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using static Cuelogic.Clrm.Common.AppConstants;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDataAccess _dataAccess;
        
        public EmployeeRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }

        public DataSet GetChildListForEmployees(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetChildValidList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId } });
            sqlParam.TableName = new List<string> {
                TableName.IdentityEmployeeGroup,
                TableName.EmployeeDepartment,
                TableName.EmployeeSkill,
                TableName.EmployeeOrganizationRole
            };
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetEmployee(int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetById;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetEmployeeList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterListForEmployees()
        {
            var employeeVm = new EmployeeVm();

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetMasterValidList;
            sqlParam.TableName = new List<string> {
                TableName.IdentityGroup,
                TableName.MasterDepartment,
                TableName.MasterSkill,
                TableName.MasterOrganizationRole
            };
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void AddOrUpdateEmployee(EmployeeVm employeeVm, UserContext userContext)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_AddOrUpdate;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@employeeId", Value=employeeVm.Employee.Id },
                    new Param() { Key="@firstName", Value= employeeVm.Employee.FirstName },
                    new Param() { Key="@middleName", Value= employeeVm.Employee.MiddleName },
                    new Param() { Key="@lastName", Value= employeeVm.Employee.LastName },
                    new Param() { Key="@orgEmpId", Value= employeeVm.Employee.OrgEmpId },
                    new Param() { Key="@joiningDate", Value= employeeVm.Employee.JoiningDate },
                    new Param() { Key="@leavingDate", Value= employeeVm.Employee.LeavingDate },
                    new Param() { Key="@contactNum", Value= employeeVm.Employee.ContactNum },
                    new Param() { Key="@email", Value= employeeVm.Employee.Email },
                    new Param() { Key="@isValid", Value= employeeVm.Employee.IsValid },
                    new Param() { Key="@updatedBy", Value= employeeVm.Employee.UpdatedBy },
                    new Param() { Key="@createdBy", Value= employeeVm.Employee.CreatedBy },
                    new Param() { Key="@createdOn", Value= employeeVm.Employee.CreatedOn },
                    new Param() { Key="@updatedOn", Value= employeeVm.Employee.UpdatedOn },
            });
            _dataAccess.ExecuteNonQuery(sqlParam);

            if (employeeVm.Employee.Id == 0)
            {
                var sqlParamLatestId = new DataAccessParameter();
                sqlParamLatestId.StoreProcedureName = AppConstants.StoreProcedure.Employee_GetLatestId;
                var latestIdDs = _dataAccess.ExecuteQuery(sqlParamLatestId);
                var Id = latestIdDs.Tables[0].ToId();
                foreach (var item in employeeVm.Employee.EmployeeSkillList)
                    item.EmployeeId = Id;
                foreach (var item in employeeVm.Employee.EmployeeDepartmentList)
                    item.EmployeeId = Id;
                foreach (var item in employeeVm.Employee.EmployeeOrganizationRoleList)
                    item.EmployeeId = Id;
                foreach (var item in employeeVm.Employee.IdentityEmployeeGroupList)
                    item.EmployeeId = Id;
            }

            var skillListXml = Helper.ObjectToXml(employeeVm.Employee.EmployeeSkillList);
            var sqlParamSkill = new DataAccessParameter();
            sqlParamSkill.StoreProcedureName = AppConstants.StoreProcedure.EmployeeSkill_BulkAddOrUpdate;
            sqlParamSkill.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmltext", Value=skillListXml },
                    new Param() { Key="@userId", Value= userContext.UserId } });
            _dataAccess.ExecuteNonQuery(sqlParamSkill);

            var departmentListXml = Helper.ObjectToXml(employeeVm.Employee.EmployeeDepartmentList);
            var sqlParamDepartment = new DataAccessParameter();
            sqlParamDepartment.StoreProcedureName = AppConstants.StoreProcedure.EmployeeDepartment_BulkAddOrUpdate;
            sqlParamDepartment.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmltext", Value=departmentListXml },
                    new Param() { Key="@userId", Value= userContext.UserId } });
            _dataAccess.ExecuteNonQuery(sqlParamDepartment);

            var organizationRoleListXml = Helper.ObjectToXml(employeeVm.Employee.EmployeeOrganizationRoleList);
            var sqlParamOrganizationRole = new DataAccessParameter();
            sqlParamOrganizationRole.StoreProcedureName = AppConstants.StoreProcedure.EmployeeOrganizationRole_BulkAddOrUpdate;
            sqlParamOrganizationRole.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmltext", Value=organizationRoleListXml },
                    new Param() { Key="@userId", Value= userContext.UserId } });
            _dataAccess.ExecuteNonQuery(sqlParamOrganizationRole);

            var groupListXml = Helper.ObjectToXml(employeeVm.Employee.IdentityEmployeeGroupList);
            var sqlParamGroup = new DataAccessParameter();
            sqlParamGroup.StoreProcedureName = AppConstants.StoreProcedure.EmployeeGroup_BulkAddOrUpdate;
            sqlParamGroup.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmltext", Value=groupListXml },
                    new Param() { Key="@userId", Value= userContext.UserId } });
            _dataAccess.ExecuteNonQuery(sqlParamGroup);
        }

        public void MarkEmployeeInvalid(int employeeId, int userId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.Employee_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramEmployeeId", Value=employeeId },
                    new Param() { Key="@paramUserId", Value=userId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
