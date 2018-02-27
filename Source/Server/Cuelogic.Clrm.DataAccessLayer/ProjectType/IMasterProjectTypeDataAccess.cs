using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccessLayer.ProjectType
{
    public interface IMasterProjectTypeDataAccess
    {
        DataSet GetMasterProjectTypeList(SearchParam searchParam);
        DataSet GetMasterProjectType(int masterProjectTypeId);
        DataSet GetMasterProjectTypeValidList();
        void AddOrUpdateMasterProjectType(MasterProjectType masterProjectType);
        void MarkMasterProjectTypeInvalid(int masterProjectTypeId);
    }
}
