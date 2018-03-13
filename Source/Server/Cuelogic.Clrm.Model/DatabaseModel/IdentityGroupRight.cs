using Cuelogic.Clrm.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Model.DatabaseModel
{
    public class IdentityGroupRight
    {
        public IdentityGroupRight()
        {
            BooleanRight = new BooleanRights();
        }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int RightId { get; set; }
        public int Action { get; set; }
        public bool IsValid { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string RightTitle { get; set; }

        public string CreatedByName { get; set; }
        public string UpdatedByName { get; set; }

        public BooleanRights BooleanRight { get; set; }

        public void SetDecimalRights()
        {
            int DecVal = 0;
            if (BooleanRight.Read == true)
                DecVal += 4;
            if (BooleanRight.Write == true)
                DecVal += 2;
            if (BooleanRight.Delete == true)
                DecVal += 1;
            Action = DecVal;
        }

        public void SetBooleanRights(int decimalNumber)
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
            BooleanRight= objBinaryRights;
        }
    }
}
