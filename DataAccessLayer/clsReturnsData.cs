using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsReturnsData
    {
        public static bool? Find(int? ReturnID, ref DateTime? ActualReturnDate, ref byte? ActualRentalDays, ref int? ConsumedMilage, ref string FinalCheckNotes, ref decimal? AdditionalCharges, ref decimal? ActualTotalDueAmount, ref int? CreatedByUserID)
        {
            bool? isFound = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Returns_Find", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ReturnID", ReturnID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                ActualReturnDate = (DateTime?)reader["ActualReturnDate"];
                                ActualRentalDays = (byte?)reader["ActualRentalDays"];
                                ConsumedMilage = (Int16)reader["ConsumedMilage"];
                                FinalCheckNotes = (string)reader["FinalCheckNotes"];
                                AdditionalCharges = (decimal?)reader["AdditionalCharges"];
                                ActualTotalDueAmount = (decimal?)reader["ActualTotalDueAmount"];
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
        public static int? AddNew(DateTime? ActualReturnDate, byte? ActualRentalDays, int? ConsumedMilage, string FinalCheckNotes, decimal? AdditionalCharges, decimal? ActualTotalDueAmount, int? CreatedByUserID)
        {

            int? ReturnID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Returns_AddNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                        command.Parameters.AddWithValue("@ConsumedMilage", ConsumedMilage);
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        // Output parameter
                        SqlParameter outputParameter = new SqlParameter("@NewID", SqlDbType.Int);
                        outputParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outputParameter);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Retrieve the output parameter value
                        ReturnID = (int)outputParameter.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                //Console.WriteLine("Database connection error: " + ex.Message);
                clsEventLog.EventLogger(ex.Message);
            }

            return ReturnID;
        }


        public static bool Update(int? ReturnID, DateTime? ActualReturnDate, byte? ActualRentalDays, int? ConsumedMilage, string FinalCheckNotes, decimal? AdditionalCharges, decimal? ActualTotalDueAmount, int? CreatedByUserID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Returns_Update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ReturnID", ReturnID);
                        command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                        command.Parameters.AddWithValue("@ConsumedMilage", ConsumedMilage);
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
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


        public static bool Delete(int? ReturnID)
        {

            int? rowsAffected = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_Returns_Delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ReturnID", ReturnID);

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
                    using (SqlCommand command = new SqlCommand("SP_Returns_GetAll", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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
