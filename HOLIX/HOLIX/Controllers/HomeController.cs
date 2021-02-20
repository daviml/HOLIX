using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HOLIX.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Database.Lib;

namespace HOLIX.Controllers
{


    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        public static bool isEdit = false;
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<User> users = new List<User>();
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = "{ Your connection strings here }";
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>View with users.</returns>
        public IActionResult Index()
        {
            FetchData("");
            return View(users);
        }

        /// <summary>
        /// Opens the Action form for User
        /// </summary>
        /// <param name="userInstance">User instance</param>
        /// <returns>View of Cadaster Register/Update</returns>
        public IActionResult Register(User userInstance)
        {
            isEdit = false;
            return View("UserAction", new User()); 
        }

        /// <summary>
        /// Saves or updates user on database
        /// </summary>
        /// <param name="userInstance">User instance</param>
        /// <returns>Redirects to index Action</returns>
        [HttpPost]
        public IActionResult Save(User userInstance)
        {
            con.Open();
            string errorMessage = string.Empty; 

            if (!isEdit)
            {
                userInstance.AddressID = Guid.NewGuid().ToString();
                userInstance.UserID = Guid.NewGuid().ToString(); 
            }

            List<DbParam> parameters = DbParam.InitializeParams(userInstance);  

            string[] querys = FillQueryString(isEdit); 

            Models.User.SaveData(con, querys, parameters, out errorMessage); 

            con.Close(); 
            return RedirectToAction("Index"); 
        }

        /// <summary>
        /// Mount querys based on intended action (Insert/Update) 
        /// </summary>
        /// <param name="isEdit">Boolean to inform if action is insert or update</param>
        /// <returns></returns>
        public string[] FillQueryString(bool isEdit)
        {
            string[] querys = new string[2];

            if(!isEdit)
            {
                querys[0] = "INSERT INTO [dbo].[TUSER](USERID, ADDRESSID, EMAIL, LOGIN, PASSWORD, NAME) VALUES (@UserID, @AddressID, @Email, @Login, @Pass, @Name)";

                querys[1] = "INSERT INTO [dbo].[TADDRESS](ADDRESSID, USERID, CITY, COMPLEMENT, COUNTRY, NEIGHBORHOOD, NUMBER, POSTALCODE, STATE, STREET) " +
                    "VALUES (@AddressID, @UserID, @AddressCity, @AddressComplement, @AddressCountry, @AddressNeighborhood, @AddressNumber, @AddressPostalCode, @AddressState, @AddressStreet)";
            }
            else
            {
                querys[0] = "UPDATE [dbo].[TUSER] SET EMAIL = @Email, PASSWORD = @Pass, NAME = @Name WHERE USERID = @UserID";

                querys[1] = "UPDATE [dbo].[TADDRESS] SET CITY = @AddressCity, COMPLEMENT = @AddressComplement, COUNTRY = @AddressCountry " +
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
            if (users.Count > 0)
            {
                users.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = $"SELECT * FROM[dbo].[TUSER] INNER JOIN[dbo].[TADDRESS] ON TUSER.USERID = TADDRESS.USERID {filter}; ";
                dr = com.ExecuteReader();
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
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
