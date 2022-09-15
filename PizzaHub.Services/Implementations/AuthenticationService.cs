using Microsoft.AspNetCore.Identity;
using PizzaHub.Entities;
using PizzaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        protected SignInManager<User> _signManager;
        protected UserManager<User> _userManager;
        protected RoleManager<Role> _roleManager;

        public AuthenticationService(SignInManager<User> signManager,UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            _signManager = signManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public User AuthenticateUser(string Username, string Password)
        {
            var result = _signManager.PasswordSignInAsync(Username, Password, false, lockoutOnFailure: false).Result;

            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(Username).Result;
                var roles = _userManager.GetRolesAsync(user).Result;
                user.Roles = roles.ToArray();

                return user;
            }
            return null;
        }

        public bool CreateUser(User user, string password)
        {
            var result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                //Admin , User
                string role = "Admin";
                var res = _userManager.AddToRoleAsync(user, role).Result;
                if (res.Succeeded)
                    return true;
            }
            return false;
        }

        public User GetUser(string Username)
        {
            return _userManager.FindByNameAsync(Username).Result;
        }

        public async Task<bool> SignOut()
        {
            try
            {
                await _signManager.SignOutAsync();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
