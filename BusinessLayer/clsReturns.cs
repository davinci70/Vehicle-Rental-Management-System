using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsReturns
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? ReturnID { set; get; }
        public DateTime? ActualReturnDate { set; get; }
        public byte? ActualRentalDays { set; get; }
        public int? ConsumedMilage { set; get; }
        public string FinalCheckNotes { set; get; }
        public decimal? AdditionalCharges { set; get; }
        public decimal? ActualTotalDueAmount { set; get; }
        public int? CreatedByUserID { set; get; }
        public clsUsers UserInfo;
        public clsReturns()
        {
            this.ReturnID = null;
            this.ActualReturnDate = null;
            this.ActualRentalDays = null;
            this.ConsumedMilage = null;
            this.FinalCheckNotes = null;
            this.AdditionalCharges = null;
            this.ActualTotalDueAmount = null;
            this.CreatedByUserID = null;

            Mode = enMode.AddNew;
        }
        private clsReturns(int? ReturnID, DateTime? ActualReturnDate, byte? ActualRentalDays, int? ConsumedMilage, string FinalCheckNotes, decimal? AdditionalCharges, decimal? ActualTotalDueAmount, int? CreatedByUserID)
        {
            this.ReturnID = ReturnID;
            this.ActualReturnDate = ActualReturnDate;
            this.ActualRentalDays = ActualRentalDays;
            this.ConsumedMilage = ConsumedMilage;
            this.FinalCheckNotes = FinalCheckNotes;
            this.AdditionalCharges = AdditionalCharges;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUsers.Find(CreatedByUserID);

            Mode = enMode.Update;
        }
        public bool AddNew()
        {
            this.ReturnID = clsReturnsData.AddNew(this.ActualReturnDate, this.ActualRentalDays, this.ConsumedMilage, this.FinalCheckNotes, this.AdditionalCharges, this.ActualTotalDueAmount, this.CreatedByUserID);

            return (this.ReturnID != null);
        }
        private bool _Update()
        {
            return clsReturnsData.Update(this.ReturnID, this.ActualReturnDate, this.ActualRentalDays, this.ConsumedMilage, this.FinalCheckNotes, this.AdditionalCharges, this.ActualTotalDueAmount, this.CreatedByUserID);
        }
        public static clsReturns Find(int? ReturnID)
        {
            DateTime? ActualReturnDate = null;
            byte? ActualRentalDays = null;
            int? ConsumedMilage = null;
            string FinalCheckNotes = null;
            decimal? AdditionalCharges = null;
            decimal? ActualTotalDueAmount = null;
            int? CreatedByUserID = null;

            bool? IsFound = clsReturnsData.Find(ReturnID, ref ActualReturnDate, ref ActualRentalDays, ref ConsumedMilage, ref FinalCheckNotes, ref AdditionalCharges, ref ActualTotalDueAmount, ref CreatedByUserID);

            if (IsFound.HasValue)
                return new clsReturns(ReturnID, ActualReturnDate, ActualRentalDays, ConsumedMilage, FinalCheckNotes, AdditionalCharges, ActualTotalDueAmount, CreatedByUserID);
            else
                return null;
        }
        public static bool Delete(int? ReturnID)
        {
            return clsReturnsData.Delete(ReturnID);
        }
        public static DataTable GetAll()
        {
            return clsReturnsData.GetAll();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNew())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }
    }

}
