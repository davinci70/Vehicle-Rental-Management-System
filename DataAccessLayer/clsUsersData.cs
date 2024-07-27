using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUsersData
    {
        public static bool? Find(int? UserID, ref string FullName, ref string Username, ref string Password, ref string Address, ref bool? status, ref string PhoneNumber, ref string ImagePath)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Users_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                FullName = (string)reader["FullName"];
                                Username = (string)reader["Username"];
                                Password = (string)reader["Password"];
                                Address = (string)reader["Address"];
                                status = (bool?)reader["status"];
                                PhoneNumber = (string)reader["PhoneNumber"];
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;

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

            return isFound;
        }
        
        public static bool? FindByUsernameAndPassword(ref int? UserID, ref string FullName, string Username, string Password, ref string Address, ref bool? status, ref string PhoneNumber, ref string ImagePath)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Users_FindByUsernameAndPassword", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                UserID = (int)reader["UserID"];
                                FullName = (string)reader["FullName"];
                                Address = (string)reader["Address"];
                                status = (bool?)reader["status"];
                                PhoneNumber = (string)reader["PhoneNumber"];
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;

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

            return isFound;
        }
        public static int? AddNew(string FullName, string Username, string Password, string Address, bool? status, string PhoneNumber, string ImagePath)
        {

            int? UserID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Users_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FullName", FullName);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath == null ? (object)DBNull.Value : ImagePath);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        UserID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return UserID;
        }


        public static bool Update(int? UserID, string FullName, string Username, string Password, string Address, bool? status, string PhoneNumber, string ImagePath)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Users_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@FullName", FullName);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
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


        public static bool Delete(int? UserID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Users_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

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
                    using (SqlCommand command = new SqlCommand("SP_Users_GetAll", connection))
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
