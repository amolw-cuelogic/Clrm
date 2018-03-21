using Cuelogic.Clrm.Common;
using System.Data;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;
using System.Collections.Generic;

namespace Cuelogic.Clrm.Repository
{
    public class MasterGroupRepository : IMasterGroupRepository
    {
        private readonly IDataAccess _dataAccess;
        public MasterGroupRepository()
        {
            _dataAccess = DataAccessFactory.GetDataAccess();
        }
        public DataSet GetIdentityGroupList(SearchParam searchParam)
        {
            var recordFrom = searchParam.Page * searchParam.Show;
            var show = searchParam.Show;

            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_GetList;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@filterText", Value=searchParam.FilterText },
                    new Param() { Key="@recordFrom", Value= recordFrom },
                    new Param() { Key="@recordTill", Value= show } });

            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetGroup(int groupId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@GroupId", Value=groupId }
            });

            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetIdentityGroupRights(int groupId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroupRight_Get;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@GroupId", Value=groupId }
            });

            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet GetIdentityRightList()
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityRight_Get;
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public DataSet SaveIdentityGroup(IdentityGroup identityGroup)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_Insert;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@grpn", Value=identityGroup.GroupName },
                    new Param() { Key="@groupdesc", Value=identityGroup.GroupDescription },
                    new Param() { Key="@valid", Value=identityGroup.IsValid },
                    new Param() { Key="@createdBy", Value=identityGroup.CreatedBy },
                    new Param() { Key="@createdOn", Value=identityGroup.CreatedOn },
            });
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            return ds;
        }

        public void SaveIdentityGroupRight(string xmlString)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroupRight_BulkInsert;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmltext", Value= xmlString }
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void UpdateIdentityGroup(IdentityGroup identityGroup)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_Update;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@GroupId", Value=identityGroup.Id },
                    new Param() { Key="@grpn", Value=identityGroup.GroupName },
                    new Param() { Key="@groupdesc", Value=identityGroup.GroupDescription },
                    new Param() { Key="@valid", Value=identityGroup.IsValid },
                    new Param() { Key="@updatedby", Value=identityGroup.UpdatedBy },
                    new Param() { Key="@updatedon", Value=identityGroup.UpdatedOn },
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void UpdateIdentityGroupRight(string xmlString)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroupRight_BulkUpdate;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@xmltext", Value= xmlString }
            });
            _dataAccess.ExecuteNonQuery(sqlParam);
        }

        public void MarkGroupInvalid(int groupId, int employeeId)
        {
            var sqlParam = new DataAccessParameter();
            sqlParam.StoreProcedureName = AppConstants.StoreProcedure.IdentityGroup_MarkInvalid;
            sqlParam.StoreProcedureParameter.AddRange(new List<Param>() {
                    new Param() { Key="@groupId", Value=groupId },
                    new Param() { Key="@employeeId", Value=employeeId }});
            _dataAccess.ExecuteNonQuery(sqlParam);
        }
        
    }
}
