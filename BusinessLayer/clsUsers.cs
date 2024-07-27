using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUsers
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? UserID { set; get; }
        public string FullName { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Address { set; get; }
        public bool? status { set; get; }
        public string PhoneNumber { set; get; }
        public string ImagePath { set; get; }
        public clsUsers()
        {
            this.UserID = null;
            this.FullName = null;
            this.Username = null;
            this.Password = null;
            this.Address = null;
            this.status = null;
            this.PhoneNumber = null;
            this.ImagePath = null;

            Mode = enMode.AddNew;
        }
        private clsUsers(int? UserID, string FullName, string Username, string Password, string Address, bool? status, string PhoneNumber, string ImagePath)
        {
            this.UserID = UserID;
            this.FullName = FullName;
            this.Username = Username;
            this.Password = Password;
            this.Address = Address;
            this.status = status;
            this.PhoneNumber = PhoneNumber;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.UserID = clsUsersData.AddNew(this.FullName, this.Username, this.Password, this.Address, this.status, this.PhoneNumber, this.ImagePath);

            return (this.UserID != null);
        }
        private bool _Update()
        {
            return clsUsersData.Update(this.UserID, this.FullName, this.Username, this.Password, this.Address, this.status, this.PhoneNumber, this.ImagePath);
        }
        public static clsUsers Find(int? UserID)
        {
            string FullName = null;
            string Username = null;
            string Password = null;
            string Address = null;
            bool? status = null;
            string PhoneNumber = null;
            string ImagePath = null;

            bool? IsFound = clsUsersData.Find(UserID, ref FullName, ref Username, ref Password, ref Address, ref status, ref PhoneNumber, ref ImagePath);

            if (IsFound.HasValue)
                return new clsUsers(UserID, FullName, Username, Password, Address, status, PhoneNumber, ImagePath);
            else
                return null;
        }
        public static clsUsers FindByUsernameAndPassword(string Username, string Password)
        {
            int? UserID = null;
            string FullName = null;
            string Address = null;
            bool? status = null;
            string PhoneNumber = null;
            string ImagePath = null;

            bool? IsFound = clsUsersData.FindByUsernameAndPassword(ref UserID, ref FullName, Username, Password, ref Address, ref status, ref PhoneNumber, ref ImagePath);

            if (IsFound.HasValue)
                return new clsUsers(UserID, FullName, Username, Password, Address, status, PhoneNumber, ImagePath);
            else
                return null;
        }
        public static bool Delete(int? UserID)
        {
            return clsUsersData.Delete(UserID);
        }
        public static DataTable GetAll()
        {
            return clsUsersData.GetAll();
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
