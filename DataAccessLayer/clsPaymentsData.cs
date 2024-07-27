using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsPaymentsData
    {
        public static bool? Find(int? PaymentID, ref int? BookingID, ref int? ReturnID, ref string Details, ref decimal? InitialPaidTotalDueAmount, ref decimal? ActualTotalDueAmount, ref decimal? TotalRemaining, ref decimal? TotalRefundedAmount, ref DateTime? PaymentDate, ref DateTime? UpdatedPaymentDate, ref int? CreatedByUserID)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                BookingID = (int?)reader["BookingID"];
                                ReturnID = reader["ReturnID"] is DBNull ? null : int.TryParse(reader["ReturnID"].ToString(), out int result) ? result : (int?)null;
                                Details = reader["Details"] != DBNull.Value ? (string)reader["Details"] : null;
                                InitialPaidTotalDueAmount = (decimal?)reader["InitialPaidTotalDueAmount"];
                                ActualTotalDueAmount = reader["ActualTotalDueAmount"] is DBNull ? null : decimal.TryParse(reader["ActualTotalDueAmount"].ToString(), out decimal result1) ? result1 : (decimal?)null;
                                TotalRemaining = reader["TotalRemaining"] is DBNull ? null : decimal.TryParse(reader["TotalRemaining"].ToString(), out decimal result2) ? result2 : (decimal?)null;
                                TotalRefundedAmount = reader["TotalRefundedAmount"] is DBNull ? null : decimal.TryParse(reader["TotalRefundedAmount"].ToString(), out decimal result3) ? result3 : (decimal?)null;
                                PaymentDate = (DateTime?)reader["PaymentDate"];
                                UpdatedPaymentDate = (DateTime?)reader["UpdatedPaymentDate"];
                                CreatedByUserID = (int?)reader["CreatedByUserID"];
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
        
        public static bool? FindByBookingID(ref int? PaymentID, int? BookingID, ref int? ReturnID, ref string Details, ref decimal? InitialPaidTotalDueAmount, ref decimal? ActualTotalDueAmount, ref decimal? TotalRemaining, ref decimal? TotalRefundedAmount, ref DateTime? PaymentDate, ref DateTime? UpdatedPaymentDate, ref int? CreatedByUserID)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_FindByBookingID", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                PaymentID = (int?)reader["PaymentID"];
                                ReturnID = reader["ReturnID"] is DBNull ? null : int.TryParse(reader["ReturnID"].ToString(), out int result) ? result : (int?)null;
                                Details = reader["Details"] != DBNull.Value ? (string)reader["Details"] : null;
                                InitialPaidTotalDueAmount = (decimal?)reader["InitialPaidTotalDueAmount"];
                                ActualTotalDueAmount = reader["ActualTotalDueAmount"] is DBNull ? null : decimal.TryParse(reader["ActualTotalDueAmount"].ToString(), out decimal result1) ? result1 : (decimal?)null;
                                TotalRemaining = reader["TotalRemaining"] is DBNull ? null : decimal.TryParse(reader["TotalRemaining"].ToString(), out decimal result2) ? result2 : (decimal?)null;
                                TotalRefundedAmount = reader["TotalRefundedAmount"] is DBNull ? null : decimal.TryParse(reader["TotalRefundedAmount"].ToString(), out decimal result3) ? result3 : (decimal?)null;
                                PaymentDate = (DateTime?)reader["PaymentDate"];
                                UpdatedPaymentDate = (DateTime?)reader["UpdatedPaymentDate"];
                                CreatedByUserID = (int?)reader["CreatedByUserID"];
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
        public static int? AddNew(int? BookingID, int? ReturnID, string Details, decimal? InitialPaidTotalDueAmount, decimal? ActualTotalDueAmount, decimal? TotalRemaining, decimal? TotalRefundedAmount, DateTime? PaymentDate, DateTime? UpdatedPaymentDate, int? CreatedByUserID)
        {

            int? PaymentID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookingID", BookingID);
                        command.Parameters.AddWithValue("@ReturnID", ReturnID == null ? (object)DBNull.Value : ReturnID);
                        command.Parameters.AddWithValue("@Details", Details == null ? (object)DBNull.Value : Details);
                        command.Parameters.AddWithValue("@InitialPaidTotalDueAmount", InitialPaidTotalDueAmount);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount == null ? (object)DBNull.Value : ActualTotalDueAmount);
                        command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining == null ? (object)DBNull.Value : TotalRemaining);
                        command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount == null ? (object)DBNull.Value : TotalRefundedAmount);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                        command.Parameters.AddWithValue("@UpdatedPaymentDate", UpdatedPaymentDate);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        PaymentID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return PaymentID;
        }


        public static bool Update(int? PaymentID, int? BookingID, int? ReturnID, string Details, decimal? InitialPaidTotalDueAmount, decimal? ActualTotalDueAmount, decimal? TotalRemaining, decimal? TotalRefundedAmount, DateTime? PaymentDate, DateTime? UpdatedPaymentDate, int? CreatedByUserID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", PaymentID);
                        command.Parameters.AddWithValue("@BookingID", BookingID);
                        command.Parameters.AddWithValue("@ReturnID", ReturnID == null ? (object)DBNull.Value : ReturnID);
                        command.Parameters.AddWithValue("@Details", Details == null ? (object)DBNull.Value : Details);
                        command.Parameters.AddWithValue("@InitialPaidTotalDueAmount", InitialPaidTotalDueAmount);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount == null ? (object)DBNull.Value : ActualTotalDueAmount);
                        command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining == null ? (object)DBNull.Value : TotalRemaining);
                        command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount == null ? (object)DBNull.Value : TotalRefundedAmount);
                        command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                        command.Parameters.AddWithValue("@UpdatedPaymentDate", UpdatedPaymentDate);
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


        public static bool Delete(int? PaymentID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Payments_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PaymentID", PaymentID);

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
                    using (SqlCommand command = new SqlCommand("SP_Payments_GetAll", connection))
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

        public static int CountReturns()
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("select dbo.CountReturns()", Connection))
                    {
                        rowsAffected = (int)Command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return rowsAffected;
        }
        public static decimal GetTotalRevenueByMonth(int Month)
        {
            decimal rowsAffected = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand("select dbo.GetRevenueByMonth(@Month)", Connection))
                    {
                        Command.Parameters.AddWithValue("@Month", Month);

                        if (Command.ExecuteScalar() != DBNull.Value)
                            rowsAffected = (decimal)Command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                clsEventLog.EventLogger(ex.Message);
            }

            return rowsAffected;
        }
    }



}
