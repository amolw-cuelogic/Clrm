using Cuelogic.Clrm.Model.CommonModel;
using System.Data;

namespace Cuelogic.Clrm.DataAccess.Interface
{
    public interface IDataAccess
    {
        void ExecuteNonQuery(DataAccessParameter dataAccessParameter);

        DataSet ExecuteQuery(DataAccessParameter dataAccessParameter);
    }
}
