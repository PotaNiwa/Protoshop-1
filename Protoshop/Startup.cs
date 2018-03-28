﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Protoshop.Models;

[assembly: OwinStartupAttribute(typeof(Protoshop.Startup))]
namespace Protoshop
{
    public partial class Startup
    {
        private ApplicationDbContext context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public Startup()
        {
            context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
        }
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdmin();
            CreateRoles();
        }

        private void CreateRoles()
        {
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

        private void CreateAdmin()
        {
            if(userManager.FindByEmail("admin@admin.com") == null)
            {
                var user = new ApplicationUser();
                user.Email = "admin@admin.com";
                user.UserName = "admin@admin.com";
                string password = "Password1!";
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
