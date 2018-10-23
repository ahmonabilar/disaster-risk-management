using Drm.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drm.Data
{
    public class DRMSeeder
    {
        private readonly DRMContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<DrmUser> _userManager;
        private readonly RoleManager<DrmRole> _roleManager;

        public DRMSeeder(DRMContext ctx, IHostingEnvironment hosting, UserManager<DrmUser> userManager, RoleManager<DrmRole> roleManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            var filePath = Path.Combine(_hosting.ContentRootPath, "testData.json");

            var json = File.ReadAllText(filePath);

            var jsonObj = JObject.Parse(json);

            var testJToken = jsonObj["Tests"];

            var testEnumerable = JsonConvert.DeserializeObject<IEnumerable<Test>>(testJToken.ToString());

            var role = await SeedRoleAsync();

            var user = await SeedUserAsync();

            await SeedUserRoleAsync(user, role);

            if (!_ctx.Tests.Any())
            {
                _ctx.Tests.AddRange(testEnumerable);

                _ctx.SaveChanges();
            }
        }

        private async Task SeedUserRoleAsync(DrmUser user, DrmRole role)
        {
            if(user == null || role == null) return;

            await _userManager.AddToRoleAsync(user, role.Name);
        }

        private async Task<DrmUser> SeedUserAsync()
        {
            var user = await _userManager.FindByNameAsync("admin");

            if (user == null)
            {
                user = new DrmUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                };

                var result = await _userManager.CreateAsync(user, "Admin_2018");

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Cound not create new user in seeder.");
                }
            }

            return user;
        }

        private async Task<DrmRole> SeedRoleAsync()
        {

            var role = await _roleManager.FindByNameAsync("Administrator");

            if(role == null)
            {
                role = new DrmRole
                {
                   Name = "Administrator",
                   NormalizedName = "administrator"
                };

                var result = await _roleManager.CreateAsync(role);

                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Cound not create new role in seeder.");
                }
            }

            return role;
        }
    }
}
