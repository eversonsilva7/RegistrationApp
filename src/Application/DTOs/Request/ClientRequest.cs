using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request
{
    /// <summary>
    /// Client request.
    /// </summary>
    public class ClientRequest
    {
        /// <summary>
        /// Name of client (max 50 characters)
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Document of client
        /// </summary>
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Invalid CPF format")]
        public string Document { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Cellphone for contact
        /// </summary>
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Invalid phone number format")]
        public string Cellphone { get; set; }
    }
}
