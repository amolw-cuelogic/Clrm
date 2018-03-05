using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.ProjectType
{
    public interface IMasterProjectTypeService
    {
        string GetList(SearchParam searchParam);

        MasterProjectType GetItem(int masterProjectTypeId);

        void Save(MasterProjectType masterProjectType, UserContext userCtx);

        void Delete(int masterProjectTypeId);
    }
}
