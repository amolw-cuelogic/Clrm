﻿using System;
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
        public DataSet GetMasterSkill(int masterSkillId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_Get;
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
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_GetList;
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
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_Insert;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@skill", masterSkill.Skill),
                    new MySqlParameter("@isValid", masterSkill.IsValid),
                    new MySqlParameter("@createdBy", masterSkill.CreatedBy),
                    new MySqlParameter("@createdOn", masterSkill.CreatedOn)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void MarkMasterSkillInvalid(int masterSkillId)
        {
            var sqlParam = new MySqlSpParam();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_MarkInvalid;
            sqlParam.StoreProcedureParam = new MySqlParameter[] {
                    new MySqlParameter("@MasterSkillId", masterSkillId)
                };
            DataAccessHelper.ExecuteNonQuery(sqlParam.ToSqlCommand(),
                 sqlParam.StoreProcedureParam);
        }

        public void UpdateMasterSkill(MasterSkill masterSkill)
        {
            var sqlparam = new MySqlSpParam();
            sqlparam.StoreProcedureName = AppConstants.StoreProcedure.spMasterSkill_Update;
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
