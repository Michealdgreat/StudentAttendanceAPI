using System;

namespace Common.Application.Validation
{
    public class InvalidCommandException : Exception
    {
        public string? Details { get; }

        public InvalidCommandException()
        {

        }
        /// <summary>
        /// Throws an exception message with a custom message
        /// </summary>
        /// <param name="message"> message is passed through the constructor</param>
        public InvalidCommandException(string message) : base(message)
        {


        }
        /// <summary>
        /// Throws an exception message with a custom message and Additional details
        /// </summary>
        /// <param name="message"> Exception message</param>
        /// <param name="details">Additional Details</param>
        public InvalidCommandException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}