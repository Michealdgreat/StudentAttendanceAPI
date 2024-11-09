using Common.Domain.Bases;

namespace Common.Domain.Exceptions
{
    /// <summary>
    /// Throws an exception if any related user data cannot be fetched while processing any user related logic. 
    /// </summary>
    public class InvalidDomainDataException : BaseDomainException
    {
        public InvalidDomainDataException()
        {

        }
        public InvalidDomainDataException(string message) : base(message)
        {

        }
    }
}