using System.Data;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Common;
using MySql.Data.MySqlClient;
using Cuelogic.Clrm.DataAccess.Interface;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MasterSkillDataAccessMySql : IMasterSkillDataAccess
    {
        public DataSet GetMasterSkill(int masterSkillId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_Get;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterSkillId", masterSkillId)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public DataSet GetMasterSkillList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_GetList;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@FilterText", searchParam.FilterText),
                    new MySqlParameter("@RecordFrom", recordFrom),
                    new MySqlParameter("@RecordTill", show)
                };
            var ds = DataAccessHelper.ExecuteQuery(sqlParam.ToSqlCommand(), sqlParam.StoreProcedureParam);
            return ds;
        }

        public void InsertMasterSkill(MasterSkill masterSkill)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_Insert;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@skill", masterSkill.Skill),
                    new MySqlParameter("@isValid", masterSkill.IsValid),
                    new MySqlParameter("@createdBy", masterSkill.CreatedBy),
                    new MySqlParameter("@createdOn", masterSkill.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void MarkMasterSkillInvalid(int masterSkillId, int employeeId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterSkillId", masterSkillId),
                    new MySqlParameter("@employeeId", employeeId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void UpdateMasterSkill(MasterSkill masterSkill)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_Update;
            sqlparam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@masterSkillId", masterSkill.Id),
                    new MySqlParameter("@skill", masterSkill.Skill),
                    new MySqlParameter("@isValid", masterSkill.IsValid),
                    new MySqlParameter("@updatedby", masterSkill.UpdatedBy),
                    new MySqlParameter("@updatedon", masterSkill.UpdatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlparam.ToSqlCommand(),
                 sqlparam.StoreProcedureParam);
        }
    }
}
