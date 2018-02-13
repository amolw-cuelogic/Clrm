using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cuelogic.Clrm.Api;
using Cuelogic.Clrm.Api.Controllers;
using Cuelogic.Clrm.DataAccessLayer;
using Cuelogic.Clrm.Model;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;

namespace Cuelogic.Clrm.Api.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var obj = new SearchParam();
            obj.FilterText = "";
            obj.Show = 9;
            obj.Page = 2;
            MySqlParameter[] para = new MySqlParameter[]
            {
                new MySqlParameter("@FilterText",obj.FilterText),
                new MySqlParameter("@RecordFrom",0),
                new MySqlParameter("@RecordTill",10)
            };
            var objDa = new DataAccessHelper();
           
            //var ds = DataAccessHelper.ExecuteQuery("spGetIdentityGroupList('"+ obj.FilterText + "','"++"','"++"')",
            //    CommandType.Text, //Even though it is store procedure, Command type is text, MySql does not accepts c# command type as storeprocedure
            //    para);

            var temp = MasterGroupDa.GetIdentityGroupList(obj);
            
        }

        [TestMethod]
        public void TestConnection()
        {



        }
    }
}
