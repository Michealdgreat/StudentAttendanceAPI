using Common.Domain.Bases;

namespace Common.Domain.Exceptions
{
    /// <summary>
    /// Throws is user cannot be found
    /// </summary>
    public class UserNotFoundException : BaseDomainException
    {
        public UserNotFoundException()
        {

        }

        public static void Check()
        {
            throw new NotImplementedException("Not Found!");
        }
    }
}