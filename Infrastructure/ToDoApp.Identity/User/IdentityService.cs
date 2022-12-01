
using Microsoft.AspNetCore.Identity;

using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Generics;

namespace ToDoApp.Identity.User
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded;
        }

        public async Task<Result> RegisterUser(string email, string password)
        {
            var identity = new ApplicationUser { UserName = email, Email = email };
            var identityResult = await _userManager.CreateAsync(identity, password);

            return identityResult.Succeeded
                    ? Result.Ok()
                    : Result.Fail(identityResult.Errors.Select(x => x.Description).Aggregate((a, b) => a + "; " + b));
        }
    }
}
