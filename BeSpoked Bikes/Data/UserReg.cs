using BeSpoked_Bikes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked_Bikes.Data
{
    public class UserReg :IUserReg
    {
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public UserReg(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<bool> IsEmailUsed(string email) => await userManager.FindByEmailAsync(email) != null;
        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
           var result= await  userManager.CreateAsync(user, password);
            if (user.Manager.Equals(true))
            {
                var foundUser = await userManager.FindByEmailAsync(user.Email);
                await editRole(foundUser, "Manager");
                
            }
            return result;
         
        }
        public async Task editRole(ApplicationUser user, string role)
        {
            var foundRole = await roleManager.FindByNameAsync(role);
            await userManager.AddToRoleAsync(user, role);

        }
        public async Task<List<ApplicationUser>> getUser()
        {
          var hold= userManager.Users.ToList();
           
            return hold;
        }
    }
    public interface IUserReg
    {
        Task<bool> IsEmailUsed(string email);
        Task<List<ApplicationUser>> getUser();
        Task editRole(ApplicationUser user, string role);
        Task<IdentityResult> CreateUser(ApplicationUser user, string password);
    }
}
