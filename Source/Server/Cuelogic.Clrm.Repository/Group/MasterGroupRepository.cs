﻿using Cuelogic.Clrm.DataAccessLayer;
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
using log4net;
using Cuelogic.Clrm.DataAccessLayer.Group;

namespace Cuelogic.Clrm.Repository.Group
{
    public class MasterGroupRepository : IMasterGroupRepository
    {
        private readonly IMasterGroupDataAccess _masterGroupDataAccess;
        public MasterGroupRepository()
        {
            _masterGroupDataAccess = new MasterGroupDataAccess();
        }
        public DataSet GetIdentityGroupList(SearchParam searchParam)
        {
            var ds = _masterGroupDataAccess.GetIdentityGroupList(searchParam);
            return ds;
        }

        public IdentityGroup GetGroup(int groupId)
        {
            var identityGroup = new IdentityGroup();
            if (groupId != 0)
            {
                var GroupDs = _masterGroupDataAccess.GetIdentityGroup(groupId);
                var GroupRightDs = _masterGroupDataAccess.GetIdentityGroupRights(groupId);
                identityGroup = GroupDs.Tables[0].ToModel<IdentityGroup>();
                var GroupRightLlist = GroupRightDs.Tables[0].ToList<IdentityGroupRight>();
                foreach (var item in GroupRightLlist)
                {
                    item.SetBooleanRights(item.Action);
                }
                identityGroup.GroupRight = GroupRightLlist;
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
                    identityGroup.GroupRight.Add(temp);
                }
            }
            return identityGroup;
        }

        public void SaveIdentityGroup(IdentityGroup identityGroup, UserContext userCtx)
        {
            identityGroup.CreatedBy = userCtx.UserId;
            identityGroup.CreatedOn = DateTime.Now.ToMySqlDateString();
            var ds = _masterGroupDataAccess.InsertIdentityGroup(identityGroup);
            var LatestId = ds.Tables[0].ToId();
            foreach (var item in identityGroup.GroupRight)
            {
                item.GroupId = LatestId;
                item.CreatedBy = userCtx.UserId; ;
                item.CreatedOn = DateTime.Now.ToMySqlDateString();
                item.IsValid = true;
                item.SetDecimalRights();
            }
            var XmlString = Helper.ObjectToXml(identityGroup.GroupRight);
            _masterGroupDataAccess.InsertIdentityGroupRight(XmlString);

        }

        public void UpdateIdentityGroup(IdentityGroup identityGroup, UserContext userCtx)
        {
            identityGroup.UpdatedBy = userCtx.UserId;
            identityGroup.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterGroupDataAccess.UpdateIdentityGroup(identityGroup);
            foreach (var item in identityGroup.GroupRight)
            {
                item.UpdatedBy = userCtx.UserId;
                item.UpdatedOn = DateTime.Now.ToMySqlDateString();
                item.SetDecimalRights();
            }
            var XmlString = Helper.ObjectToXml(identityGroup.GroupRight);
            _masterGroupDataAccess.UpdateIdentityGroupRight(XmlString);

        }

        public void MarkGroupInvalid(int groupId)
        {
            _masterGroupDataAccess.MarkGroupInvalid(groupId);
        }
    }
}
