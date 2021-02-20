using System.Data;

namespace Database.Lib
{
    /// <summary>
    /// Database parameter class.
    /// </summary>
    public partial class DbParam
    {
        /// <summary>
        /// Gets or sets parameter name.
        /// </summary>
        /// <value>Parameter name.</value>
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets parameter value.
        /// </summary>
        /// <value>Parameter value.</value>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets parameter type.
        /// </summary>
        /// <value>Parameter type.</value>
        public DbType DbType { get; set; }
    }
}