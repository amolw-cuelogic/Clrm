using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.DataAccess.MySql
{
    public class MySqlDataAccess : IDataAccess
    {
        private static ILog applogManager = AppLogManager.GetLogger();
        private static string connectionString = string.Empty;

        public MySqlDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                    connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void ExecuteNonQuery(DataAccessParameter dataAccessParameter)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand(dataAccessParameter.ToSqlCommandd(), connection))
                {
                    command.CommandType = CommandType.Text;
                    if (dataAccessParameter.StoreProcedureParameter != null)
                    {
                        for (var i = 0; i < dataAccessParameter.StoreProcedureParameter.Count; i++)
                            command.Parameters.AddWithValue(dataAccessParameter.StoreProcedureParameter[i].Key, 
                                dataAccessParameter.StoreProcedureParameter[i].Value);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public DataSet ExecuteQuery(DataAccessParameter dataAccessParameter)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand(dataAccessParameter.ToSqlCommandd(), connection))
                {
                    DataSet ds = new DataSet();
                    command.CommandType = CommandType.Text;
                    if (dataAccessParameter.StoreProcedureParameter != null)
                    {
                        for (var i = 0; i < dataAccessParameter.StoreProcedureParameter.Count; i++)
                            command.Parameters.AddWithValue(dataAccessParameter.StoreProcedureParameter[i].Key, 
                                dataAccessParameter.StoreProcedureParameter[i].Value);
                    }
                    using (var da = new MySqlDataAdapter(command))
                    {
                        da.Fill(ds);
                    }
                    if (ds.Tables.Count > 0 && dataAccessParameter.TableName != null)
                    {
                        if (dataAccessParameter.TableName.Count > 0)
                        {
                            for (var i = 0; i < ds.Tables.Count; i++)
                            {
                                ds.Tables[i].TableName = dataAccessParameter.TableName[i];
                            }
                        }
                    }
                    connection.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
