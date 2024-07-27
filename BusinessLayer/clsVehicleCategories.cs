using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsVehicleCategories
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? CategoryID { set; get; }
        public string CategoryName { set; get; }
        public clsVehicleCategories()
        {
            this.CategoryID = null;
            this.CategoryName = null;

            Mode = enMode.AddNew;
        }
        private clsVehicleCategories(int? CategoryID, string CategoryName)
        {
            this.CategoryID = CategoryID;
            this.CategoryName = CategoryName;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.CategoryID = clsVehicleCategoriesData.AddNew(this.CategoryName);

            return (this.CategoryID != null);
        }
        private bool _Update()
        {
            return clsVehicleCategoriesData.Update(this.CategoryID, this.CategoryName);
        }
        public static clsVehicleCategories Find(int? CategoryID)
        {
            string CategoryName = null;

            bool? IsFound = clsVehicleCategoriesData.Find(CategoryID, ref CategoryName);

            if (IsFound.HasValue)
                return new clsVehicleCategories(CategoryID, CategoryName);
            else
                return null;
        }
        
        public static clsVehicleCategories FindByName(string CategoryName)
        {
            int? CategoryID = null;

            bool? IsFound = clsVehicleCategoriesData.FindByName(ref CategoryID, CategoryName);

            if (IsFound.HasValue)
                return new clsVehicleCategories(CategoryID, CategoryName);
            else
                return null;
        }
        public static bool Delete(int? CategoryID)
        {
            return clsVehicleCategoriesData.Delete(CategoryID);
        }
        public static DataTable GetAll()
        {
            return clsVehicleCategoriesData.GetAll();
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
