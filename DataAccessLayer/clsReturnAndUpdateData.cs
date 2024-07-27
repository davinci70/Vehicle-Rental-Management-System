using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsReturnAndUpdateData
    {
        public static bool ReturnAndUpdateDataAccordingly(DateTime? actualReturnDate, byte? actualRentalDays,
    int? consumedMilage, string finalCheckNotes, decimal? additionalCharges,
    decimal? actualTotalDueAmount, int? createdByUserID, decimal? totalRemaining,
    decimal? totalRefundedAmount, decimal? InitialPaidTotalDueAmount, int? VehicleID, int? Milage, int? PaymentID, int? BookingID)
        {
            int? ReturnID = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    SqlTransaction Transaction = Connection.BeginTransaction();

                    try
                    {
                        SqlCommand returnCommand = new SqlCommand("SP_Returns_AddNew", Connection, Transaction);
                        returnCommand.CommandType = CommandType.StoredProcedure;

                        returnCommand.Parameters.AddWithValue("@ActualReturnDate", actualReturnDate);
                        returnCommand.Parameters.AddWithValue("@ActualRentalDays", actualRentalDays);
                        returnCommand.Parameters.AddWithValue("@ConsumedMilage", consumedMilage);
                        returnCommand.Parameters.AddWithValue("@FinalCheckNotes", finalCheckNotes);
                        returnCommand.Parameters.AddWithValue("@AdditionalCharges", additionalCharges);
                        returnCommand.Parameters.AddWithValue("@ActualTotalDueAmount", actualTotalDueAmount);
                        returnCommand.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                        // Output parameter
                        SqlParameter outputReturnParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputReturnParameter.Direction = ParameterDirection.Output;
                        returnCommand.Parameters.Add(outputReturnParameter);
                        returnCommand.ExecuteNonQuery();
                        ReturnID = (int)outputReturnParameter.Value;

                        // --------------------------------------------------

                        SqlCommand updateReturnIDCommand = new SqlCommand("SP_Payments_UpdateReturnID", Connection, Transaction);
                        updateReturnIDCommand.CommandType = CommandType.StoredProcedure;
                        
                        updateReturnIDCommand.Parameters.AddWithValue("@PaymentID", PaymentID);
                        updateReturnIDCommand.Parameters.AddWithValue("@ReturnID", ReturnID);
                        
                        updateReturnIDCommand.ExecuteNonQuery();

                        // --------------------------------------------------

                        decimal? RefundedAmount = null;

                        if (InitialPaidTotalDueAmount > actualTotalDueAmount)
                            RefundedAmount = InitialPaidTotalDueAmount - actualTotalDueAmount;
                        else
                            RefundedAmount = 0;

                        SqlCommand paymentCommand = new SqlCommand("SP_Payments_UpdateByReturnID", Connection, Transaction);
                        paymentCommand.CommandType = CommandType.StoredProcedure;

                        paymentCommand.Parameters.AddWithValue("@ReturnID", ReturnID);
                        paymentCommand.Parameters.AddWithValue("@ActualTotalDueAmount", actualTotalDueAmount);
                        paymentCommand.Parameters.AddWithValue("@TotalRemaining", actualTotalDueAmount - InitialPaidTotalDueAmount);
                        paymentCommand.Parameters.AddWithValue("@TotalRefundedAmount", RefundedAmount);
                        paymentCommand.Parameters.AddWithValue("@UpdatedPaymentDate", DateTime.Now);

                        paymentCommand.ExecuteNonQuery();

                        // --------------------------------------------------

                        SqlCommand vehicleCommand = new SqlCommand("SP_Vehicles_UpdateAfterReturn", Connection, Transaction);
                        vehicleCommand.CommandType = CommandType.StoredProcedure;

                        vehicleCommand.Parameters.AddWithValue("@VehicleID", VehicleID);
                        vehicleCommand.Parameters.AddWithValue("@Milage", Milage + consumedMilage);
                        vehicleCommand.Parameters.AddWithValue("@IsAvailable", 1);

                        vehicleCommand.ExecuteNonQuery();

                        // --------------------------------------------------

                        SqlCommand bookingCommand = new SqlCommand("SP_Bookings_UpdateStatus", Connection, Transaction);
                        bookingCommand.CommandType = CommandType.StoredProcedure;

                        bookingCommand.Parameters.AddWithValue("@BookingID", BookingID);
                        bookingCommand.Parameters.AddWithValue("@Status", "Completed");

                        bookingCommand.ExecuteNonQuery();
                        Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                        // Log the exception
                        clsEventLog.EventLogger(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                //Console.WriteLine("Outer Exception: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return ReturnID != null;
        }

    }
}
