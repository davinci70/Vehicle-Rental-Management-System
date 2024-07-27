using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBookingsData
    {
        public static bool? Find(int? BookingID, ref int? CustomerID, ref int? VehicleID, ref DateTime StartDate, ref DateTime EndDate, ref string DropoffLocation, ref string PickupLocation, ref decimal? PricePerDay, ref decimal? InitialTotalDueAmount, ref string Notes, ref string Status, ref int? CreatedByUserID)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Bookings_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                CustomerID = (int?)reader["CustomerID"];
                                VehicleID = (int?)reader["VehicleID"];
                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                DropoffLocation = (string)reader["DropoffLocation"];
                                PickupLocation = (string)reader["PickupLocation"];
                                PricePerDay = (decimal?)reader["PricePerDay"];
                                InitialTotalDueAmount = (decimal?)reader["InitialTotalDueAmount"];
                                Notes = reader["Notes"] != DBNull.Value ? (string)reader["Notes"] : null;
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
        
        public static int? AddNew(int? CustomerID, int? VehicleID, DateTime StartDate, DateTime EndDate, string DropoffLocation, string PickupLocation, decimal? PricePerDay, decimal? InitialTotalDueAmount, string Notes, string status, int? CreatedByUserID)
        {

            int? BookingID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Bookings_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        command.Parameters.AddWithValue("@PricePerDay", PricePerDay);
                        command.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
                        command.Parameters.AddWithValue("@Notes", Notes == null ? (object)DBNull.Value : Notes);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        BookingID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return BookingID;
        }


        public static bool Update(int? BookingID, int? CustomerID, int? VehicleID, DateTime StartDate, DateTime EndDate, string DropoffLocation, string PickupLocation, decimal? PricePerDay, decimal? InitialTotalDueAmount, string Notes, string status, int? CreatedByUserID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Bookings_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookingID", BookingID);
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        command.Parameters.AddWithValue("@PricePerDay", PricePerDay);
                        command.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
                        command.Parameters.AddWithValue("@Notes", Notes == null ? (object)DBNull.Value : Notes);
                        command.Parameters.AddWithValue("@Status", status);
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


        public static bool Delete(int? BookingID)
        {

            int? BookingRowsAffected = null;
            int? PaymentRowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        SqlCommand paymentCommand = new SqlCommand("SP_Payments_DeleteByBookingID", connection, transaction);

                        paymentCommand.CommandType = CommandType.StoredProcedure;
                        paymentCommand.Parameters.AddWithValue("@BookingID", BookingID);

                        PaymentRowsAffected = paymentCommand.ExecuteNonQuery();

                        SqlCommand BookingCommand = new SqlCommand("SP_Bookings_Delete", connection, transaction);

                        BookingCommand.CommandType = CommandType.StoredProcedure;
                        BookingCommand.Parameters.AddWithValue("@BookingID", BookingID);


                        BookingRowsAffected = BookingCommand.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                    
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return (BookingRowsAffected > 0 && PaymentRowsAffected > 0);
        }


        public static DataTable GetAll()
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_viewBookings_GetAll", connection))
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
        public static DataTable GetAllByCustomer(string Customer)
        {

            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_viewBookings_GetAllByCustomer", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Customer", Customer);

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

        public static int CountBookings()
        {
            int CountBookings = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("select dbo.CountBookings()", Connection))
                    {
                        CountBookings = (int)Command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex) 
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return CountBookings;
        }
        
        public static int CountOnRent()
        {
            int CountOnRent = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("select dbo.CountOnRent()", Connection))
                    {
                        CountOnRent = (int)Command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex) 
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return CountOnRent;
        }

    }


}
