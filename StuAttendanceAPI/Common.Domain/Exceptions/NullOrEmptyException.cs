using Common.Domain.Bases;

namespace Common.Domain.Exceptions
{
    /// <summary>
    /// Throws an exception when parameter or return value is null 
    /// </summary>
    public class NullOrEmptyException : BaseDomainException
    {
        public NullOrEmptyException()
        {

        }

        public NullOrEmptyException(string message) : base(message)
        {

        }

    }
}