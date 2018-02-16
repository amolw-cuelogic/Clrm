﻿using Cuelogic.Clrm.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuelogic.Clrm.Common;
using Cuelogic.Clrm.Model.CommonModel;
using Cuelogic.Clrm.Model.DatabaseModel;
using System.Data;
using Cuelogic.Clrm.DataAccessLayer.Interface;
using log4net;
using Cuelogic.Clrm.DataAccessLayer.DataAccess;

namespace Cuelogic.Clrm.Repository.Repository
{
    public class MasterDepartmentRepository : IMasterDepartmentRepository
    {
        private ILog applogManager = AppLogManager.GetLogger();
        private readonly IMasterDepartmentDataAccess _masterDepartmentDataAccess;

        public MasterDepartmentRepository()
        {
            _masterDepartmentDataAccess = new MasterDepartmentDataAccess();
        }
        public MasterDepartment GetMasterDepartment(int MasterDepartmentId)
        {
            try
            {
                if (MasterDepartmentId != 0)
                {
                    var MasterDepartmentDs = _masterDepartmentDataAccess.GetMasterDepartment(MasterDepartmentId);
                    var MasterDepartmentObj = MasterDepartmentDs.Tables[0].ToModel<MasterDepartment>();
                    return MasterDepartmentObj;
                }
                else
                {
                    return new MasterDepartment();
                }
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public DataSet GetMasterDepartmentList(SearchParam objSearchParam)
        {
            try
            {
                var ds = _masterDepartmentDataAccess.GetMasterDepartmentList(objSearchParam);
                return ds;
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void MarkMasterDepartmentInvalid(int MasterDepartmentId)
        {
            try
            {
                _masterDepartmentDataAccess.MarkMasterDepartmentInvalid(MasterDepartmentId);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void SaveMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            try
            {
                ObjMasterDepartment.CreatedBy = userCtx.UserId;
                ObjMasterDepartment.CreatedOn = DateTime.Now.ToMySqlDateString();
                _masterDepartmentDataAccess.InsertMasterDepartment(ObjMasterDepartment);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }

        public void UpdateMasterDepartment(MasterDepartment ObjMasterDepartment, UserContext userCtx)
        {
            try
            {
                ObjMasterDepartment.UpdatedBy = userCtx.UserId;
                ObjMasterDepartment.UpdatedOn = DateTime.Now.ToMySqlDateString();
                _masterDepartmentDataAccess.UpdateMasterDepartment(ObjMasterDepartment);
            }
            catch (Exception ex)
            {
                applogManager.Error(ex);
                throw ex;
            }
        }
    }
}
