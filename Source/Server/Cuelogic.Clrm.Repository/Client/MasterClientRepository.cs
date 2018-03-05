using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.DataAccessLayer.Client;

namespace Cuelogic.Clrm.Repository.Client
{
    public class MasterClientRepository : IMasterClientRepository
    {
        private readonly IMasterClientDataAccess _masterClientDataAccess;
        public MasterClientRepository()
        {
            _masterClientDataAccess = new MasterClientDataAccess();
        }

        public void AddOrUpdateMasterClient(MasterClient masterClient, UserContext userCtx)
        {
            masterClient.CreatedBy = userCtx.UserId;
            masterClient.UpdatedBy = userCtx.UserId;
            masterClient.CreatedOn = DateTime.Now.ToMySqlDateString();
            masterClient.UpdatedOn = DateTime.Now.ToMySqlDateString();
            _masterClientDataAccess.AddOrUpdateMasterClient(masterClient);
        }

        public MasterClient GetMasterClient(int masterClientId)
        {
            if (masterClientId != 0)
            {
                var ds = _masterClientDataAccess.GetMasterClient(masterClientId);
                var masterClient = ds.Tables[0].ToModel<MasterClient>();
                return masterClient;
            }
            else
            {
                return new MasterClient();
            }
        }

        public DataSet GetMasterClientList(SearchParam searchParam)
        {
            var ds = _masterClientDataAccess.GetMasterClientList(searchParam);
            return ds;
        }

        public void MarkMasterClientInvalid(int masterClientId)
        {
            _masterClientDataAccess.MarkMasterClientInvalid(masterClientId);
        }
    }
}
