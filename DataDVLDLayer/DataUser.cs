using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataDVLDLayer
{
    public class clsDataUser
    {
        public static DataTable GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string quere = @"select Users.UserID ,People.PersonID,
            People.FirstName + ' ' + People.SecondName + ' ' +
            ISNULL(People.ThirdName,'')+ ' ' + People.LastName 
            as FullName, Users.UserName, Users.IsActive from Users join People
            on People.PersonID = Users.PersonID;";

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


        public static bool GetUserInfoByID(int UserID, ref int PersonID,
           ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string quere = "select * from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(quere, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

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



        public static bool GetUserInfoByNationalNo(string NationalNo, ref int UserID, 
            ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = @"select Users.UserID ,People.PersonID, Users.UserName, Users.Password,
                            People.NationalNo, Users.IsActive from Users join People
                            on People.PersonID = Users.PersonID
                            where NationalNo = @NationalNo";

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

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];                
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

        public static int AddUser( int PersonID,
            string UserName,  string Password,  bool IsActive)
        {

            int UserID = -1;

            string quere = @"INSERT INTO [dbo].[Users]
           ([PersonID]
           ,[UserName]
           ,[Password]
           ,[IsActive])
            VALUES (@PersonID
           ,@UserName
           ,@Password
           ,@IsActive) 
                select SCOPE_IDENTITY();";


            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                Object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return UserID;

        }

        public static bool UpdateUser(int UserID, int PersonID,
            string UserName, string Password, bool IsActive)
        {
            int result = 0;
            string quere = @"UPDATE [dbo].[Users]
             SET [PersonID] = @PersonID
            ,[UserName] = @UserName
            ,[Password] = @Password
            ,[IsActive] = @IsActive
                 WHERE UserID = @UserID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            

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


        public static bool DeleteUserByID(int UserID)
        {
            int result = 0;
            string quere = "DELETE FROM [dbo].[Users] WHERE UserID = @UserID";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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
            return (result > 0);
        }

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool IsUserExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = @"select Found=1 from Users join People
            on People.PersonID = Users.PersonID where NationalNo = @NationalNo";

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

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string query = @"select Found=1 from Users join People
            on People.PersonID = Users.PersonID where People.PersonID = @PersonID";

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

        public static bool isAllowedForLogin(string UserName,string Password)
        {
            bool isAllowed = false;

            string quere = "select found = 1 from Users" +
                " where UserName = @UserName and Password = @Password and IsActive = 1";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isAllowed = reader.HasRows;

                reader.Close();
            }
            catch(Exception ex)
            {
                isAllowed = false;
            }
            finally
            {
                connection.Close();
            }

            return isAllowed;
        }

        public static bool isUserNameUserAvailable(string UserName)
        {
            bool isAvailable = false;

            string quere = "select found = 1 from Users where UserName = @UserName ";

            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);
            SqlCommand command = new SqlCommand(quere, connection);

            command.Parameters.AddWithValue("@UserName", UserName);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isAvailable = false;
                }
                else
                {
                    isAvailable = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isAvailable = false;
            }
            finally
            {
                connection.Close();
            }

            return isAvailable;
        }



        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password
            ,ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsConnection.ConnectionString);

            string quere = "select * from Users where UserName = @UserName " +
                "and Password = @Password";

            SqlCommand command = new SqlCommand(quere, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);



            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];

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
    }
}
