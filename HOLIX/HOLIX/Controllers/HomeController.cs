using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Database.Lib;
using HOLIX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HOLIX.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Identifies if is user edition or addition.
        /// </summary>
        public static bool IsEdit = false;

        private SqlCommand com = new SqlCommand();

        private SqlDataReader dr;

        private SqlConnection con = new SqlConnection();

        private List<User> users = new List<User>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="configuration">Configuration settings.</param>
        /// <param name="logger">Logger.</param>
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            this.con.ConnectionString = configuration.GetConnectionString("DatabaseConn");
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>View with users.</returns>
        public IActionResult Index()
        {
            this.FetchData(string.Empty);
            return this.View(this.users);
        }

        /// <summary>
        /// Opens the Action form for User, with the intend of Register.
        /// </summary>
        /// <param name="userInstance">User instance.</param>
        /// <returns>View of Cadaster Register/Update.</returns>
        public IActionResult Register(User userInstance)
        {
            IsEdit = false;
            return this.View("UserAction", new User());
        }

        /// <summary>
        /// Opens the Action form for User, with intend of Update.
        /// </summary>
        /// <param name="userCode">User code.</param>
        /// <returns>View of Cadaster Register/Update.</returns>
        public IActionResult Update(string userCode)
        {
            IsEdit = true;

            string filter = $"WHERE USR.USERID = '{userCode}'";

            this.FetchData(filter);

            User userInstance = this.users[0];

            return this.View("UserAction", userInstance);
        }

        /// <summary>
        /// Saves or updates user on database.
        /// </summary>
        /// <param name="userInstance">User instance.</param>
        /// <returns>Redirects to index Action.</returns>
        [HttpPost]
        public IActionResult Save(User userInstance)
        {
            this.con.Open();

            if (!IsEdit)
            {
                userInstance.AddressID = Guid.NewGuid().ToString();
                userInstance.UserID = Guid.NewGuid().ToString();
            }

            List<DbParam> parameters = DbParam.InitializeParams(userInstance);

            string[] querys = this.FillQueryString(IsEdit);

            Models.User.SaveData(this.con, querys, parameters, out string errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine(errorMessage);
            }

            this.con.Close();
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Mount querys based on intended action (Insert/Update).
        /// </summary>
        /// <param name="isEdit">Boolean to inform if action is insert or update.</param>
        /// <returns>Update or insert querys.</returns>
        public string[] FillQueryString(bool isEdit)
        {
            string[] querys = new string[2];

            if (!isEdit)
            {
                querys[0] = "INSERT INTO [dbo].[TUSER](USERID, EMAIL, LOGIN, PASSWORD, NAME) VALUES (@UserID, @Email, @Login, @Pass, @Name)";

                querys[1] = "INSERT INTO [dbo].[TADDRESS](ADDRESSID, USERID, CITY, COMPLEMENT, COUNTRY, NEIGHBORHOOD, NUMBER, POSTALCODE, STATE, STREET) " +
                    "VALUES (@AddressID, @UserID, @AddressCity, @AddressComplement, @AddressCountry, @AddressNeighborhood, @AddressNumber, @AddressPostalCode, @AddressState, @AddressStreet)";
            }
            else
            {
                querys[0] = "UPDATE [dbo].[TUSER] SET EMAIL = @Email, PASSWORD = @Pass, LOGIN = @Login, NAME = @Name WHERE USERID = @UserID";

                querys[1] = "UPDATE [dbo].[TADDRESS] SET CITY = @AddressCity, COMPLEMENT = @AddressComplement, COUNTRY = @AddressCountry, " +
                    "NEIGHBORHOOD = @AddressNeighborhood, NUMBER = @AddressNumber, POSTALCODE = @AddressPostalCode, STATE = @AddressState, STREET = @AddressStreet " +
                    "WHERE ADDRESSID = @AddressID";
            }

            return querys;
        }

        /// <summary>
        /// Get users in database and their addresses.
        /// </summary>
        private void FetchData(string filter)
        {
            if (this.users.Count > 0)
            {
                this.users.Clear();
            }

            try
            {
                this.con.Open();
                this.com.Connection = this.con;
                this.com.CommandText = $@" SELECT USR.USERID,
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

                this.dr = this.com.ExecuteReader();

                while (this.dr.Read())
                {
                    this.users.Add(new User()
                    {
                        UserID = this.dr["USERID"].ToString(),
                        AddressID = this.dr["ADDRESSID"].ToString(),
                        Email = this.dr["EMAIL"].ToString(),
                        Login = this.dr["LOGIN"].ToString(),
                        Name = this.dr["NAME"].ToString(),
                        Password = this.dr["PASSWORD"].ToString(),
                        AddressCity = this.dr["CITY"].ToString(),
                        AddressComplement = this.dr["COMPLEMENT"].ToString(),
                        AddressCountry = this.dr["COUNTRY"].ToString(),
                        AddressNeighborhood = this.dr["NEIGHBORHOOD"].ToString(),
                        AddressNumber = this.dr["NUMBER"].ToString(),
                        AddressPostalCode = this.dr["POSTALCODE"].ToString(),
                        AddressState = this.dr["STATE"].ToString(),
                        AddressStreet = this.dr["STREET"].ToString(),
                    });
                }

                this.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
