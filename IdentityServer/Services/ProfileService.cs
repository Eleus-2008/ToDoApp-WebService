using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Services
{
    public class ProfileService : IProfileService
    {
        //services
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public ProfileService(UserManager<IdentityUser<Guid>> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                if (!string.IsNullOrEmpty(context.Subject.Identity.Name))
                {
                    var user = await _userManager.FindByNameAsync(context.Subject.Identity.Name);

                    if (user != null)
                    {
                        var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);

                        context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                    }
                }
                else
                {
                    var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

                    if (!string.IsNullOrEmpty(userId?.Value))
                    {
                        var user = await _userManager.FindByIdAsync(userId.Value);

                        if (user != null)
                        {
                            var claims = ResourceOwnerPasswordValidator.GetUserClaims(user);

                            context.IssuedClaims =
                                claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log your error
            }
        }

        public async Task IsActiveAsync(IsActiveContext context) => context.IsActive = true;
    }
}