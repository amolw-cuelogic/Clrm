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
        private ILog applogManager = AppLogManager.GetLogger();
        public DataSet GetMasterDepartment(int MasterDepartmentId)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetMasterDepartment;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterDepartmentId", MasterDepartmentId)
                };
                var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public DataSet GetMasterDepartmentList(SearchParam objSearchParam)
        {
            try
            {
                var RecordFrom = objSearchParam.Page * objSearchParam.Show;
                var Show = objSearchParam.Show;

                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetMasterDepartmentList;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", objSearchParam.FilterText),
                    new MySqlParameter("@RecordFrom", RecordFrom),
                    new MySqlParameter("@RecordTill", Show)
                };
                var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public DataSet InsertMasterDepartment(MasterDepartment ObjMasterDepartment)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void MarkMasterDepartmentInvalid(int MasterDepartmentId)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
