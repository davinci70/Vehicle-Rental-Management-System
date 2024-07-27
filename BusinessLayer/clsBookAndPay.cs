using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBookAndPay
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? BookingID { set; get; }
        public int? CustomerID { set; get; }
        public clsCustomers CustomerInfo { set; get; }
        public int? VehicleID { set; get; }
        public clsVehicles VehicleInfo { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public string DropoffLocation { set; get; }
        public string PickupLocation { set; get; }
        public decimal? PricePerDay { set; get; }
        public decimal? InitialTotalDueAmount { set; get; }
        public string Status { set; get; }
        public string Notes { set; get; }
        public int? ReturnID { set; get; }
        public string Details { set; get; }
        public decimal? InitialPaidTotalDueAmount { set; get; }
        public decimal? ActualTotalDueAmount { set; get; }
        public decimal? TotalRemaining { set; get; }
        public decimal? TotalRefundedAmount { set; get; }
        public DateTime? PaymentDate { set; get; }
        public DateTime? UpdatedPaymentDate { set; get; }
        public int? CreatedByUserID { set; get; }

        public clsBookAndPay()
        {
            this.BookingID = null;
            this.CustomerID = null;
            this.VehicleID = null;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.DropoffLocation = null;
            this.PickupLocation = null;
            this.PricePerDay = null;
            this.InitialTotalDueAmount = null;
            this.Notes = null;
            this.Status = null;
            this.ReturnID = null;
            this.Details = null;
            this.InitialPaidTotalDueAmount = null;
            this.ActualTotalDueAmount = null;
            this.TotalRemaining = null;
            this.TotalRefundedAmount = null;
            this.PaymentDate = null;
            this.UpdatedPaymentDate = null;
            this.CreatedByUserID = null;

            Mode = enMode.AddNew;
        }

        private clsBookAndPay(int? BookingID, int? CustomerID, int? VehicleID, DateTime StartDate, DateTime EndDate, string DropoffLocation, string PickupLocation, decimal? PricePerDay, decimal? InitialTotalDueAmount, string Notes, string Status,
            int? PaymentID, int? ReturnID, string Details, decimal? InitialPaidTotalDueAmount, decimal? ActualTotalDueAmount, decimal? TotalRemaining, decimal? TotalRefundedAmount, DateTime? PaymentDate, DateTime? UpdatedPaymentDate, int? CreatedByUserID)
        {
            this.BookingID = BookingID;
            this.CustomerID = CustomerID;
            this.CustomerInfo = clsCustomers.Find(CustomerID);
            this.VehicleID = VehicleID;
            this.VehicleInfo = clsVehicles.Find(VehicleID);
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.DropoffLocation = DropoffLocation;
            this.PickupLocation = PickupLocation;
            this.PricePerDay = PricePerDay;
            this.InitialTotalDueAmount = InitialTotalDueAmount;
            this.Notes = Notes;
            this.Status = Status;
            this.ReturnID = ReturnID;
            this.Details = Details;
            this.InitialPaidTotalDueAmount = InitialPaidTotalDueAmount;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.TotalRemaining = TotalRemaining;
            this.TotalRefundedAmount = TotalRefundedAmount;
            this.PaymentDate = PaymentDate;
            this.UpdatedPaymentDate = UpdatedPaymentDate;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public bool Save()
        {
            return clsBookAndPayData.BookAndPay(this.CustomerID, this.VehicleID, this.StartDate, this.EndDate, this.DropoffLocation, this.PickupLocation, this.PricePerDay, this.InitialTotalDueAmount, this.Notes, this.Status,
                this.ReturnID, this.Details, this.InitialPaidTotalDueAmount, this.ActualTotalDueAmount, this.TotalRemaining, this.TotalRefundedAmount, this.PaymentDate, this.UpdatedPaymentDate, this.CreatedByUserID);
        }
    }
}
