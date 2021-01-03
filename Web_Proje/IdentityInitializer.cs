using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Proje.Entities;

namespace Web_Proje
{
    public class IdentityInitializer
    {
        // Identity ile admin oluşturma
        public static void AdminOlustur(UserManager<AppUser> usermanager , RoleManager<IdentityRole> rolemanager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Burak Can",
                SurName = "Görgülü",
                UserName = "b201210372@sakarya.edu.tr"
            };
            if (usermanager.FindByNameAsync("b201210372@sakarya.edu.tr").Result == null)
            {
                var identityResult = usermanager.CreateAsync(appUser,"123").Result;
            };

            if (rolemanager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                var identityResult = rolemanager.CreateAsync(role).Result;
                var result = usermanager.AddToRoleAsync(appUser, role.Name).Result;
            }
        }
    }
}
