#nullable enable

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsCustomers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? CustomerID { set; get; }
        public string Name { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public byte? Gender { set; get; }
        public string LicenseNumber { set; get; }
        public string ImagePath { set; get; }
        public clsCustomers()
        {
            this.CustomerID = null;
            this.Name = null;
            this.PhoneNumber = null;
            this.Email = null;
            this.Address = null;
            this.DateOfBirth = null;
            this.Gender = null;
            this.LicenseNumber = null;
            this.ImagePath = null;

            Mode = enMode.AddNew;
        }
        private clsCustomers(int? CustomerID, string Name, string PhoneNumber, string Email, string Address, DateTime? DateOfBirth, byte? Gender, string LicenseNumber, string ImagePath)
        {
            this.CustomerID = CustomerID;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.LicenseNumber = LicenseNumber;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.CustomerID = clsCustomersData.AddNew(this.Name, this.PhoneNumber, this.Email, this.Address, this.DateOfBirth, this.Gender, this.LicenseNumber, this.ImagePath);

            return (this.CustomerID != null);
        }
        private bool _Update()
        {
            return clsCustomersData.Update(this.CustomerID, this.Name, this.PhoneNumber, this.Email, this.Address, this.DateOfBirth, this.Gender, this.LicenseNumber, this.ImagePath);
        }
        public static clsCustomers Find(int? CustomerID)
        {
            string Name = null;
            string PhoneNumber = null;
            string Email = null;
            string Address = null;
            DateTime? DateOfBirth = null;
            byte? Gender = null;
            string LicenseNumber = null;
            string ImagePath = null;

            bool? IsFound = clsCustomersData.Find(CustomerID, ref Name, ref PhoneNumber, ref Email, ref Address, ref DateOfBirth, ref Gender, ref LicenseNumber, ref ImagePath);

            if (IsFound.HasValue)
                return new clsCustomers(CustomerID, Name, PhoneNumber, Email, Address, DateOfBirth, Gender, LicenseNumber, ImagePath);
            else
                return null;
        }
        public static bool Delete(int? CustomerID)
        {
            return clsCustomersData.Delete(CustomerID);
        }
        public static DataTable GetAll()
        {
            return clsCustomersData.GetAll();
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
