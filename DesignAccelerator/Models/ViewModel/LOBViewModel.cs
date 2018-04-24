using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DA.DomainModel;
using DA.BusinessLayer;
using System.ComponentModel.DataAnnotations;

namespace DesignAccelerator.Models.ViewModel
{
    public class LOBViewModel
    {
        #region PublicProperties

        public int DAID { get; set; }
        public int lobID { get; set; }
        [Required(ErrorMessage = "LOB Description is required")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]*$", ErrorMessage = "Special Characters are not allowed in this field")]
        public string lobDesc { get; set; }

        public string DAName { get; set; }
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int ModuleId { get; set; }
        
        public IList<LOBViewModel> LobList { get; set; }

        #endregion

        public void AddLOB(LOBViewModel  lobViewModel)
        {
            try
            {
                tbl_LOB tblLOB = new tbl_LOB();

                tblLOB.LobDesc = lobViewModel.lobDesc;
                tblLOB.daId = lobViewModel.DAID;//1;

                tblLOB.EntityState = DA.DomainModel.EntityState.Added;

                LOBManager lobManager = new LOBManager();
                lobManager.AddLOB(tblLOB);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public void DeleteLob(LOBViewModel lobViewModel)
        {
            try
            {
                tbl_LOB tblLOB = new tbl_LOB();
                tblLOB.LobID = lobViewModel.lobID;
                tblLOB.daId = lobViewModel.DAID;
                tblLOB.EntityState = DA.DomainModel.EntityState.Deleted;

                LOBManager lobManager = new LOBManager();
                lobManager.DeleteLOB(tblLOB);
            }
            catch(Exception)
            {
                throw;
            }          
        }

        public void UpdateLob(LOBViewModel lobViewModel)
        {
            try
            {
                tbl_LOB tblLOB = new tbl_LOB();
                tblLOB.LobID = lobViewModel.lobID;
                tblLOB.LobDesc = lobViewModel.lobDesc;
                tblLOB.daId = lobViewModel.DAID;// 1;
                tblLOB.EntityState = DA.DomainModel.EntityState.Modified;

                LOBManager lobManager = new LOBManager();
                lobManager.UpdateLOB(tblLOB);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void GetLobDetails(int daId)
        {
            try
            {
                LOBManager lobManager = new LOBManager();
                var lobList = lobManager.GetLOBDetails(daId);

                LobList = new List<LOBViewModel>();
                foreach (var item in lobList)
                {
                    LOBViewModel lobViewModel = new LOBViewModel();
                    lobViewModel.lobID = item.LobID;
                    lobViewModel.lobDesc = item.LobDesc;
                    lobViewModel.DAID = item.daId;//1;

                    LobList.Add(lobViewModel);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void GetDAName(int daId, out int appId, out string daName)
        {
            try
            {
                tbl_DesignAccelerator tblDA = new tbl_DesignAccelerator();
                DAManager daManager = new DAManager();
                tblDA = daManager.FindDA(daId);
                appId = (int)tblDA.ModuleId;
                daName = tblDA.daName;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public LOBViewModel FindLob(int? lobID)
        {
            try
            {
                LOBViewModel lobViewModel = new LOBViewModel();

                LOBManager lobManager = new LOBManager();
                var lob = lobManager.FindLOB(lobID);

                lobViewModel.lobID = lob.LobID;
                lobViewModel.lobDesc = lob.LobDesc;
                lobViewModel.DAID = lob.daId;//1;
                return lobViewModel;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}