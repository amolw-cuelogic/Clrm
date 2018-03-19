﻿using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuelogic.Clrm.MockData
{
    public class MasterGroupMockData
    {
        public static string GetMockDataMasterGroupList()
        {
            return "[{'Id':109,'GroupName':'Super Admin','GroupDescription':'Super Admin','IsValid':'Yes','Name':'Amol Wabale','CreatedOn':'01/03/2018'},{'Id':111,'GroupName':'User','GroupDescription':'User','IsValid':'Yes','Name':'Amol Wabale','CreatedOn':'06/03/2018'}]";
        }

        public static DataSet GetMockDataMasterGroupListDataset()
        {
            var ds = new DataSet();
            var jsonString = GetMockDataMasterGroupList();
            var dt = Helper.JsonStringToDatatable(jsonString);
            ds.Tables.Add(dt);
            return ds;
        }

        public static DataSet GetMockDataEmployeeGroupRightDataset()
        {
            var ds = new DataSet();
            var data = GetMockDataIdentityGroupRightList();
            var jsonString = Helper.ObjectToJson(data);
            var dt = Helper.JsonStringToDatatable(jsonString);
            dt.Columns.Remove("BooleanRight");
            ds.Tables.Add(dt);
            return ds;
        }

        public static List<IdentityGroupRight> GetMockDataIdentityGroupRightList()
        {
            var xml = "<?xml version='1.0' encoding='utf-16'?> <ArrayOfIdentityGroupRight xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'> <IdentityGroupRight> <Id>66</Id> <GroupId>115</GroupId> <RightId>400</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>67</Id> <GroupId>115</GroupId> <RightId>401</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>68</Id> <GroupId>115</GroupId> <RightId>402</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>69</Id> <GroupId>115</GroupId> <RightId>403</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>70</Id> <GroupId>115</GroupId> <RightId>200</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>71</Id> <GroupId>115</GroupId> <RightId>201</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>72</Id> <GroupId>115</GroupId> <RightId>202</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>73</Id> <GroupId>115</GroupId> <RightId>300</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>74</Id> <GroupId>115</GroupId> <RightId>301</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>75</Id> <GroupId>115</GroupId> <RightId>302</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>76</Id> <GroupId>115</GroupId> <RightId>303</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>77</Id> <GroupId>115</GroupId> <RightId>304</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> <IdentityGroupRight> <Id>78</Id> <GroupId>115</GroupId> <RightId>305</RightId> <Action>7</Action> <IsValid>true</IsValid> <CreatedBy>1</CreatedBy> <CreatedOn>2018-01-01</CreatedOn> <UpdatedBy>0</UpdatedBy> <BooleanRight> <Read>true</Read> <Write>true</Write> <Delete>true</Delete> </BooleanRight> </IdentityGroupRight> </ArrayOfIdentityGroupRight>";
            var obj = Helper.XmlToObject(xml, typeof(List<IdentityGroupRight>)) as List<IdentityGroupRight>;
            return obj;
        }

        public static IdentityGroup GetMockDataMasterGroup()
        {
            var data = new IdentityGroup();
            data.Id = 1;
            data.GroupName = "Super Admin";
            data.GroupDescription = "Super Admin";
            data.CreatedBy = 1;
            data.CreatedOn = "2018-02-02";
            data.UpdatedBy = 1;
            data.UpdatedOn = "2018-02-02";
            return data;
        }
    }
}
