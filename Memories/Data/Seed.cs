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

                            Image = "https://i.imgur.com/OpqEbBQ.jpg",

                            FamilyCategory = FamilyCategory.Morgan,
                            Address = new Address()
                            {
                                City = "Covington",
                                State = "TN"
                            },

                        
                         },
                        new Family()
                        {

                            FamilyName = "Thornton",

                            Image = "https://i.imgur.com/17Zfj2P.jpg",

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

                            Image = "https://i.imgur.com/eYa36Fy.jpg",

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
             //Family Members
                if (!context.FamilyMembers.Any())
                {
                    context.FamilyMembers.AddRange(new List<FamilyMember>()
                    {
                        new FamilyMember()
                        {
                            FirstName = "Bettye",
                            LastName = "Morgan",
                            MemberImage = "https://i.imgur.com/sFnheBI.jpg",
                            
                        },
                        new FamilyMember()
                        {
                            FirstName = "Toby",
                            LastName = "Morgan",
                            MemberImage = "https://i.imgur.com/CEGzvI2.jpg",
                            
                        },
                        new FamilyMember()
                        {
                            FirstName = "Larry",
                            LastName = "Morgan",
                            MemberImage = "https://i.imgur.com/weiy85T.jpg",
                            
                        },
                        
        });
                    context.SaveChanges();
                }
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