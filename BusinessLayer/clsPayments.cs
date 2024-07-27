using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPayments
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? PaymentID { set; get; }
        public int? BookingID { set; get; }
        public int? ReturnID { set; get; }
        public string Details { set; get; }
        public decimal? InitialPaidTotalDueAmount { set; get; }
        public decimal? ActualTotalDueAmount { set; get; }
        public decimal? TotalRemaining { set; get; }
        public decimal? TotalRefundedAmount { set; get; }
        public DateTime? PaymentDate { set; get; }
        public DateTime? UpdatedPaymentDate { set; get; }
        public int? CreatedByUserID { set; get; }
        public clsUsers UserInfo;
        public clsPayments()
        {
            this.PaymentID = null;
            this.BookingID = null;
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
        private clsPayments(int? PaymentID, int? BookingID, int? ReturnID, string Details, decimal? InitialPaidTotalDueAmount, decimal? ActualTotalDueAmount, decimal? TotalRemaining, decimal? TotalRefundedAmount, DateTime? PaymentDate, DateTime? UpdatedPaymentDate, int? CreatedByUserID)
        {
            this.PaymentID = PaymentID;
            this.BookingID = BookingID;
            this.ReturnID = ReturnID;
            this.Details = Details;
            this.InitialPaidTotalDueAmount = InitialPaidTotalDueAmount;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.TotalRemaining = TotalRemaining;
            this.TotalRefundedAmount = TotalRefundedAmount;
            this.PaymentDate = PaymentDate;
            this.UpdatedPaymentDate = UpdatedPaymentDate;
            this.CreatedByUserID = CreatedByUserID;
            this.UserInfo = clsUsers.Find(CreatedByUserID);

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.PaymentID = clsPaymentsData.AddNew(this.BookingID, this.ReturnID, this.Details, this.InitialPaidTotalDueAmount, this.ActualTotalDueAmount, this.TotalRemaining, this.TotalRefundedAmount, this.PaymentDate, this.UpdatedPaymentDate, this.CreatedByUserID);

            return (this.PaymentID != null);
        }
        private bool _Update()
        {
            return clsPaymentsData.Update(this.PaymentID, this.BookingID, this.ReturnID, this.Details, this.InitialPaidTotalDueAmount, this.ActualTotalDueAmount, this.TotalRemaining, this.TotalRefundedAmount, this.PaymentDate, this.UpdatedPaymentDate, this.CreatedByUserID);
        }
        public static clsPayments Find(int? PaymentID)
        {
            int? BookingID = null;
            int? ReturnID = null;
            string Details = null;
            decimal? InitialPaidTotalDueAmount = null;
            decimal? ActualTotalDueAmount = null;
            decimal? TotalRemaining = null;
            decimal? TotalRefundedAmount = null;
            DateTime? PaymentDate = null;
            DateTime? UpdatedPaymentDate = null;
            int? CreatedByUserID = null;

            bool? IsFound = clsPaymentsData.Find(PaymentID, ref BookingID, ref ReturnID, ref Details, ref InitialPaidTotalDueAmount, ref ActualTotalDueAmount, ref TotalRemaining, ref TotalRefundedAmount, ref PaymentDate, ref UpdatedPaymentDate, ref CreatedByUserID);

            if (IsFound.HasValue)
                return new clsPayments(PaymentID, BookingID, ReturnID, Details, InitialPaidTotalDueAmount, ActualTotalDueAmount, TotalRemaining, TotalRefundedAmount, PaymentDate, UpdatedPaymentDate, CreatedByUserID);
            else
                return null;
        }
        public static clsPayments FindByBookingID(int? BookingID)
        {
            int? PaymentID = null;
            int? ReturnID = null;
            string Details = null;
            decimal? InitialPaidTotalDueAmount = null;
            decimal? ActualTotalDueAmount = null;
            decimal? TotalRemaining = null;
            decimal? TotalRefundedAmount = null;
            DateTime? PaymentDate = null;
            DateTime? UpdatedPaymentDate = null;
            int? CreatedByUserID = null;

            bool? IsFound = clsPaymentsData.FindByBookingID(ref PaymentID, BookingID, ref ReturnID, ref Details, ref InitialPaidTotalDueAmount, ref ActualTotalDueAmount, ref TotalRemaining, ref TotalRefundedAmount, ref PaymentDate, ref UpdatedPaymentDate, ref CreatedByUserID);

            if (IsFound.HasValue)
                return new clsPayments(PaymentID, BookingID, ReturnID, Details, InitialPaidTotalDueAmount, ActualTotalDueAmount, TotalRemaining, TotalRefundedAmount, PaymentDate, UpdatedPaymentDate, CreatedByUserID);
            else
                return null;
        }
        public static bool Delete(int? PaymentID)
        {
            return clsPaymentsData.Delete(PaymentID);
        }
        public static DataTable GetAll()
        {
            return clsPaymentsData.GetAll();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
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
        public static int CountReturns()
        {
            return clsPaymentsData.CountReturns();
        }
        public static decimal GetTotalRevenueByMonth(int Month)
        {
            return clsPaymentsData.GetTotalRevenueByMonth(Month);
        }
    }


}
