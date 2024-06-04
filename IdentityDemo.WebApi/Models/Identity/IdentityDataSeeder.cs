using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.WebApi.Models.Identity
{
    public class IdentityDataSeeder
    {
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityDataSeeder(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await CreateUserAsync(AdminUser, "P@ssword1");
            await CreateUserAsync(AliceUser, "P@ssword1");
            await CreateUserAsync(BobUser, "P@ssword1");
        }

        private async Task CreateUserAsync(IdentityUser user, string password)
        {
            var exists = await _userManager.FindByEmailAsync(user.Email);
            if (exists == null)
                await _userManager.CreateAsync(user, password);
        }

        private static IdentityUser AdminUser = new IdentityUser
        {
            Id = "b8633e2d-a33b-45e6-8329-1958b3252bbd",
            UserName = "admin@example.com",
            NormalizedUserName = "ADMIN",
            Email = "admin@example.com",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            EmailConfirmed = true,
        };

        private static IdentityUser AliceUser = new IdentityUser
        {
            Id = "de1e0d65-aa11-4953-b074-1ba0b825851b",
            UserName = "alice@example.com",
            NormalizedUserName = "ALICE",
            Email = "alice@example.com",
            NormalizedEmail = "ALICE@EXAMPLE.COM",
            EmailConfirmed = true,
        };

        private static IdentityUser BobUser = new IdentityUser
        {
            Id = "33d069d9-a8c1-4e45-b51a-1ec42b219eb7",
            UserName = "bob@example.com",
            NormalizedUserName = "BOB",
            Email = "bob@example.com",
            NormalizedEmail = "BOB@EXAMPLE.COM",
            EmailConfirmed = true,
        };
    }
}
