using BusinessLayer.DTO.RequestDTO;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole()
        {
            await accountService.AssignRole();
            return Ok();
        }

        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin()
        {
            await accountService.CreateAdmin();
            return Ok();
        }

        [HttpPost("UserRegister")]
        public async Task<IActionResult> UserRegister(CreateUserDTO createUserDTO)
        {
            await accountService.CreateUser(createUserDTO);
            return Ok();
        }

        [HttpPost("AdminLogin")]
        public async Task<IActionResult> AdminLogin(AdminLoginDTO adminLoginDTO)
        {
            var response = await accountService.AdminLogin(adminLoginDTO);
            return Ok(response);
        }

        [HttpPost("UserLogin")]
        public async Task<IActionResult> Userlogin(UserLoginDTO userLoginDTO)
        {
            var response = await accountService.UserLogin(userLoginDTO);
            return Ok(response);
        }
    }
}
