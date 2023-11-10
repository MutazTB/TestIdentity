﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDomainENT.Entities;
using TestRepositoryDAL.DAL.Interfaces;

namespace TestRepositoryDAL.DAL.Implementation
{
    public class UserDAL : IUserDAL
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserDAL(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task Login(UserLogin userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, true, false);

            if (!result.Succeeded)
            {
                throw new Exception("Wrong username or password!");
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Register(UserRegister userRegister)
        {
            if (await _userManager.FindByNameAsync(userRegister.UserName) != null)
            {
                throw new Exception("Username is used before.");
            }

            if (await _userManager.FindByEmailAsync(userRegister.Email) != null)
            {
                throw new Exception("Email is used before.");
            }

            var user = new ApplicationUser { UserName = userRegister.UserName, Email = userRegister.Email };
            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong!\nMake sure the password has small letters, capital letters, numbers, and symbols!");
            }
        }

    }
}
