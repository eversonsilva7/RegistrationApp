using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Integration
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string Error { get; set; }

        public int ClientId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public Client Client { get; set; }
    }
}
