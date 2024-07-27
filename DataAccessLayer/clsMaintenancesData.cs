using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsMaintenancesData
    {
        public static bool? Find(int? MaintenanceID, ref int? VehicleID, ref string Description, ref DateTime? MaintenanceDate, ref decimal? Cost, ref string Status, ref int? CreatedByUserID)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Maintenances_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                VehicleID = (int?)reader["VehicleID"];
                                Description = (string)reader["Description"];
                                MaintenanceDate = (DateTime?)reader["MaintenanceDate"];
                                Cost = (decimal?)reader["Cost"];
                                Status = (string)reader["Status"];
                                CreatedByUserID = (int?)reader["CreatedByUserID"];

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
        public static int? AddNew(int? VehicleID, string Description, DateTime? MaintenanceDate, decimal? Cost, string Status, int? CreatedByUserID)
        {

            int? MaintenanceID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand commandMaintenance = new SqlCommand("SP_Maintenances_AddNew", connection, transaction);
                        
                        commandMaintenance.CommandType = CommandType.StoredProcedure;

                        commandMaintenance.Parameters.AddWithValue("@VehicleID", VehicleID);
                        commandMaintenance.Parameters.AddWithValue("@Description", Description);
                        commandMaintenance.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
                        commandMaintenance.Parameters.AddWithValue("@Cost", Cost);
                        commandMaintenance.Parameters.AddWithValue("@Status", Status);
                        commandMaintenance.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        commandMaintenance.Parameters.Add(outputParameter);

                        commandMaintenance.ExecuteNonQuery();

                        // -----------------------------------------------------------

                        SqlCommand commandVehicle = new SqlCommand("SP_Vehicles_UpdateAvailability", connection, transaction);

                        commandVehicle.CommandType = CommandType.StoredProcedure;

                        commandVehicle.Parameters.AddWithValue("@VehicleID", VehicleID);
                        commandVehicle.Parameters.AddWithValue("@IsAvailable", 0);

                        commandVehicle.ExecuteNonQuery();
                        transaction.Commit();

                        // Retrieve the output parameter value
                        MaintenanceID = (int)outputParameter.Value;
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        clsEventLog.EventLogger(ex.Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return MaintenanceID;
        }
        public static bool Update(int? MaintenanceID, int? VehicleID, string Description, DateTime? MaintenanceDate, decimal? Cost, string Status, int? CreatedByUserID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Maintenances_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
                        command.Parameters.AddWithValue("@Cost", Cost);
                        command.Parameters.AddWithValue("@Status", Status);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


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
        public static bool Delete(int? MaintenanceID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Maintenances_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

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
                    using (SqlCommand command = new SqlCommand("SP_Maintenances_GetAll", connection))
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
        public static DataTable GetAllByVehicleID(int VehicleID)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Maintenances_GetAllByVehicleID", connection))
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
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return dt;

        }
        public static bool ReleaseVehicleAfterMaintenance(int MaintenanceID, int VehicleID)
        {
            object Release = null;
            object Vehicle = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    try
                    {
                        SqlCommand commandRelease = new SqlCommand("SP_Maintenances_UpdateStatus", connection, transaction);

                        commandRelease.CommandType = CommandType.StoredProcedure;
                        commandRelease.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);
                        commandRelease.Parameters.AddWithValue("@Status", "Completed");

                        Release = commandRelease.ExecuteNonQuery();

                        SqlCommand commandVehicle = new SqlCommand("SP_Vehicles_UpdateAvailability", connection, transaction);

                        commandVehicle.CommandType = CommandType.StoredProcedure;
                        commandVehicle.Parameters.AddWithValue("@VehicleID", VehicleID);
                        commandVehicle.Parameters.AddWithValue("@IsAvailable", 1);

                        Vehicle = commandVehicle.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        clsEventLog.EventLogger(ex.Message);
                    }

                }
            }
            catch (Exception ex)
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return (Release != null && Vehicle != null);
        }
        public static bool IsMaintenanceCompleted(int MaintenanceID)
        {
            bool IsCompleted = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("sp_Maintenances_IsMaintenanceCompleted", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            IsCompleted = reader.HasRows;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return IsCompleted;
        }
        public static int CountUnderMaintenance()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select dbo.CountVehiclesUnderMaintenance()", connection))
                    {

                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return count;
        }
    }


}
