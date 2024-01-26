using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
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
