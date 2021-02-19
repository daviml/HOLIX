using System;

namespace HOLIX.Models
{
    /// <summary>
    /// Error view model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets request id.
        /// </summary>
        /// <value>Request id.</value>
        public string RequestId { get; set; }

        /// <summary>
        /// Identifies wether show request id.
        /// </summary>
        /// <returns>True: shows | False: not show.</returns>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
