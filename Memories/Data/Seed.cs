using Memories.Data;
using Memories.Models;
using Microsoft.AspNetCore.Identity;
using Memories.Data.Enum;

namespace Memories.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Families.Any())
                {
                    context.Families.AddRange(new List<Family>()
                    {
                        new Family()
                        {
                            FamilyName = "Morgan",
                            Image = "https://photos.app.goo.gl/uYrEfHwH1UisA3X27",
                            FamilyCategory = FamilyCategory.Morgan,
                            Address = new Address()
                            {
                                City = "Covington",
                                State = "TN"
                            }
                         },
                        new Family()
                        {
                            FamilyName = "Thornton",
                            Image = "https://photos.app.goo.gl/3Yc7u6ipeX4doatP6",
                            FamilyCategory = FamilyCategory.Thornton,
                            Address = new Address()
                            {
                                City = "Covington",
                                State = "TN"
                            }
                        },
                        new Family()
                        {
                            FamilyName = "Townsend",
                            Image = "https://photos.app.goo.gl/hjo6xFVTb5vYVrv39",
                            FamilyCategory = FamilyCategory.Townsend,
                            Address = new Address()
                            {
                                City = "Indianapolis",
                                State = "IN"
                            }
                        },
                        
                    });
                    context.SaveChanges();
                }
                //Races
                //if (!context.Races.Any())
                //{
                //    context.Races.AddRange(new List<Race>()
                //    {
                //        new Race()
                //        {
                //            Title = "Running Race 1",
                //            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //            Description = "This is the description of the first race",
                //            RaceCategory = RaceCategory.Marathon,
                //            Address = new Address()
                //            {
                //                Street = "123 Main St",
                //                City = "Charlotte",
                //                State = "NC"
                //            }
                //        },
                //        new Race()
                //        {
                //            Title = "Running Race 2",
                //            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //            Description = "This is the description of the first race",
                //            RaceCategory = RaceCategory.Ultra,
                //            AddressId = 5,
                //            Address = new Address()
                //            {
                //                Street = "123 Main St",
                //                City = "Charlotte",
                //                State = "NC"
                //            }
                //        }
                //    });
                //    context.SaveChanges();
                //}
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}