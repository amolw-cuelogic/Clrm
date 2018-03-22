using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class CustomException
    {
        [Serializable]
        public class BadRequest : Exception
        {
            public BadRequest(string errorMessage)
                 : base(errorMessage)
            {
                
            }
        }

        [Serializable]
        public class ClientWarning : Exception
        {
            public ClientWarning(string errorMessage)
                 : base(errorMessage, 
                       new Exception(Helper.ComposeClientMessage(AppConstants.MessageType.Warning,errorMessage)))
            {

            }
        }

        [Serializable]
        public class NoContentFound : Exception
        {
            public NoContentFound(string errorMessage)
                 : base(errorMessage,
                       new Exception(Helper.ComposeClientMessage(AppConstants.MessageType.Warning, errorMessage)))
            {

            }
        }
    }
}
