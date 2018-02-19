using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;

namespace Cuelogic.Clrm.DataAccessLayer.Skill
{
    public class MasterSkillDataAccess : IMasterSkillDataAccess
    {
        public DataSet GetMasterSkill(int MasterSkillId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_Get;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterSkillId", MasterSkillId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterSkillList(SearchParam objSearchParam)
        {
            var RecordFrom = objSearchParam.Page * objSearchParam.Show;
            var Show = objSearchParam.Show;

            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_GetList;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", objSearchParam.FilterText),
                    new MySqlParameter("@RecordFrom", RecordFrom),
                    new MySqlParameter("@RecordTill", Show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlparam.ToSqlCommand(), sqlparam.StoreProcedureParam);
            return ds;
        }

        public void InsertMasterSkill(MasterSkill ObjMasterSkill)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_Insert;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@skill", ObjMasterSkill.Skill),
                    new MySqlParameter("@isValid", ObjMasterSkill.IsValid),
                    new MySqlParameter("@createdBy", ObjMasterSkill.CreatedBy),
                    new MySqlParameter("@createdOn", ObjMasterSkill.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void MarkMasterSkillInvalid(int MasterSkillId)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_MarkInvalid;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterSkillId", MasterSkillId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }

        public void UpdateMasterSkill(MasterSkill ObjMasterSkill)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_Update;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterSkillId", ObjMasterSkill.Id),
                    new MySqlParameter("@skill", ObjMasterSkill.Skill),
                    new MySqlParameter("@isValid", ObjMasterSkill.IsValid),
                    new MySqlParameter("@updatedby", ObjMasterSkill.UpdatedBy),
                    new MySqlParameter("@updatedon", ObjMasterSkill.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }
    }
}
