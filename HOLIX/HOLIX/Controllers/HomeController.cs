using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HOLIX.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace HOLIX.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<User> users = new List<User>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = "";
        }

        public IActionResult Index()
        {
            FetchData();
            return View(users);
        }

        private void FetchData()
        {
            if (users.Count > 0)
            {
                users.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT * FROM[dbo].[TUSER] INNER JOIN[dbo].[TADDRESS] ON TUSER.USERID = TADDRESS.USERID; ";
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
