using InnatAPP.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnatAPP.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void SeedRoles()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            { 
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Usuário@localhost.com";
                user.Id = "1";
            }
        }

        public void SeedUsers()
        {
            throw new NotImplementedException();
        }
    }
}
