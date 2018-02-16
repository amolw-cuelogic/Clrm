using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
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

        #region GET FUNCTIONS

        public DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            var RecordFrom = objSearchParam.Page * objSearchParam.Show;
            var Show = objSearchParam.Show;

            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetIdentityGroupList;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@FilterText", objSearchParam.FilterText),
                new MySqlParameter("@RecordFrom", RecordFrom),
                new MySqlParameter("@RecordTill", Show)
            };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetIdentityGroup(int GroupId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetIdentityGroup;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@GroupId", GroupId)
            };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetIdentityGroupRights(int GroupId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetIdentityGroupRights;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@GroupId", GroupId)
            };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetIdentityRightList()
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spGetIdentityRight;
            sqlparam.StoreProcedureParam = null;
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand());
            return ds;
        }

        #endregion

        #region UPDATE FUNCTIONS

        public void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spUpdateIdentityGroup;
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
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spBulkUpdateIdentityGroupRight;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@xmltext", XmlString)
            };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

        #region UPDATE FUNCTIONS

        public DataSet InsertIdentityGroup(IdentityGroup ObjIdentityGroup)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spInsertIdentityGroup;
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
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spBulkInsertIdentityGroupRight;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@xmltext", XmlString)
            };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

        #region OTHER FUNCTIONS

        public void MarkGroupInvalid(int GroupId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spIdentityGroupMarkInvalid;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                new MySqlParameter("@groupId", GroupId)
            };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        #endregion

    }
}
