namespace AuthCoffeeTime.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        ///Set a code for confirm email
        /// </summary>
        /// <param name="email">Email to which the code should be sent</param>
        /// <returns>Return code which need for confirm email</returns>
        Task<int> SendCode(string email);
    }
}
