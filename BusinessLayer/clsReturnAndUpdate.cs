using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsReturnAndUpdate
    {
        public int? ReturnID { set; get; }
        public DateTime? ActualReturnDate { set; get; }
        public byte? ActualRentalDays { set; get; }
        public int? ConsumedMilage { set; get; }
        public string FinalCheckNotes { set; get; }
        public decimal? AdditionalCharges { set; get; }
        public decimal? ActualTotalDueAmount { set; get; }
        public int? CreatedByUserID { set; get; }
        public decimal? TotalRemaining { set; get; }
        public decimal? TotalRefundedAmount { set; get; }
        public decimal? InitialPaidTotalDueAmount { set; get; }
        public int? VehicleID { set; get; }
        public int? Milage {  set; get; }
        public int? PaymentID { set; get; }
        public int? BookingID { set; get; }

        public clsReturnAndUpdate()
        {
            this.ReturnID = null;
            this.ActualReturnDate = null;
            this.ActualRentalDays = null;
            this.ConsumedMilage = null;
            this.FinalCheckNotes = null;
            this.AdditionalCharges = null;
            this.ActualTotalDueAmount = null;
            this.CreatedByUserID = null;
            this.TotalRemaining = null;
            this.TotalRefundedAmount = null;
            this.InitialPaidTotalDueAmount = null;
            this.VehicleID = null;
            this.Milage = null;
            this.PaymentID = null;
            this.BookingID = null;
        }

        private clsReturnAndUpdate(int? returnID, DateTime? actualReturnDate, byte? actualRentalDays, int? consumedMilage, string finalCheckNotes, decimal? additionalCharges, decimal? actualTotalDueAmount, int? createdByUserID, decimal? totalRemaining, decimal? totalRefundedAmount, decimal? initialTotalPaidDueAmount, int? VehicleID, int? Milage, int? PaymentID, int? BookingID)
        {
            this.ReturnID = returnID;
            this.ActualReturnDate = actualReturnDate;
            this.ActualRentalDays = actualRentalDays;
            this.ConsumedMilage = consumedMilage;
            this.FinalCheckNotes = finalCheckNotes;
            this.AdditionalCharges = additionalCharges;
            this.ActualTotalDueAmount = actualTotalDueAmount;
            this.CreatedByUserID = createdByUserID;
            this.TotalRemaining = totalRemaining;
            this.TotalRefundedAmount = totalRefundedAmount;
            this.InitialPaidTotalDueAmount= initialTotalPaidDueAmount;
            this.VehicleID = VehicleID;
            this.Milage = Milage;
            this.PaymentID = PaymentID;
            this.BookingID = BookingID;
        }

        public bool Save()
        {
            return clsReturnAndUpdateData.ReturnAndUpdateDataAccordingly(this.ActualReturnDate,
                this.ActualRentalDays, this.ConsumedMilage, this.FinalCheckNotes, this.AdditionalCharges,
                this.ActualTotalDueAmount, this.CreatedByUserID, this.TotalRemaining, this.TotalRefundedAmount,
                this.InitialPaidTotalDueAmount, this.VehicleID, this.Milage, this.PaymentID, this.BookingID);
        }
    }
}
