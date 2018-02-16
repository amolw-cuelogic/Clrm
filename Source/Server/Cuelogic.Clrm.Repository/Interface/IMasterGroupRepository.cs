using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Interface
{
    public interface IMasterGroupRepository
    {
        DataSet GetIdentityGroupList(SearchParam objSearchParam);

        IdentityGroup GetGroup(int GroupId);

        void SaveIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx);

        void UpdateIdentityGroup(IdentityGroup ObjIdentityGroup, UserContext userCtx);

        void MarkGroupInvalid(int GroupId);
    }
}
