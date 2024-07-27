using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCustomersData
    {
        public static bool? Find(int? CustomerID, ref string Name, ref string PhoneNumber, ref string Email, ref string Address, ref DateTime? DateOfBirth, ref byte? Gender, ref string LicenseNumber, ref string ImagePath)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Customers_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                Name = (string)reader["Name"];
                                PhoneNumber = (string)reader["PhoneNumber"];
                                Email = (string)reader["Email"];
                                Address = (string)reader["Address"];
                                DateOfBirth = (DateTime?)reader["DateOfBirth"];
                                Gender = (byte?)reader["Gender"];
                                LicenseNumber = (string)reader["LicenseNumber"];
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsEventLog.EventLogger(ex.Message);
                //Console.WriteLine("Database connection error: " + ex.Message);
            }

            return isFound;
        }
        public static int? AddNew(string Name, string PhoneNumber, string Email, string Address, DateTime? DateOfBirth, byte? Gender, string LicenseNumber, string ImagePath)
        {

            int? CustomerID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Customers_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath == null ? (object)DBNull.Value : ImagePath);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        CustomerID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return CustomerID;
        }


        public static bool Update(int? CustomerID, string Name, string PhoneNumber, string Email, string Address, DateTime? DateOfBirth, byte? Gender, string LicenseNumber, string ImagePath)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Customers_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@LicenseNumber", LicenseNumber);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath == null ? (object)DBNull.Value : ImagePath);


                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return (rowsAffected > 0);
        }


        public static bool Delete(int? CustomerID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Customers_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return (rowsAffected > 0);
        }


        public static DataTable GetAll()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Customers_GetAll", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return dt;

        }

    }


}
