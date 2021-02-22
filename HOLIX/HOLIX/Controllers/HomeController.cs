using System;
using System.Collections.Generic;
using HOLIX.Models;
using HOLIX.Repository;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Users list.
        /// </summary>
        /// <returns>List of users.</returns>
        private List<User> users = new List<User>();

        /// <summary>
        /// User repository.
        /// </summary>
        private UserRepository userRepos;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="userRepos">User repository.</param>
        public HomeController(UserRepository userRepos)
        {
            this.userRepos = userRepos;
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
        /// <returns>View of Cadaster Register/Update.</returns>
        public IActionResult Register()
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
            if (!IsEdit)
            {
                userInstance.AddressID = Guid.NewGuid().ToString("N");
                userInstance.UserID = Guid.NewGuid().ToString("N");
            }

            this.userRepos.InsertUpdateUser(IsEdit, userInstance);

            return this.RedirectToAction("Index");
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
                this.users = this.userRepos.SelectUsers(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
