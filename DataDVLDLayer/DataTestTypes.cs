using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDVLDLayer
{
    public class clsDataTestTypes
    {
        public static DataTable GetAllTestType()
        {
            DataTable dataTable = new DataTable();

            string quere = "select * from TestTypes";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle,
            string TestTypeDescription, decimal TestTypeFees)
        {
            int result = 0;

            string quere = @"UPDATE [dbo].[TestTypes]
             SET [TestTypeTitle] = @TestTypeTitle
            ,[TestTypeDescription] = @TestTypeDescription
             ,[TestTypeFees] = @TestTypeFees
                WHERE TestTypeID = @TestTypeID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);


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

        public static bool isTestTypeExist(int TestTypeID)
        {
            bool isFound = false;

            string quere = @"select found = 1 from TestTypes 
                where TestTypeID = @TestTypeID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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

        public static bool GetTestTypeInfoByID(int TestTypeID, ref string TestTypeTitle
            , ref string TestTypeDescription, ref decimal TestTypeFees)
        {
            bool isFound = false;

            string quere = @"select * from TestTypes 
                where TestTypeID = @TestTypeID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = (decimal)reader["TestTypeFees"];

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
