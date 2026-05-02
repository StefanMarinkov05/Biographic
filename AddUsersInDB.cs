using Biographic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Biographic
{
    public class AddUsersInDB
    {
        public const string ADMIN_ROLE = "Admin";
        public const string USER_ROLE = "User";
        public const string ADMIN_PASSWORD = "Admin#1";
        public const string USER_PASSWORD = "User#1";
        public const string ADMIN_EMAIL = "admin@sudo.com";
        public const string USER_EMAIL = "user@user.com";

        public const string ADMIN_FIRST_NAME = "Admin";
        public const string ADMIN_LAST_NAME = "Sudo";
        public const string ADMIN_NICKNAME = "TheBoss";

        public const string USER_FIRST_NAME = "User";
        public const string USER_LAST_NAME = "Normal";
        public const string USER_NICKNAME = "Average";

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AddUsersInDB(RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task AddTestRolesAndUsersIfEmpty()
        {
            await AddTestRolesIfEmpty();
            await AddTestUsersIfEmpty();
        }

        private async Task AddTestRolesIfEmpty()
        {
            await AddRoleIfEmpty(ADMIN_ROLE);
            await AddRoleIfEmpty(USER_ROLE);
        }

        private async Task AddRoleIfEmpty(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        private async Task AddTestUsersIfEmpty()
        {
            await AddTestUserIfEmpty(
                ADMIN_EMAIL,
                ADMIN_ROLE,
                ADMIN_PASSWORD,
                ADMIN_FIRST_NAME,
                ADMIN_LAST_NAME,
                ADMIN_NICKNAME);

            await AddTestUserIfEmpty(
                USER_EMAIL,
                USER_ROLE,
                USER_PASSWORD,
                USER_FIRST_NAME,
                USER_LAST_NAME,
                USER_NICKNAME);
        }

        private async Task AddTestUserIfEmpty(string email, string role, string password, string firstName, string lastName, string nickname)
        {
            if (!await _userManager.Users.AnyAsync(user => user.Email == email))
            {
                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = firstName,   
                    LastName = lastName,
                    Nickname = nickname
                };

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }

                    await _userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
