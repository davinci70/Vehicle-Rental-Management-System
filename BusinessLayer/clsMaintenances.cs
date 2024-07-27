using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsMaintenances
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? MaintenanceID { set; get; }
        public int? VehicleID { set; get; }
        public clsVehicles VehicleInfo;
        public string Description { set; get; }
        public DateTime? MaintenanceDate { set; get; }
        public decimal? Cost { set; get; }
        public string Status { set; get; }
        public int? CreatedByUserID { set; get; }
        public clsMaintenances()
        {
            this.MaintenanceID = null;
            this.VehicleID = null;
            this.Description = null;
            this.MaintenanceDate = null;
            this.Cost = null;
            this.Status = null;
            this.CreatedByUserID = null;

            Mode = enMode.AddNew;
        }
        private clsMaintenances(int? MaintenanceID, int? VehicleID, string Description, DateTime? MaintenanceDate, decimal? Cost, string Status, int? CreatedByUserID)
        {
            this.MaintenanceID = MaintenanceID;
            this.VehicleID = VehicleID;
            this.VehicleInfo = clsVehicles.Find(VehicleID);
            this.Description = Description;
            this.MaintenanceDate = MaintenanceDate;
            this.Cost = Cost;
            this.Status = Status;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.MaintenanceID = clsMaintenancesData.AddNew(this.VehicleID, this.Description, this.MaintenanceDate, this.Cost, this.Status, this.CreatedByUserID);

            return (this.MaintenanceID != null);
        }
        private bool _Update()
        {
            return clsMaintenancesData.Update(this.MaintenanceID, this.VehicleID, this.Description, this.MaintenanceDate, this.Cost, this.Status, this.CreatedByUserID);
        }
        public static clsMaintenances Find(int? MaintenanceID)
        {
            int? VehicleID = null;
            string Description = null;
            DateTime? MaintenanceDate = null;
            decimal? Cost = null;
            string Status = null;
            int? CreatedByUserID = null;

            bool? IsFound = clsMaintenancesData.Find(MaintenanceID, ref VehicleID, ref Description, ref MaintenanceDate, ref Cost, ref Status, ref CreatedByUserID);

            if (IsFound.HasValue)
                return new clsMaintenances(MaintenanceID, VehicleID, Description, MaintenanceDate, Cost, Status, CreatedByUserID);
            else
                return null;
        }
        public static bool Delete(int? MaintenanceID)
        {
            return clsMaintenancesData.Delete(MaintenanceID);
        }
        public static DataTable GetAll()
        {
            return clsMaintenancesData.GetAll();
        }
        public static DataTable GetAllByVehicleID(int VehicleID)
        {
            return clsMaintenancesData.GetAllByVehicleID(VehicleID);
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
        public static bool ReleaseVehicleAfterMaintenance(int MaintenanceID, int VehicleID)
        {
            return clsMaintenancesData.ReleaseVehicleAfterMaintenance(MaintenanceID, VehicleID);
        }
        public static bool IsMaintenanceCompleted(int MaintenanceID)
        {
            return clsMaintenancesData.IsMaintenanceCompleted(MaintenanceID);
        }
        public static int CountUnderMaintenance()
        {
            return clsMaintenancesData.CountUnderMaintenance();
        }
    }

}
