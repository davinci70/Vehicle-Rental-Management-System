using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsBookings
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? BookingID { set; get; }
        public int? CustomerID { set; get; }
        public clsCustomers CustomerInfo;
        public int? VehicleID { set; get; }
        public clsVehicles VehicleInfo;
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public string DropoffLocation { set; get; }
        public string PickupLocation { set; get; }
        public decimal? PricePerDay { set; get; }
        public decimal? InitialTotalDueAmount { set; get; }
        public string Notes { set; get; }
        public string Status { set; get; }
        public int? CreatedByUserID { set; get; }
        public clsBookings()
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
            this.CreatedByUserID = null;

            Mode = enMode.AddNew;
        }
        private clsBookings(int? BookingID, int? CustomerID, int? VehicleID, DateTime StartDate, DateTime EndDate, string DropoffLocation, string PickupLocation, decimal? PricePerDay, decimal? InitialTotalDueAmount, string Notes, string Status, int? CreatedByUserID)
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
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.BookingID = clsBookingsData.AddNew(this.CustomerID, this.VehicleID, this.StartDate, this.EndDate, this.DropoffLocation, this.PickupLocation, this.PricePerDay, this.InitialTotalDueAmount, this.Notes, this.Status, this.CreatedByUserID);

            return (this.BookingID != null);
        }
        private bool _Update()
        {
            return clsBookingsData.Update(this.BookingID, this.CustomerID, this.VehicleID, this.StartDate, this.EndDate, this.DropoffLocation, this.PickupLocation, this.PricePerDay, this.InitialTotalDueAmount, this.Notes, this.Status, this.CreatedByUserID);
        }
        public static clsBookings Find(int? BookingID)
        {
            int? CustomerID = null;
            int? VehicleID = null;
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            string DropoffLocation = null;
            string PickupLocation = null;
            decimal? PricePerDay = null;
            decimal? InitialTotalDueAmount = null;
            string Notes = null;
            string Status = null;
            int? CreatedByUserID = null;

            bool? IsFound = clsBookingsData.Find(BookingID, ref CustomerID, ref VehicleID, ref StartDate, ref EndDate, ref DropoffLocation, ref PickupLocation, ref PricePerDay, ref InitialTotalDueAmount, ref Notes, ref Status, ref CreatedByUserID);

            if (IsFound.HasValue)
                return new clsBookings(BookingID, CustomerID, VehicleID, StartDate, EndDate, DropoffLocation, PickupLocation, PricePerDay, InitialTotalDueAmount, Notes, Status, CreatedByUserID);
            else
                return null;
        }
      
        public static bool Delete(int? BookingID)
        {
            return clsBookingsData.Delete(BookingID);
        }
        public static DataTable GetAll()
        {
            return clsBookingsData.GetAll();
        }
        public static DataTable GetAllByCustomer(string Customer)
        {
            return clsBookingsData.GetAllByCustomer(Customer);
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

        public int ActualRentalDays()
        {
            return (this.EndDate.Date - this.StartDate.Date).Days;
        }

        public static int CountBookings()
        {
            return clsBookingsData.CountBookings();
        }

        public static int CountOnRent()
        {
            return clsBookingsData.CountOnRent();
        }
    }

}
