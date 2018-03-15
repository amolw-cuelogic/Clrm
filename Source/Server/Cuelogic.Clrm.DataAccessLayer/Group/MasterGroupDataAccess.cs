using Cuelogic.Clrm.Common;
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

namespace Cuelogic.Clrm.DataAccessLayer.Group
{
    public class MasterGroupDataAccess : IMasterGroupDataAccess
    {

        #region GET FUNCTIONS

        public DataSet GetIdentityGroupList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", searchParam.FilterText),
                    new MySqlParameter("@RecordFrom", recordFrom),
                    new MySqlParameter("@RecordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetIdentityGroup(int groupId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@GroupId", groupId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetIdentityGroupRights(int groupId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroupRight_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@GroupId", groupId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetIdentityRightList()
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityRight_Get;
            sqlParam.StoreProcedureParam = null;
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand());
            return ds;
        }

        #endregion

        #region UPDATE FUNCTIONS

        public void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_Update;
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

        public void UpdateIdentityGroupRight(string XmlString)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroupRight_BulkUpdate;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", XmlString)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

        #region INSERT FUNCTIONS

        public DataSet InsertIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_Insert;
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

        public void InsertIdentityGroupRight(string XmlString)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroupRight_BulkInsert;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@xmltext", XmlString)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

        #region OTHER FUNCTIONS

        public void MarkGroupInvalid(int GroupId, int employeeId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_MarkInvalid;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@groupId", GroupId),
                    new MySqlParameter("@employeeId", employeeId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

    }
}
