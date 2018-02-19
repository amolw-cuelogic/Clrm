using Cuelogic.Clrm.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using log4net;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;

namespace Cuelogic.Clrm.DataAccessLayer.DataAccess
{
    public class MasterDepartmentDataAccess : IMasterDepartmentDataAccess
    {
        public DataSet GetMasterDepartment(int MasterDepartmentId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterDepartment_Get;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterDepartmentId", MasterDepartmentId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterDepartmentList(SearchParam objSearchParam)
        {
            var RecordFrom = objSearchParam.Page * objSearchParam.Show;
            var Show = objSearchParam.Show;

            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterDepartment_GetList;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", objSearchParam.FilterText),
                    new MySqlParameter("@RecordFrom", RecordFrom),
                    new MySqlParameter("@RecordTill", Show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public void InsertMasterDepartment(MasterDepartment ObjMasterDepartment)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterDepartment_Insert;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@departmentName", ObjMasterDepartment.DepartmentName),
                    new MySqlParameter("@departmentHead", ObjMasterDepartment.DepartmentHead),
                    new MySqlParameter("@isValid", ObjMasterDepartment.IsValid),
                    new MySqlParameter("@createdBy", ObjMasterDepartment.CreatedBy),
                    new MySqlParameter("@createdOn", ObjMasterDepartment.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterDepartment_Update;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@departmentId", ObjMasterDepartment.Id),
                    new MySqlParameter("@departmentName", ObjMasterDepartment.DepartmentName),
                    new MySqlParameter("@departmentHead", ObjMasterDepartment.DepartmentHead),
                    new MySqlParameter("@isValid", ObjMasterDepartment.IsValid),
                    new MySqlParameter("@updatedby", ObjMasterDepartment.UpdatedBy),
                    new MySqlParameter("@updatedon", ObjMasterDepartment.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void MarkMasterDepartmentInvalid(int MasterDepartmentId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterDepartment_MarkInvalid;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterDepartmentId", MasterDepartmentId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

    }
}
