using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Group
{
    public interface IMasterGroup
    {
        string GetList(SearchParam objSearchParam);

        IdentityGroup GetItem(int GroupId);

        void Save(IdentityGroup ObjIdentityGroup, UserContext userCtx);

        void Delete(int GroupId);

    }
}
