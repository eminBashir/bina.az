using BusinessLayer.DTO.RequestDTO;
using BusinessLayer.DTO.ResponseDTO;
using BusinessLayer.JWT_Helper.Interface;
using BusinessLayer.Services.Interfaces;
using DataLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWT_Service _jWT_Service;

        public AccountService(RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, IJWT_Service jWT_Service)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _jWT_Service = jWT_Service;
        }

        public async Task AssignRole()
        {
            var roles = new List<Role>
            {
                new Role() { Name = "Admin", Id = Guid.NewGuid().ToString() },
                new Role() { Name = "User", Id= Guid.NewGuid().ToString() },
            };
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(role);
            }
        }
        public async Task CreateAdmin()
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "SystemAdmin",
                Email = "bashirovemin@yahoo.com",
                PhoneNumber = "0704300505",
                CreateDate = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, "Admin_12345*#");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
        public async Task CreateUser(CreateUserDTO createUserDTO)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = createUserDTO.UserName,
                Email = createUserDTO.Email,
                PhoneNumber = createUserDTO.PhoneNumber,
                CreateDate = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, createUserDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        public async Task<LoginResponseDTO> AdminLogin(AdminLoginDTO adminLoginDTO)
        {
            var admin = await _userManager.FindByEmailAsync(adminLoginDTO.Email);

            if (admin == null)
            {
                throw new Exception("Admin is not found");
            }
            else
            {
                var succesResult = await _signInManager.CheckPasswordSignInAsync(admin, adminLoginDTO.Password, false);

                if (succesResult.Succeeded)
                {
                    var roles = (await _userManager.GetRolesAsync(admin)).ToList();
                    var result = await _jWT_Service.CreateToken(admin.Email, roles);
                    return result;
                }
                else
                {
                    throw new Exception("email or password is not incorrect");
                }
            }
        }
        public async Task<LoginResponseDTO> UserLogin(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user == null)
            {
                throw new Exception("User is not found");
            }
            else
            {
                var succesResult = await _signInManager.CheckPasswordSignInAsync(user,userLoginDTO.Password, false);

                if (succesResult.Succeeded)
                {
                    var roles = (await _userManager.GetRolesAsync(user)).ToList();
                    var result = await _jWT_Service.CreateToken(user.Email, roles);
                    return result;
                }
                else
                {
                    throw new Exception("email or password is not incorrect");
                }
            }
        }
    }
}
