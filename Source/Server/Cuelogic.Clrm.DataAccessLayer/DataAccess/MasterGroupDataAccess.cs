using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.DataAccess
{
    public class MasterGroupDataAccess : IMasterGroupDataAccess
    {
        private ILog applogManager = AppLogManager.GetLogger();

        #region GET FUNCTIONS

        public DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            try
            {
                var RecordFrom = objSearchParam.Page * objSearchParam.Show;
                var Show = objSearchParam.Show;

                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroup_GetList;
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

        public DataSet GetIdentityGroup(int GroupId)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroup_Get;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@GroupId", GroupId)
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

        public DataSet GetIdentityGroupRights(int GroupId)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroupRight_Get;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@GroupId", GroupId)
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

        public DataSet GetIdentityRightList()
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityRight_Get;
                sqlparam.StoreProcedureParam = null;
                var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand());
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        #endregion

        #region UPDATE FUNCTIONS

        public void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroup_Update;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@GroupId", ObjIdentityGroup.Id),
                    new MySqlParameter("@grpn", ObjIdentityGroup.GroupName),
                    new MySqlParameter("@groupdesc", ObjIdentityGroup.GroupDescription),
                    new MySqlParameter("@valid", ObjIdentityGroup.IsValid),
                    new MySqlParameter("@updatedby", ObjIdentityGroup.UpdatedBy),
                    new MySqlParameter("@updatedon", ObjIdentityGroup.UpdatedOn)
                };
                DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                     sqlparam.StoreProcedureParam);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void UpdateIdentityGroupRight(string XmlString)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroupRight_BulkUpdate;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", XmlString)
                };
                DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                     sqlparam.StoreProcedureParam);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        #endregion

        #region INSERT FUNCTIONS

        public DataSet InsertIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroup_Insert;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@groupName", ObjIdentityGroup.GroupName),
                    new MySqlParameter("@groupDesc", ObjIdentityGroup.GroupDescription),
                    new MySqlParameter("@isValid", ObjIdentityGroup.IsValid),
                    new MySqlParameter("@createdBy", ObjIdentityGroup.CreatedBy),
                    new MySqlParameter("@createdOn", ObjIdentityGroup.CreatedOn)
                };
                var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(),
                     sqlparam.StoreProcedureParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void InsertIdentityGroupRight(string XmlString)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroupRight_BulkInsert;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", XmlString)
                };
                DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                     sqlparam.StoreProcedureParam);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        #endregion

        #region OTHER FUNCTIONS

        public void MarkGroupInvalid(int GroupId)
        {
            try
            {
                var sqlparam = new MySqlSpParam();
                sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroup_MarkInvalid;
                sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@groupId", GroupId)
                };
                DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                     sqlparam.StoreProcedureParam);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        #endregion

    }
}
