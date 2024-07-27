using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsVehicleCategoriesData
    {
        public static bool? Find(int? CategoryID, ref string CategoryName)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_VehicleCategories_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CategoryName = (string)reader["CategoryName"];

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
        
        public static bool? FindByName(ref int? CategoryID, string CategoryName)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_VehicleCategories_FindByName", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CategoryID = (int)reader["CategoryID"];

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
        public static int? AddNew(string CategoryName)
        {

            int? CategoryID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_VehicleCategories_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryName", CategoryName);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        CategoryID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return CategoryID;
        }


        public static bool Update(int? CategoryID, string CategoryName)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_VehicleCategories_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CategoryID", CategoryID);
                        command.Parameters.AddWithValue("@CategoryName", CategoryName);


                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return (rowsAffected > 0);
        }


        public static bool Delete(int? CategoryID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_VehicleCategories_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryID", CategoryID);

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
                    using (SqlCommand command = new SqlCommand("SP_VehicleCategories_GetAll", connection))
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
