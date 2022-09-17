using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Register;
using Service.Services.Interfaces;

namespace Web.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAccountService _service;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IAccountService service, RoleManager<IdentityRole> roleManager)
        {
            _service = service;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            await _service.Register(registerDto);
            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<string> Login(LoginDto loginDto)
        {
            string token = await _service.Login(loginDto);
            return token;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
        }





        //Roles Enum
        public enum UserRoles
        {
            SuperAdmin,
            Admin,
            Master,
            Consumer
        }
    }
}
