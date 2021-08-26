using System;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        
        public ResourceOwnerPasswordValidator(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(context.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, context.Password))
                {
                    context.Result = new GrantValidationResult(
                        subject: user.Id.ToString(),
                        authenticationMethod: "custom",
                        claims: GetUserClaims(user));

                    return;
                }

                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
            catch (Exception ex)
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
        }

        public static Claim[] GetUserClaims(IdentityUser<Guid> user)
        {
            return new Claim[]
            {
                new Claim("user_id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
        }
    }
}