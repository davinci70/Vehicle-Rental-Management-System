using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsVehicleFuelTypesData
    {
        public static bool? Find(int? ID, ref string FuelType)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FuelTypes_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                FuelType = (string)reader["FuelType"];

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
        
        public static bool? FindByName(ref int? ID, string FuelType)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FuelTypes_FindByName", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FuelType", FuelType);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                ID = (int)reader["ID"];

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
        public static int? AddNew(string FuelType)
        {

            int? ID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FuelTypes_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FuelType", FuelType);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        ID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return ID;
        }


        public static bool Update(int? ID, string FuelType)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FuelTypes_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ID", ID);
                        command.Parameters.AddWithValue("@FuelType", FuelType);


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


        public static bool Delete(int? ID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_FuelTypes_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", ID);

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
                    using (SqlCommand command = new SqlCommand("SP_FuelTypes_GetAll", connection))
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
