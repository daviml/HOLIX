using System.ComponentModel.DataAnnotations;

namespace HOLIX.Models
{
    public partial class User
    {
        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        /// <value>User id.</value>
        [Display(Name = "Código do Usuário")]
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>Name.</value>
        [Display(Name = "Nome completo")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>Email.</value>
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>Login.</value>
        [Display(Name = "Login")]
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>Password.</value>
        [Display(Name = "Senha")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the address id.
        /// </summary>
        /// <value>Address id.</value>
        [Display(Name = "Código do endereço")]
        public string AddressID { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>Street.</value>
        [Display(Name = "Rua")]
        public string AddressStreet { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>Number.</value>
        [Display(Name = "Número da residência")]
        public string AddressNumber { get; set; }

        /// <summary>
        /// Gets or sets the complement.
        /// </summary>
        /// <value>Complement.</value>
        [Display(Name = "Complemento")]
        public string AddressComplement { get; set; }

        /// <summary>
        /// Gets or sets the neighborhood.
        /// </summary>
        /// <value>Neighborhood.</value>
        [Display(Name = "Bairro")]
        public string AddressNeighborhood { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>Postal code.</value>
        [Display(Name = "CEP")]
        public string AddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>City.</value>
        [Display(Name = "Cidade")]
        public string AddressCity { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>State.</value>
        [Display(Name = "Estado")]
        public string AddressState { get; set; }

        /// <summary>
        /// Gets or sets the coutry.
        /// </summary>
        /// <value>Country.</value>
        [Display(Name = "País")]
        public string AddressCountry { get; set; }
    }
}
