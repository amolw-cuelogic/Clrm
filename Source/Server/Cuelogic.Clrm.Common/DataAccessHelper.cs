using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.Common
{
    public static class DataAccessHelper
    {
        private static ILog applogManager = AppLogManager.GetLogger();
        private static string connectionString = string.Empty;

        static DataAccessHelper()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionString"].ConnectionString;

            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }



        public static void ExecuteNonQuery(string commandText, MySqlParameter[] commandParameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                if (commandParameters == null)
                    commandParameters = new MySqlParameter[] { new MySqlParameter() };
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    command.Parameters.AddRange(commandParameters.ToArray());
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

        public static DataSet ExecuteQuery(string commandText, MySqlParameter[] commandParameters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                if (commandParameters == null)
                    commandParameters = new MySqlParameter[] { new MySqlParameter() };
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand(commandText, connection))
                {
                    DataSet ds = new DataSet();
                    command.CommandType = commandType;
                    command.Parameters.AddRange(commandParameters);
                    using (var da = new MySqlDataAdapter(command))
                    {
                        da.Fill(ds);
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
