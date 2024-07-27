using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDocuments
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode? Mode = null;
        public int? DocumentID { set; get; }
        public int? CustomerID { set; get; }
        public string Name { set; get; }
        public string Path { set; get; }
        public int? CreatedBy { set; get; }
        public clsDocuments()
        {
            this.DocumentID = null;
            this.CustomerID = null;
            this.Name = null;
            this.Path = null;
            this.CreatedBy = null;

            Mode = enMode.AddNew;
        }
        private clsDocuments(int? DocumentID, int? CustomerID, string Name, string Path, int? CreatedBy)
        {
            this.DocumentID = DocumentID;
            this.CustomerID = CustomerID;
            this.Name = Name;
            this.Path = Path;
            this.CreatedBy = CreatedBy;

            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.DocumentID = clsDocumentsData.AddNew(this.CustomerID, this.Name, this.Path, this.CreatedBy);

            return (this.DocumentID != null);
        }
        private bool _Update()
        {
            return clsDocumentsData.Update(this.DocumentID, this.CustomerID, this.Name, this.Path, this.CreatedBy);
        }
        public static clsDocuments Find(int? DocumentID)
        {
            int? CustomerID = null;
            string Name = null;
            string Path = null;
            int? CreatedBy = null;

            bool? IsFound = clsDocumentsData.Find(DocumentID, ref CustomerID, ref Name, ref Path, ref CreatedBy);

            if (IsFound.HasValue)
                return new clsDocuments(DocumentID, CustomerID, Name, Path, CreatedBy);
            else
                return null;
        }
        public static bool Delete(int? DocumentID)
        {
            return clsDocumentsData.Delete(DocumentID);
        }
        public static DataTable GetAll(int CustomerID)
        {
            return clsDocumentsData.GetAll(CustomerID);
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
