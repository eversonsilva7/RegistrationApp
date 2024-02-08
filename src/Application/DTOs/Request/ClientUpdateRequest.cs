using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Application.DTOs.Request
{
    /// <summary>
    /// Client update model.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ClientUpdateRequest
    {
        /// <summary>
        /// Client Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of client (max 50 characters)
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

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
