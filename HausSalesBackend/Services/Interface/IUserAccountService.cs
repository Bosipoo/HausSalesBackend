using HausSalesBackend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace HausSalesBackend.Services.Interface
{
    public interface IUserAccountService
    {
        Task<object> SignUpAsync(SignUpModel model, string role);
        Task<object> LoginAsync(LoginModel model);
        Task<string> ExternalLoginAsync(ExternalLoginModel model);
        Task<string> ExternalLoginCallbackAsync();
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl);
    }
}
