using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOLIX.Models
{
    public class User
    {
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        /// <value>User id.</value>
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>Name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>Email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>Login.</value>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>Password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the address id.
        /// </summary>
        /// <value>Address id.</value>
        public string AddressID { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>Street.</value>
        public string AddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>Number.</value>
        public string AddressNumber { get; set; }

        /// <summary>
        /// Gets or sets the complement.
        /// </summary>
        /// <value>Complement.</value>
        public string AddressComplement { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>Neighborhood.</value>
        public string AddressNeighborhood { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>Postal code.</value>
        public string AddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>City.</value>
        public string AddressCity { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>State.</value>
        public string AddressState { get; set; }

        /// <summary>
        /// Gets or sets the coutry.
        /// </summary>
        /// <value>Country.</value>
        public string AddressCountry { get; set; }
    }
}
