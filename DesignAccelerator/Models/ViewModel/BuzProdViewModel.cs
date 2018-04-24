using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DA.DomainModel;
using DA.BusinessLayer;

namespace DesignAccelerator.Models.ViewModel
{
    public class BuzProdViewModel
    {

        #region PublicProperties
              
        public int BuzProdID { get; set; }
        [Required(ErrorMessage = "Business Product Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]*$", ErrorMessage = "Special Characters are not allowed in this field")]
        public string BuzProdDesc { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int ApplicationID { get; set; }
        public string ApplicationName { get; set; }
        public int daId { get; set; }
        public string daName { get; set; }        
        public IList<tbl_BuzProd> lstBuzProd { get; set; }

        #endregion

        public BuzProdViewModel GetBuzProducts(int? designAccelaratorID)
        {
            try
            {
                BuzProdViewModel buzprodviewmodel = new BuzProdViewModel();
                BuzProdManager buzprodManager = new BuzProdManager();
                buzprodviewmodel.lstBuzProd = buzprodManager.GetBusinessProducts(designAccelaratorID);

                return buzprodviewmodel;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void AddBuzProd(BuzProdViewModel buzprodviewmodel)
        {
            try
            {
                tbl_BuzProd tblbuzprod = new tbl_BuzProd();

                tblbuzprod.BuzProdDesc = buzprodviewmodel.BuzProdDesc;
                tblbuzprod.daId = buzprodviewmodel.daId;
                tblbuzprod.EntityState = DA.DomainModel.EntityState.Added;

                BuzProdManager buzprodManager = new BuzProdManager();
                buzprodManager.AddBuzProd(tblbuzprod);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public BuzProdViewModel FindBuzProd(int? buzProdID)
        {
            try
            {
                BuzProdViewModel buzprodvm = new BuzProdViewModel();
                BuzProdManager buzprodManager = new BuzProdManager();
                var buzprods = buzprodManager.FindBuzProd(buzProdID);
                buzprodvm.daId = buzprods.daId;
                buzprodvm.BuzProdID = buzprods.BuzProdID;
                buzprodvm.BuzProdDesc = buzprods.BuzProdDesc;

                return buzprodvm;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteBuzProd(BuzProdViewModel buzprodviewmodel)
        {
            try
            {
                tbl_BuzProd tblbuzprod = new tbl_BuzProd();

                tblbuzprod.BuzProdID = buzprodviewmodel.BuzProdID;
                tblbuzprod.EntityState = DA.DomainModel.EntityState.Deleted;

                BuzProdManager buzprodManager = new BuzProdManager();
                buzprodManager.DeleteBuzProd(tblbuzprod);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void UpdateBuzProd(BuzProdViewModel buzprodviewmodel)
        {
            try
            {
                tbl_BuzProd tblbuzprod = new tbl_BuzProd();

                tblbuzprod.BuzProdID = buzprodviewmodel.BuzProdID;
                tblbuzprod.BuzProdDesc = buzprodviewmodel.BuzProdDesc;
                tblbuzprod.daId = buzprodviewmodel.daId;
                tblbuzprod.EntityState = DA.DomainModel.EntityState.Modified;

                BuzProdManager buzprodManager = new BuzProdManager();
                buzprodManager.UpdateBuzProd(tblbuzprod);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}