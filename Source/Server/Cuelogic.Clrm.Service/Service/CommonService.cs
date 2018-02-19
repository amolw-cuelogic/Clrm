using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.DatabaseModel;
using Cuelogic.Clrm.Repository;
using Cuelogic.Clrm.Repository.Interface;
using Cuelogic.Clrm.Repository.Repository;
using Cuelogic.Clrm.Service.Interface;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Service.Service
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        public CommonService()
        {
            _commonRepository = new CommonRepository();
        }
        public Employee GetEmployeeDetails(string EmailId)
        {
            var data = _commonRepository.GetEmployeeDetails(EmailId);
            return data;
        }
    }
}
