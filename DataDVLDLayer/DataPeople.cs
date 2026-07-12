using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataDVLDLayer
{
    public class clsDataPeople
    {
        public static DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string quere = @"select People.PersonID ,People.NationalNo ,People.FirstName,People.SecondName
             ,People.ThirdName,People.LastName, People.DateOfBirth,
             Case
             When People.Gendor = 0 then 'Male'
             else 'Female'
             end as GendorCaption
             ,People.Address, People.Email,People.Phone,Countries.CountryName,People.ImagePath From People join Countries
             on People.NationalityCountryID = Countries.CountryID 
             order by People.FirstName;";
             
            SqlCommand command = new SqlCommand(quere, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);

                    reader.Close();
                }

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


        public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName,
           ref string SeccondName, ref string TherdName, ref string LastName, ref string Email, ref string Phone, ref string Address,
           ref DateTime DateOfBirth, ref int CountryID, ref byte Gendor, ref string ImagePath)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string quere = "SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(quere, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];

                    SeccondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        TherdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        TherdName = "";
                    }

                    LastName = (string)reader["LastName"];

                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    Gendor = Convert.ToByte(reader["Gendor"]); 
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["NationalityCountryID"];

                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : "";
                    Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : "";

                    reader.Close();
                }
                else
                {
                    isFound = false;
                }
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


        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
        ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
         ref byte Gendor, ref string Address, ref string Phone, ref string Email,
         ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    //ThirdName: allows null in database so we should handle null
                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    //Email: allows null in database so we should handle null
                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

                }
                else
                {
                    isFound = false;
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

        public static int AddPerson( string NationalNo,  string FirstName,
            string SecondName,  string ThirdName,  string LastName,  string Email,  string Phone,  string Address,
            DateTime DateOfBirth,  int CountryID,  byte Gendor,  string ImagePath)
        {

            int PersonID = -1;

            string quere = @"INSERT INTO [dbo].[People] 
                 ([NationalNo], [FirstName], [SecondName], [ThirdName], [LastName], 
                 [DateOfBirth], [Gendor], [Address], [Phone], [Email], [NationalityCountryID], [ImagePath]) 
                 VALUES 
                 (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName,
                 @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
                select SCOPE_IDENTITY();";


            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@NationalityCountryID", CountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar(); 

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;

        }

        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, string Email, string Phone, string Address,
            DateTime DateOfBirth, int CountryID, byte Gendor, string ImagePath)
        {
            int result = 0;
            string quere = @"UPDATE [dbo].[People]
                 SET [NationalNo] = @NationalNo,
                     [FirstName] = @FirstName,
                     [SecondName] = @SecondName,
                     [ThirdName] = @ThirdName,
                     [LastName] = @LastName,
                     [DateOfBirth] = @DateOfBirth,
                     [Gendor] = @Gendor,
                     [Address] = @Address,
                     [Phone] = @Phone,
                     [Email] = @Email,
                     [NationalityCountryID] = @CountryID,
                     [ImagePath] = @ImagePath
                 WHERE PersonID = @PersonID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);


            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "")
            {
                command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else
                command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
            {
                command.Parameters.AddWithValue("@Email", Email);
            }
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return result > 0;
        }


        public static bool DeletePersonByID(int PersonID)
        {
            int result = 0;
            string quere = "DELETE FROM [dbo].[People] WHERE PersonID = @PersonID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return (result > 0);
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

    }

}
