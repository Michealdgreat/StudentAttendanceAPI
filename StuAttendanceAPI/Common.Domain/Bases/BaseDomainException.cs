namespace Common.Domain.Bases
{

    /// <summary>
    /// This is a base exception class where all other exception inherits from.
    /// </summary>
    public class BaseDomainException : Exception
    {
        public BaseDomainException()
        {

        }

        public BaseDomainException(string message) : base(message)
        {

        }
    }
}
