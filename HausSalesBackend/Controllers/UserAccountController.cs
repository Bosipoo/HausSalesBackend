using HausSalesBackend.Models;
using HausSalesBackend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HausSalesBackend.Controllers
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        // POST: api/Account/SignUp
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model, string role = "Admin")
        {
            var response = await _userAccountService.SignUpAsync(model, "Admin");
            return Ok(response);
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _userAccountService.LoginAsync(model);

            if (result == null)
                return Unauthorized(new { status = "error", message = "Invalid credentials" });

            return Ok(result);
        }


        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await _userAccountService.SignOutAsync();
            return Ok(new { message = "Signed out successfully" });
        }
        // GET: api/Account/ExternalLogin
        //[HttpGet("ExternalLogin")]
        //public IActionResult ExternalLogin(string provider, string returnUrl = null)
        //{
        //    var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });
        //    var properties = _userAccountService.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return Challenge(properties, provider);
        //}

        //// GET: api/Account/ExternalLoginCallback
        //[HttpGet("ExternalLoginCallback")]
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        //{
        //    if (remoteError != null)
        //        return RedirectToAction(nameof(Login), new { ReturnUrl = returnUrl });

        //    var token = await _userAccountService.ExternalLoginCallbackAsync();
        //    if (token == null)
        //        return Unauthorized(new { Message = "External login failed" });

        //    return Ok(new { Token = token });
        //}
    }
}