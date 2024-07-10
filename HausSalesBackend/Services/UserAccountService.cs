using HausSalesBackend.Models;
using HausSalesBackend.Services.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HausSalesBackend.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public UserAccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        public async Task<object> SignUpAsync(SignUpModel model, string role)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Avatar = "https://www.mecallapi.com/users/1.png" // Example avatar URL, you might want to make this dynamic
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Check if the role exists
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    var applicationRole = new ApplicationRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper(),
                        Description = $"{role} role",
                        CreatedDate = DateTime.UtcNow
                    };
                    await _roleManager.CreateAsync(applicationRole);
                }

                // Assign the role to the user
                await _userManager.AddToRoleAsync(user, role);

                // Generate JWT token
                var token = GenerateJwtToken(user);

                // Return the custom response
                return new
                {
                    status = "ok",
                    message = "Signed up successfully",
                    accessToken = token,
                    user = new
                    {
                        id = user.Id,
                        fname = user.FirstName,
                        lname = user.LastName,
                        username = user.UserName,
                        email = user.Email,
                        avatar = user.Avatar
                    }
                };
            }

            return new
            {
                status = "error",
                message = "Signup failed",
                errors = result.Errors
            };
        }


        public async Task<object> LoginAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return new
                {
                    status = "error",
                    message = "Login failed"
                };
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = GenerateJwtToken(user);

            // Return the custom response
            return new
            {
                status = "ok",
                message = "Logged in",
                accessToken = token,
                user = new
                {
                    id = user.Id,
                    fullname = user.FirstName,
                    lastname = user.LastName,
                    username = user.UserName,
                    email = user.Email,
                    avatar = user.Avatar
                }
            };
        }


        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<string> ExternalLoginAsync(ExternalLoginModel model)
        {
            var info = new UserLoginInfo(model.Provider, model.IdToken, model.Provider);

            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                // Create a new user account using the information from the external login provider
                var email = info.ProviderKey; // For simplicity, using ProviderKey as email, you can parse this as needed
                user = new ApplicationUser { UserName = email, Email = email };
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded) return null;

                result = await _userManager.AddLoginAsync(user, info);
                if (!result.Succeeded) return null;
            }

            // Sign in the user with this external login provider
            await _signInManager.SignInAsync(user, isPersistent: false);

            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> ExternalLoginCallbackAsync()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return null;

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (user == null) return null;

                // Generate JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }

            return null;
        }

        public AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
