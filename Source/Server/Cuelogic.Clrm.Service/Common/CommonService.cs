using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Repository.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Common
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService()
        {
            _commonRepository = new CommonRepository();
        }
        public Employee GetEmployeeDetails(string emailId)
        {
            var data = _commonRepository.GetEmployeeDetails(emailId);
            return data;
        }
    }
}
