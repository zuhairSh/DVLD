using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataDVLDLayer
{
    public class clsDataApplicationType
    {
        public static DataTable GetAllApplicationType()
        {
            DataTable dataTable = new DataTable();

            string quere = "select * from ApplicationTypes";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                 if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID,string ApplicationTypeTitle
            , decimal ApplicationFees)
        {
            int result = 0;

            string quere = @"UPDATE [dbo].[ApplicationTypes]
              SET [ApplicationTypeTitle] = @ApplicationTypeTitle
                ,[ApplicationFees] = @ApplicationFees
                WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


            try
            {
                connection.Open();

                 result = command.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return result > 0;
        }

        public static bool isApplicationTypeExist(int ApplicationTypeID)
        {
            bool isFound = false;

            string quere = @"select found = 1 from ApplicationTypes 
                where ApplicationTypeID = @ApplicationTypeID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID,ref string ApplicationTypeTitle
            ,ref decimal ApplicationTypeFees)
        {
            bool isFound = false;

            string quere = @"select * from ApplicationTypes 
                where ApplicationTypeID = @ApplicationTypeID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                if(reader.Read())
                {
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationTypeFees = (decimal)reader["ApplicationFees"];
                    isFound = true;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
