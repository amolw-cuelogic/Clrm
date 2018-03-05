using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.Client
{
    public interface IMasterClientRepository
    {
        DataSet GetMasterClientList(SearchParam searchParam);
        MasterClient GetMasterClient(int masterClientId);
        void AddOrUpdateMasterClient(MasterClient masterClient, UserContext userCtx);
        void MarkMasterClientInvalid(int masterClientId);
    }
}
