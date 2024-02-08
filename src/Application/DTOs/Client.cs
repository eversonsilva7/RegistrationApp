namespace Application.DTOs
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Client model.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Cellphone { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsIntegrated { get; set; }
    }
}
