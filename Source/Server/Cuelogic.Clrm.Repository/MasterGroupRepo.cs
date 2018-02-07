using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository
{
    public class MasterGroupRepo
    {
        public static DataSet GetIdentityGroupList(SearchParam objSearchParam)
        {
            var list = MasterGroupDa.GetIdentityGroupList(objSearchParam);
            return list;
        }
    }
}
