using System;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess.MySql;
using static Cuelogic.Clrm.Common.AppConstants;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository
{
    public class MasterSkillRepository : IMasterSkillRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterSkillRepository()
        {
            _dataAccess = new MySqlDataAccess();
        }
        public DataSet GetMasterSkill(int masterSkillId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@MasterSkillId", Value = masterSkillId }
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetMasterSkillList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void MarkMasterSkillInvalid(int masterSkillId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@MasterSkillId", Value = masterSkillId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void SaveMasterSkill(MasterSkill masterSkill)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_Insert;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramSkill", Value=masterSkill.Skill },
                    new Param() { Key="@paramIsValid", Value=masterSkill.IsValid },
                    new Param() { Key="@paramCreatedBy", Value=masterSkill.CreatedBy },
                    new Param() { Key="@paramCreatedOn", Value=masterSkill.CreatedOn }
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void UpdateMasterSkill(MasterSkill masterSkill)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.MasterSkill_Update;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@paramMasterSkillId", Value=masterSkill.Id },
                    new Param() { Key="@paramSkill", Value=masterSkill.Skill },
                    new Param() { Key="@paramIsValid", Value=masterSkill.IsValid },
                    new Param() { Key="@paramCreatedBy", Value=masterSkill.UpdatedBy },
                    new Param() { Key="@paramCreatedOn", Value=masterSkill.UpdatedOn }
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
    }
}
