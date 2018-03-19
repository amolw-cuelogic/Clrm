using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.MockData
{
    public class CommonMockData
    {
        public static string GetUserRights()
        {
            return "<?xml version='1.0' encoding='utf-16'?> <ArrayOfIdentityGroupRight xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <IdentityGroupRight> <Id>1</Id> <GroupId>115</GroupId> <RightId>202</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>2</Id> <GroupId>115</GroupId> <RightId>200</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>3</Id> <GroupId>115</GroupId> <RightId>201</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>4</Id> <GroupId>115</GroupId> <RightId>403</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>5</Id> <GroupId>115</GroupId> <RightId>400</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>6</Id> <GroupId>115</GroupId> <RightId>305</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>7</Id> <GroupId>115</GroupId> <RightId>301</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>8</Id> <GroupId>115</GroupId> <RightId>302</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>9</Id> <GroupId>115</GroupId> <RightId>303</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>10</Id> <GroupId>115</GroupId> <RightId>304</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>11</Id> <GroupId>115</GroupId> <RightId>300</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>12</Id> <GroupId>115</GroupId> <RightId>401</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>13</Id> <GroupId>115</GroupId> <RightId>402</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-03-09</CreatedOn> <UpdatedBy>1</UpdatedBy> <UpdatedOn>2018-03-09</UpdatedOn> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> </ArrayOfIdentityGroupRight>";
        }

        public static ClaimsIdentity GetUserClaimsIdentity()
        {
            var customIdentity = new ClaimsIdentity("");
            customIdentity.AddClaim(new Claim("Email", "amol.wabale@gmail.com"));
            customIdentity.AddClaim(new Claim("Id", "1"));
            customIdentity.AddClaim(new Claim("UserName", "Amol Wabale"));
            customIdentity.AddClaim(new Claim("Rights", GetUserRights()));
            return customIdentity;
        }

        public static UserContext GetMockDataUserContext()
        {
            var strRight = GetUserRights();
            var data = new UserContext();
            data.EmailId = "amol.wabale@cuelogic.com";
            data.UserId = 1;
            data.UserName = "Amol Wabale";
            data.Rights = Helper.XmlToObject(strRight, typeof(List<IdentityGroupRight>)) as List<IdentityGroupRight>;
            return data;
        }

        public static DataSet GetMasterCurrencyDataSet()
        {
            var ds = new DataSet();
            var data = GetMasterCurrency();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }
        public static List<MasterCurrency> GetMasterCurrency()
        {
            var data = new List<MasterCurrency>();

            var obj1 = new MasterCurrency();
            obj1.Id = 1;
            obj1.CountryId = 1;
            obj1.Currency = "Dollar";
            data.Add(obj1);

            var obj2 = new MasterCurrency();
            obj2.Id = 1;
            obj2.CountryId = 2;
            obj2.Currency = "Rupee";
            data.Add(obj2);

            return data;
        }
    }
}
