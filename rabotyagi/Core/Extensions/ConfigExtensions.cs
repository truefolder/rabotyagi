using Microsoft.AspNetCore.Identity;
using rabotyagi.Core.Consts;
using rabotyagi.DataAccess.Entities;

namespace rabotyagi.Core.Extensions;

public static class ConfigExtensions
{
    public static async Task SeedRolesAndAdminAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var roleManager = services.GetRequiredService<RoleManager<Role>>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        foreach (var roleName in RolesConstants.AllRoles)
            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new Role { Name = roleName });

        var superAdmin = await userManager.GetUsersInRoleAsync(RolesConstants.SuperAdminRole);
        if (superAdmin.Count > 0)
            return;
        
        const string adminPhoneNumber = "+77777777777";
        const string adminPassword = "123123";

        var admin = new User
        {
            Name = RolesConstants.SuperAdminRole,
            Surname = RolesConstants.SuperAdminRole,
            UserName = adminPhoneNumber,
            PhoneNumber = adminPhoneNumber,
        };

        var result = await userManager.CreateAsync(admin, adminPassword);
        if (result.Succeeded)
            await userManager.AddToRoleAsync(admin, RolesConstants.SuperAdminRole);
    }
}