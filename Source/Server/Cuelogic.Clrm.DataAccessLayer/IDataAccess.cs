using Cuelogic.Clrm.Model.CommonModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public interface IDataAccess
    {
        void ExecuteNonQuery(DataAccessParameter dataAccessParameter);

        DataSet ExecuteQuery(DataAccessParameter dataAccessParameter);
    }
}
