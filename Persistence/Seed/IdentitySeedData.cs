using ApplicationCore.Common.Interfaces.SeedData;
using Microsoft.AspNetCore.Identity;
using Persistence.Identity;

namespace Persistence.Seed
{
    public class IdentitySeedData : ISeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        private readonly UserManager<ApplicationUser> _userManager;

        public IdentitySeedData(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async void Initialize()
        {
            var user = await _userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser() { UserName = "Admin" };
                await _userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
