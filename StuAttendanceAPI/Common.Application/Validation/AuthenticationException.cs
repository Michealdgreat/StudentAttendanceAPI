

namespace Common.Application.Validation
{
    /// <summary>
    /// Used in Authentication scenario where a process fail during user's authentication.
    /// </summary>
    public class AuthenticationException : Exception
    {
        public string? Details { get; set; }
        /// <summary>
        /// This constructor provide custom message about the exception in relation to where its been used.
        /// </summary>
        /// <param name="message">custom message</param>
        public AuthenticationException(string message) : base(message)
        {
        }
        public AuthenticationException(string message, string details) : base(message)
        {
            Details = details;
        }
    }
}

