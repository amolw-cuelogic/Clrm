using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using Cuelogic.Clrm.DataAccessLayer.DataAccess;
using log4net;

namespace Cuelogic.Clrm.Repository.Repository
{
    public class MasterGroupRepository : IMasterGroupRepository
    {
        private readonly IMasterGroupDataAccess _masterGroupDataAccess;
        private ILog applogManager = AppLogManager.GetLogger();
        public MasterGroupRepository()
        {
            _masterGroupDataAccess = new MasterGroupDataAccess();
        }
        public DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            try
            {
                var ds = _masterGroupDataAccess.GetIdentityGroupList(objSearchParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public IdentityGroup GetGroup(int GroupId)
        {
            try
            {
                var GroupObj = new IdentityGroup();
                if (GroupId != 0)
                {
                    var GroupDs = _masterGroupDataAccess.GetIdentityGroup(GroupId);
                    var GroupRightDs = _masterGroupDataAccess.GetIdentityGroupRights(GroupId);
                    GroupObj = GroupDs.Tables[0].ToModel<IdentityGroup>();
                    var GroupRightLlist = GroupRightDs.Tables[0].ToList<IdentityGroupRight>();
                    foreach (var item in GroupRightLlist)
                    {
                        item.SetBooleanRights(item.Action);
                    }
                    GroupObj.GroupRight = GroupRightLlist;
                }
                else
                {
                    var RightDs = _masterGroupDataAccess.GetIdentityRightList();
                    var RightObj = RightDs.Tables[0].ToList<IdentityRight>();
                    foreach (var item in RightObj)
                    {
                        var temp = new IdentityGroupRight();
                        temp.Action = 4; //Set read right by default
                        temp.IsValid = true;
                        temp.RightId = item.Id;
                        temp.RightTitle = item.RightTitle;
                        temp.SetBooleanRights(temp.Action);
                        GroupObj.GroupRight.Add(temp);
                    }
                }
                return GroupObj;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void SaveIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            try
            {
                ObjIdentityGroup.CreatedBy = userCtx.UserId;
                ObjIdentityGroup.CreatedOn = DateTime.Now.ToMySqlDateString();
                var ds = _masterGroupDataAccess.InsertIdentityGroup(ObjIdentityGroup);
                var LatestId = ds.Tables[0].ToId();
                foreach (var item in ObjIdentityGroup.GroupRight)
                {
                    item.GroupId = LatestId;
                    item.CreatedBy = userCtx.UserId; ;
                    item.CreatedOn = DateTime.Now.ToMySqlDateString();
                    item.IsValid = true;
                    item.SetDecimalRights();
                }
                var XmlString = Helper.ObjectToXml(ObjIdentityGroup.GroupRight);
                _masterGroupDataAccess.InsertIdentityGroupRight(XmlString);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx)
        {
            try
            {
                ObjIdentityGroup.UpdatedBy = userCtx.UserId;
                ObjIdentityGroup.UpdatedOn = DateTime.Now.ToMySqlDateString();
                _masterGroupDataAccess.UpdateIdentityGroup(ObjIdentityGroup);
                foreach (var item in ObjIdentityGroup.GroupRight)
                {
                    item.UpdatedBy = userCtx.UserId;
                    item.UpdatedOn = DateTime.Now.ToMySqlDateString();
                    item.SetDecimalRights();
                }
                var XmlString = Helper.ObjectToXml(ObjIdentityGroup.GroupRight);
                _masterGroupDataAccess.UpdateIdentityGroupRight(XmlString);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void MarkGroupInvalid(int GroupId)
        {
            try
            {
                _masterGroupDataAccess.MarkGroupInvalid(GroupId);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
