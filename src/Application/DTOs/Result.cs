﻿using System.Diagnostics.CodeAnalysis;

namespace Application.DTOs
{
    [ExcludeFromCodeCoverage]
    public class Result
    {
        /// <summary>
        /// Booleand indicates response status.
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Message of response.
        /// </summary>
        public string Message { get; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
