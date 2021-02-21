using System.Collections.Generic;
using System.Data;
using HOLIX.Models;

namespace Database.Lib
{
    /// <summary>
    /// Database parameter class.
    /// </summary>
    public partial class DbParam
    {
        /// <summary>
        /// Sets the parameters to be used in querys.
        /// </summary>
        /// <param name="user">User instance.</param>
        /// <returns>List of Dbparam.</returns>
        public static List<DbParam> InitializeParams(User user)
        {
            List<DbParam> parameters = new List<DbParam>
            {
              new DbParam
              {
                ParameterName = "@UserID",
                Value = user.UserID,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@Name",
                Value = user.Name,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@Email",
                Value = user.Email,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@Login",
                Value = user.Login,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@Pass",
                Value = user.Password,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressID",
                Value = user.AddressID,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressStreet",
                Value = user.AddressStreet,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressNumber",
                Value = user.AddressNumber,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressComplement",
                Value = user.AddressComplement,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressNeighborhood",
                Value = user.AddressNeighborhood,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressPostalCode",
                Value = user.AddressPostalCode,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressCity",
                Value = user.AddressCity,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressState",
                Value = user.AddressState,
                DbType = DbType.String,
              },
              new DbParam
              {
                ParameterName = "@AddressCountry",
                Value = user.AddressCountry,
                DbType = DbType.String,
              },
            };

            return parameters;
        }
    }
}
