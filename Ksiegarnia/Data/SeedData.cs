using Ksiegarnia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ksiegarnia.Data;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var roleExists = await roleManager.RoleExistsAsync("Admin");
        if (!roleExists)
        {
            var role = new IdentityRole("Admin");
            await roleManager.CreateAsync(role);
        }

        var userRoleExists = await roleManager.RoleExistsAsync("User");
        if (!userRoleExists)
        {
            var role = new IdentityRole("User");
            await roleManager.CreateAsync(role);
        }

        var adminUser = await userManager.FindByEmailAsync("admin@ksiegarnia.com");
        if (adminUser == null)
        {
            adminUser = new User { UserName = "admin@ksiegarnia.com", Email = "admin@ksiegarnia.com", FirstName = "Admin", LastName = "Ksiegarnia", EmailConfirmed = true };
            var result = await userManager.CreateAsync(adminUser, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        var normalUser = await userManager.FindByEmailAsync("user@ksiegarnia.com");
        if (normalUser == null)
        {
            normalUser = new User { UserName = "user@ksiegarnia.com", Email = "user@ksiegarnia.com", FirstName = "User", LastName = "Ksiegarnia", EmailConfirmed = true };
            var result = await userManager.CreateAsync(normalUser, "User123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }
}