namespace Application.User.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Token service abstration.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<string> GenerateAToken(string email, string password);
    }
}