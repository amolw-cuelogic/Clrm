using Cuelogic.Clrm.Model.DatabaseModel;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cuelogic.Clrm.Model.CommonModel;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.MockData;
using Cuelogic.Clrm.DataAccess.Interface;
using Cuelogic.Clrm.DataAccess;

namespace Cuelogic.Clrm.DataAccess.Tests
{
    [TestClass]
    public class MySqlDataAccessTest
    {
        private IDataAccess _dataAccess = new MySqlDataAccess();
        private const string _testCategory = "DataAccess - MySql";

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMySqlDataAccessExecuteNonQuery()
        {
            //ARRANGE
            var sqlParam = new DataAccessParameter();
            sqlParam.SqlQuery = "SHOW SCHEMAS";

            //ACT
            _dataAccess.ExecuteNonQuery(sqlParam);

            //ASSERT
        }

        [TestMethod]
        [TestCategory(_testCategory)]
        public void TestMySqlDataAccessExecuteQuery()
        {
            //ARRANGE
            var sqlParam = new DataAccessParameter();
            sqlParam.SqlQuery = "SHOW SCHEMAS";

            //ACT
            var ds = _dataAccess.ExecuteQuery(sqlParam);
            var dt = ds.Tables[0];
            var jsonString = dt.ToJsonString();

            //ASSERT
            Assert.IsNotNull(ds);
            Assert.IsTrue(jsonString != "");
            Assert.IsInstanceOfType(ds, typeof(DataSet));
            Assert.IsInstanceOfType(dt, typeof(DataTable));
            Assert.IsInstanceOfType(jsonString, typeof(string));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }


    }

}
