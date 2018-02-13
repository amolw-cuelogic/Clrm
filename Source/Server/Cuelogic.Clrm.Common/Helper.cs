using Cuelogic.Clrm.Model;
using Cuelogic.Clrm.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public class Helper
    {
        public static BooleanRights GetBooleanRights(int decimalNumber)
        {
            var objBinaryRights = new BooleanRights();
            string result = string.Empty;
            int remainder;
            int i = 0;
            while (decimalNumber > 0)
            {
                i++;
                remainder = decimalNumber % 2;
                decimalNumber /= 2;
                result = remainder.ToString() + result;
                if (i == 1)
                    objBinaryRights.Delete = (remainder == 1) ? true : false;
                if (i == 2)
                    objBinaryRights.Write = (remainder == 1) ? true : false;
                if (i == 3)
                    objBinaryRights.Read = (remainder == 1) ? true : false;
            }
            Console.WriteLine("Binary:  {0}", result);
            return objBinaryRights;
        }
    }
}
