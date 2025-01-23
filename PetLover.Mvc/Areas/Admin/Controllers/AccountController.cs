using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetLover.Bl.Dtos;
using PetLover.Core;
using PetLover.Data.Context;

namespace PetLover.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;    
        private readonly IMapper _mapper;



        public AccountController(AppDbContext context, UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(a => a.Email == createUserDto.Email))
                {
                    ModelState.AddModelError("Email", "This email already taken");
                    return View(createUserDto);
                }
                if (_context.Users.Any(a => a.UserName == createUserDto.UserName))
                {
                    ModelState.AddModelError("UserName", "This userName already taken");
                    return View(createUserDto);

                }
                var result = _mapper.Map<AppUser>(createUserDto);
                await _userManager.CreateAsync(result,createUserDto.Password);
                return StatusCode(StatusCodes.Status200OK, "Successfully created User");
            }
            return View(createUserDto);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            if (ModelState.IsValid)
            {
               AppUser? appUser=await _context.Users.FirstOrDefaultAsync(a=>a.Email == loginUserDto.Email); 
                if (appUser == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "This user dont find");
                   
                }if (await _userManager.CheckPasswordAsync(appUser, loginUserDto.Password) == true)
                {
                    await _signInManager.SignInAsync(appUser, true);
                  await  _userManager.AddToRoleAsync(appUser, "User");
                    return StatusCode(StatusCodes.Status200OK, "Login successfully");
                }
               
            


            }
            return View();
        }
        public async Task CreateRole()
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        }
        [Authorize(Roles ="User")]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
            return StatusCode(StatusCodes.Status200OK, "logout successfully");
        }
    }
}
