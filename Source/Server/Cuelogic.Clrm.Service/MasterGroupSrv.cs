using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service
{
    public static class MasterGroupSrv
    {
        public static DataSet GetIdentityGroupList()
        {
            DataSet list = MasterGroupRepo.GetIdentityGroupList();
            var temp = list.Tables[0].ToModel<IdentityGroup>();
            return list;
        }

        
    }
}
