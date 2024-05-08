namespace MvcPresentation.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using MvcPresentation.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LogicLayer;
    using System.Runtime.ConstrainedExecution;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcPresentation.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MvcPresentation.Models.ApplicationDbContext";
        }

        /// Creator: Liam Easton
        /// Created: 3/27/2024
        /// Summary: Adding roles to the seed. Added all of the roles we currently have on desktop, except for front desk rep.
        /// Last Updated By: Liam Easton
        /// Last Updated: 3/27/2024
        /// What Was Changed: initial creation
        ///Last Updated By: Matthew Baccam
        ///Last Updated: 04/11/2024
        ///What Was Changed: Added the client role to this so we can use the role 
        protected override void Seed(MvcPresentation.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            List<string> roles = new List<string>() { 
                "CEO",
                "Admin",
                "Maintenance Manager", 
                "Inventory Manager", 
                "Cook",
                "Driver", 
                "Maintenance Technician",
                "Kitchen Manager", 
                "Security Manager",
                "Security Guard", 
                "Transportation Coordinator",
                "Housekeeping Coordinator", 
                "Housekeeping Staff",
                "Client"
            };

            foreach (var roleName in roles)
            {
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole() { Name = roleName });
            }

            context.SaveChanges();

            // create an admin

            string admin = "admin@company.com";
            string adminPassword = "P@ssw0rd";

            if (!context.Users.Any(u => u.UserName.Equals(admin)))
            {
                var user = new ApplicationUser()
                {
                    GivenName = "System",
                    FamilyName = "Admin",
                    UserName = admin,
                    Email = admin,
                };

                IdentityResult result = userManager.Create(user, adminPassword);
                context.SaveChanges();

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                    userManager.AddToRole(user.Id, "CEO");
                    context.SaveChanges();
                }
            }
        }
    }
}
