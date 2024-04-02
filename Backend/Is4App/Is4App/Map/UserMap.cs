using DomainApp.Models;
using Is4App.ViewModels;

namespace Is4App.Map
{
    public class UserMap
    {
        /// <summary>
        /// Mapl registration`s model of request with domain`s model of login
        /// </summary>
        /// <param name="request">Request of registration</param>
        /// <returns>Domain`s model of registration</returns>
        public RegistrationViewModel MapWith(RegistrationUserRequest request) =>
            new RegistrationViewModel()
            {
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,
                NumberPhone = request.NumberPhone,
            };


        /// <summary>
        /// Map Login`s model of request with domain`s model of login
        /// </summary>
        /// <param name="request">Request of login</param>
        /// <returns>Domain`s model of login</returns>
        public LoginViewModel MapWith(LoginUserRequest request) =>
            new LoginViewModel()
            {
                UserName = request.UserName,
                Password = request.Password,
            };
    }
}
