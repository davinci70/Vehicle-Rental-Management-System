using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsVehicles
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? VehicleID { set; get; }
        public string Make { set; get; }
        public string Model { set; get; }
        public int? Year { set; get; }
        public string Name { set; get; }
        public int? Milage { set; get; }
        public int? FuelTypeID { set; get; }
        public clsFuelTypes FuelTypeInfo;
        public string PlateNumber { set; get; }
        public int? VehicleCategoryID { set; get; }
        public clsVehicleCategories VehicleCategoryInfo { set; get; }
        public decimal? PricePerDay { set; get; }
        public bool? IsAvailable { set; get; }
        public string ImagePath { set; get; }
        public clsVehicles()
        {
            this.VehicleID = null;
            this.Make = null;
            this.Model = null;
            this.Year = null;
            this.Milage = null;
            this.FuelTypeID = null;
            this.FuelTypeInfo = null;
            this.PlateNumber = null;
            this.VehicleCategoryID = null;
            this.VehicleCategoryInfo = null;
            this.PricePerDay = null;
            this.IsAvailable = null;
            this.ImagePath = null;

            Mode = enMode.AddNew;
        }
        private clsVehicles(int? VehicleID, string Make, string Model, int? Year, int? Milage, int? FuelTypeID, string PlateNumber, int? VehicleCategoryID, decimal? PricePerDay, bool? IsAvailable, string ImagePath)
        {
            this.VehicleID = VehicleID;
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Name = this.Make + " " + this.Model + " " + this.Year;
            this.Milage = Milage;
            this.FuelTypeID = FuelTypeID;
            this.FuelTypeInfo = clsFuelTypes.Find(FuelTypeID);
            this.PlateNumber = PlateNumber;
            this.VehicleCategoryID = VehicleCategoryID;
            this.VehicleCategoryInfo = clsVehicleCategories.Find(VehicleCategoryID);
            this.PricePerDay = PricePerDay;
            this.IsAvailable = IsAvailable;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.VehicleID = clsVehiclesData.AddNew(this.Make, this.Model, this.Year, this.Milage, this.FuelTypeID, this.PlateNumber, this.VehicleCategoryID, this.PricePerDay, this.IsAvailable, this.ImagePath);

            return (this.VehicleID != null);
        }
        private bool _Update()
        {
            return clsVehiclesData.Update(this.VehicleID, this.Make, this.Model, this.Year, this.Milage, this.FuelTypeID, this.PlateNumber, this.VehicleCategoryID, this.PricePerDay, this.IsAvailable, this.ImagePath);
        }
        public static clsVehicles Find(int? VehicleID)
        {
            string Make = null;
            string Model = null;
            int? Year = null;
            int? Milage = null;
            int? FuelTypeID = null;
            string PlateNumber = null;
            int? VehicleCategoryID = null;
            decimal? PricePerDay = null;
            bool? IsAvailable = null;
            string ImagePath = null;

            bool? IsFound = clsVehiclesData.Find(VehicleID, ref Make, ref Model, ref Year, ref Milage, ref FuelTypeID, ref PlateNumber, ref VehicleCategoryID, ref PricePerDay, ref IsAvailable, ref ImagePath);

            if (IsFound.HasValue)
                return new clsVehicles(VehicleID, Make, Model, Year, Milage, FuelTypeID, PlateNumber, VehicleCategoryID, PricePerDay, IsAvailable, ImagePath);
            else
                return null;
        }
        
        public static clsVehicles FindIfAvailable(int? VehicleID)
        {
            string Make = null;
            string Model = null;
            int? Year = null;
            int? Milage = null;
            int? FuelTypeID = null;
            string PlateNumber = null;
            int? VehicleCategoryID = null;
            decimal? PricePerDay = null;
            bool? IsAvailable = null;
            string ImagePath = null;

            bool? IsFound = clsVehiclesData.FindIfAvailable(VehicleID, ref Make, ref Model, ref Year, ref Milage, ref FuelTypeID, ref PlateNumber, ref VehicleCategoryID, ref PricePerDay, ref IsAvailable, ref ImagePath);

            if (IsFound.HasValue)
                return new clsVehicles(VehicleID, Make, Model, Year, Milage, FuelTypeID, PlateNumber, VehicleCategoryID, PricePerDay, IsAvailable, ImagePath);
            else
                return null;
        }
        public static bool Delete(int? VehicleID)
        {
            return clsVehiclesData.Delete(VehicleID);
        }
        public static DataTable GetAll()
        {
            return clsVehiclesData.GetAll();
        }
        
        public static DataTable GetAllAvailable()
        {
            return clsVehiclesData.GetAllAvailable();
        }
        
        public static DataTable GetAllReservationsByVehicleID(int VehicleID)
        {
            return clsVehiclesData.GetAllReservationsByVehicleID(VehicleID);
        }
        
        public static DataTable GetAvailableVehicles()
        {
            return clsVehiclesData.GetAvailableVehicles();
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

        public static int? GetNumberOfRentals(int? VehicleID)
        {
            return clsVehiclesData.GetNumberOfRentals(VehicleID);
        }

        public static int CountVehiclesByCategory(string category)
        {
            return clsVehiclesData.CountVehiclesByCategory(category);   
        }

    }


}
