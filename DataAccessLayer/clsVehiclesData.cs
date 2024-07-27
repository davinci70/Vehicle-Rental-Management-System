using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsVehiclesData
    {
        public static bool? Find(int? VehicleID, ref string Make, ref string Model, ref int? Year, ref int? Milage, ref int? FuelTypeID, ref string PlateNumber, ref int? VehicleCategoryID, ref decimal? PricePerDay, ref bool? IsAvailable, ref string ImagePath)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                Make = (string)reader["Make"];
                                Model = (string)reader["Model"];
                                Year = (int?)reader["Year"];
                                Milage = (int?)reader["Milage"];
                                FuelTypeID = (int?)reader["FuelTypeID"];
                                PlateNumber = (string)reader["PlateNumber"];
                                VehicleCategoryID = (int?)reader["VehicleCategoryID"];
                                PricePerDay = (decimal?)reader["PricePerDay"];
                                IsAvailable = (bool?)reader["IsAvailable"];
                                ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null;

                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return isFound;
        }
        
        public static bool? FindIfAvailable(int? VehicleID, ref string Make, ref string Model, ref int? Year, ref int? Milage, ref int? FuelTypeID, ref string PlateNumber, ref int? VehicleCategoryID, ref decimal? PricePerDay, ref bool? IsAvailable, ref string ImagePath)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_FindIfAvailable", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                Make = (string)reader["Make"];
                                Model = (string)reader["Model"];
                                Year = (int?)reader["Year"];
                                Milage = (int?)reader["Milage"];
                                FuelTypeID = (int?)reader["FuelTypeID"];
                                PlateNumber = (string)reader["PlateNumber"];
                                VehicleCategoryID = (int?)reader["VehicleCategoryID"];
                                PricePerDay = (decimal?)reader["PricePerDay"];
                                IsAvailable = (bool?)reader["IsAvailable"];
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
        public static int? AddNew(string Make, string Model, int? Year, int? Milage, int? FuelTypeID, string PlateNumber, int? VehicleCategoryID, decimal? PricePerDay, bool? IsAvailable, string ImagePath)
        {

            int? VehicleID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Make", Make);
                        command.Parameters.AddWithValue("@Model", Model);
                        command.Parameters.AddWithValue("@Year", Year);
                        command.Parameters.AddWithValue("@Milage", Milage);
                        command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
                        command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
                        command.Parameters.AddWithValue("@VehicleCategoryID", VehicleCategoryID);
                        command.Parameters.AddWithValue("@PricePerDay", PricePerDay);
                        command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath == null ? (object)DBNull.Value : ImagePath);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        VehicleID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message, ex.GetType());
                clsEventLog.EventLogger(ex.Message);            
            }

            return VehicleID;
        }
        public static bool Update(int? VehicleID, string Make, string Model, int? Year, int? Milage, int? FuelTypeID, string PlateNumber, int? VehicleCategoryID, decimal? PricePerDay, bool? IsAvailable, string ImagePath)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@Make", Make);
                        command.Parameters.AddWithValue("@Model", Model);
                        command.Parameters.AddWithValue("@Year", Year);
                        command.Parameters.AddWithValue("@Milage", Milage);
                        command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
                        command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
                        command.Parameters.AddWithValue("@VehicleCategoryID", VehicleCategoryID);
                        command.Parameters.AddWithValue("@PricePerDay", PricePerDay);
                        command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                        command.Parameters.AddWithValue("@ImagePath", ImagePath == null ? (object)DBNull.Value : ImagePath);


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

        public static bool Delete(int? VehicleID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);

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

        public static DataTable GetAll()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_viewVehicles_GetAll", connection))
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
                // Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return dt;

        }
        
        public static DataTable GetAllAvailable()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_viewVehicles_GetAllAvailable", connection))
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
                // Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return dt;

        }
        
        public static DataTable GetAllReservationsByVehicleID(int VehicleID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_GetAllVehicleReservationsByVehicleID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);

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
                // Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return dt;

        }
        
        public static DataTable GetAvailableVehicles()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Vehicles_GetAvailableVehicles", connection))
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
                // Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return dt;

        }

        public static int? GetNumberOfRentals(int? VehicleID)
        {
            int NumberOfResults = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("select dbo.GetNumberOfVehicleRentals(@VehicleID)", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);

                        NumberOfResults = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex) 
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return NumberOfResults;
        }
        
        public static int CountVehiclesByCategory(string Category)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("select dbo.CountVehicleAvailableByCategory(@CategoryName)", connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@CategoryName", Category);

                        rowsAffected = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex) 
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return rowsAffected;
        }

    }



}
