﻿using System.Diagnostics.CodeAnalysis;

namespace PresentationPartner.Models
{
    [ExcludeFromCodeCoverage]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
