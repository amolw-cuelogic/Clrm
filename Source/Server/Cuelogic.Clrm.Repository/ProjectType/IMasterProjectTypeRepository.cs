using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Repository.ProjectType
{
    public interface IMasterProjectTypeRepository
    {
        DataSet GetMasterProjectTypeList(SearchParam searchParam);
        MasterProjectType GetMasterProjectType(int masterProjectTypeId);
        DataSet GetMasterProjectTypeValidList();
        void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType, UserContext userCtx);
        void MarkMasterProjectTypeInvalid(int masterProjectTypeId);
    }
}
