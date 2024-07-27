using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsBookAndPayData
    {
        public static bool BookAndPay(int? CustomerID, int? VehicleID, DateTime StartDate, DateTime EndDate, string DropoffLocation, string PickupLocation, decimal? PricePerDay, decimal? InitialTotalDueAmount, string Notes, string Status, int? ReturnID, string Details, decimal? InitialPaidTotalDueAmount, decimal? ActualTotalDueAmount, decimal? TotalRemaining, decimal? TotalRefundedAmount, DateTime? PaymentDate, DateTime? UpdatedPaymentDate, int? CreatedByUserID)
        {
            int? BookingID = null;
            int? PaymentID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();                    

                    try
                    {
                        // perform booking
                        SqlCommand bookCommand = new SqlCommand("SP_Bookings_AddNew", connection, transaction);

                        bookCommand.CommandType = CommandType.StoredProcedure;

                        bookCommand.Parameters.AddWithValue("@CustomerID", CustomerID);
                        bookCommand.Parameters.AddWithValue("@VehicleID", VehicleID);
                        bookCommand.Parameters.AddWithValue("@StartDate", StartDate);
                        bookCommand.Parameters.AddWithValue("@EndDate", EndDate);
                        bookCommand.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        bookCommand.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        bookCommand.Parameters.AddWithValue("@PricePerDay", PricePerDay);
                        bookCommand.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
                        bookCommand.Parameters.AddWithValue("@Notes", Notes == null ? (object)DBNull.Value : Notes);
                        bookCommand.Parameters.AddWithValue("@Status", Status);
                        bookCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        // Output parameter
                        SqlParameter outputBookParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputBookParameter.Direction = ParameterDirection.Output;
                        bookCommand.Parameters.Add(outputBookParameter);
                        bookCommand.ExecuteNonQuery();
                        BookingID = (int)outputBookParameter.Value;


                        // perform paying
                        SqlCommand payCommand = new SqlCommand("SP_Payments_AddNew", connection, transaction);

                        payCommand.CommandType = CommandType.StoredProcedure;

                        payCommand.Parameters.AddWithValue("@BookingID", BookingID);
                        payCommand.Parameters.AddWithValue("@ReturnID", ReturnID == null ? (object)DBNull.Value : ReturnID);
                        payCommand.Parameters.AddWithValue("@Details", Details == null ? (object)DBNull.Value : Details);
                        payCommand.Parameters.AddWithValue("@InitialPaidTotalDueAmount", InitialPaidTotalDueAmount);
                        payCommand.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount == null ? (object)DBNull.Value : ActualTotalDueAmount);
                        payCommand.Parameters.AddWithValue("@TotalRemaining", TotalRemaining == null ? (object)DBNull.Value : TotalRemaining);
                        payCommand.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount == null ? (object)DBNull.Value : TotalRefundedAmount);
                        payCommand.Parameters.AddWithValue("@PaymentDate", PaymentDate);
                        payCommand.Parameters.AddWithValue("@UpdatedPaymentDate", UpdatedPaymentDate);
                        payCommand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                        // Output parameter
                        SqlParameter outputPayParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputPayParameter.Direction = ParameterDirection.Output;
                        payCommand.Parameters.Add(outputPayParameter);
                        payCommand.ExecuteNonQuery();
                        PaymentID = (int)outputPayParameter.Value;



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

            return (BookingID != null && PaymentID != null);

        }
    }
}
