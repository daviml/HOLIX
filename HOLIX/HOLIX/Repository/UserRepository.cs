using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Database.Lib;
using HOLIX.Database;
using HOLIX.Models;

namespace HOLIX.Repository
{
    /// <summary>
    /// User repository class.
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// Mount querys based on intended action (Insert/Update).
        /// </summary>
        /// <param name="isEdit">Boolean to inform if action is insert or update.</param>
        /// <param name="user">User data.</param>
        public void InsertUpdateUser(bool isEdit, User user)
        {
            SqlConnection connection = Connection.Conn;

            List<string> querys = new List<string>();

            if (!isEdit)
            {
                querys.Add("INSERT INTO [dbo].[TUSER](USERID, EMAIL, LOGIN, PASSWORD, NAME) VALUES (@UserID, @Email, @Login, @Pass, @Name)");

                querys.Add("INSERT INTO [dbo].[TADDRESS](ADDRESSID, USERID, CITY, COMPLEMENT, COUNTRY, NEIGHBORHOOD, NUMBER, POSTALCODE, STATE, STREET) " +
                    "VALUES (@AddressID, @UserID, @AddressCity, @AddressComplement, @AddressCountry, @AddressNeighborhood, @AddressNumber, @AddressPostalCode, @AddressState, @AddressStreet)");
            }
            else
            {
                querys.Add("UPDATE [dbo].[TUSER] SET EMAIL = @Email, PASSWORD = @Pass, LOGIN = @Login, NAME = @Name WHERE USERID = @UserID");

                querys.Add("UPDATE [dbo].[TADDRESS] SET CITY = @AddressCity, COMPLEMENT = @AddressComplement, COUNTRY = @AddressCountry, " +
                    "NEIGHBORHOOD = @AddressNeighborhood, NUMBER = @AddressNumber, POSTALCODE = @AddressPostalCode, STATE = @AddressState, STREET = @AddressStreet " +
                    "WHERE ADDRESSID = @AddressID");
            }

            List<DbParam> parameters = DbParam.InitializeParams(user);
            Database.DatabaseCommands.ExecuteCommands(connection, querys, parameters, out string errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine(errorMessage);
            }
        }

        /// <summary>
        /// Select all users and their addresses.
        /// </summary>
        /// <param name="filter">Select filter.</param>
        /// <returns>List with all users.</returns>
        public List<User> SelectUsers(string filter)
        {
            SqlConnection connection = Connection.Conn;
            List<User> users = new List<User>();

            SqlCommand com = new SqlCommand
            {
                Connection = connection,
            };

            com.CommandText = $@" SELECT USR.USERID,
                                        ADR.ADDRESSID,
                                        USR.EMAIL,
                                        USR.LOGIN,
                                        USR.NAME,
                                        USR.PASSWORD,
                                        ADR.CITY,
                                        ADR.COMPLEMENT,
                                        ADR.COUNTRY,
                                        ADR.NEIGHBORHOOD,
                                        ADR.NUMBER,
                                        ADR.POSTALCODE,
                                        ADR.STATE,
                                        ADR.STREET
                                        FROM[dbo].[TUSER] USR INNER JOIN[dbo].[TADDRESS] ADR ON USR.USERID = ADR.USERID
                                    {filter}; ";

            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                users.Add(new User()
                {
                    UserID = dr["USERID"].ToString(),
                    AddressID = dr["ADDRESSID"].ToString(),
                    Email = dr["EMAIL"].ToString(),
                    Login = dr["LOGIN"].ToString(),
                    Name = dr["NAME"].ToString(),
                    Password = dr["PASSWORD"].ToString(),
                    AddressCity = dr["CITY"].ToString(),
                    AddressComplement = dr["COMPLEMENT"].ToString(),
                    AddressCountry = dr["COUNTRY"].ToString(),
                    AddressNeighborhood = dr["NEIGHBORHOOD"].ToString(),
                    AddressNumber = dr["NUMBER"].ToString(),
                    AddressPostalCode = dr["POSTALCODE"].ToString(),
                    AddressState = dr["STATE"].ToString(),
                    AddressStreet = dr["STREET"].ToString(),
                });
            }

            connection.Close();

            return users;
        }
    }
}
