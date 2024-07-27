using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsFuelTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? ID { set; get; }
        public string FuelType { set; get; }
        public clsFuelTypes()
        {
            this.ID = null;
            this.FuelType = null;

            Mode = enMode.AddNew;
        }
        private clsFuelTypes(int? ID, string FuelType)
        {
            this.ID = ID;
            this.FuelType = FuelType;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.ID = clsVehicleFuelTypesData.AddNew(this.FuelType);

            return (this.ID != null);
        }
        private bool _Update()
        {
            return clsVehicleFuelTypesData.Update(this.ID, this.FuelType);
        }
        public static clsFuelTypes Find(int? ID)
        {
            string FuelType = null;

            bool? IsFound = clsVehicleFuelTypesData.Find(ID, ref FuelType);

            if (IsFound.HasValue)
                return new clsFuelTypes(ID, FuelType);
            else
                return null;
        }
        
        public static clsFuelTypes FindByName(string FuelType)
        {
            int? ID = null;

            bool? IsFound = clsVehicleFuelTypesData.FindByName(ref ID, FuelType);

            if (IsFound.HasValue)
                return new clsFuelTypes(ID, FuelType);
            else
                return null;
        }
        public static bool Delete(int? ID)
        {
            return clsVehicleFuelTypesData.Delete(ID);
        }
        public static DataTable GetAll()
        {
            return clsVehicleFuelTypesData.GetAll();
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
    }


}
