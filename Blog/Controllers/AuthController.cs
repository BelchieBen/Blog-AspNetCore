using Blog.ViewModels;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Blog.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        List<Roles> roleList = new List<Roles>()
        {
            new Roles(){Role="Manager"},
            new Roles(){Role="Employee"},
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);
            return User.IsInRole("Admin") ? RedirectToAction("Index", "Panel") : RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(roleList, "Role", "Role");
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            var role = roleList.Where(r => r.Role == vm.Role)
                                   .Select(r => r.Role).FirstOrDefault();

            var userExists = await _userManager.FindByEmailAsync(vm.Email);
            if (userExists != null)
            {
                return BadRequest($"User {vm.Email} already exists!");
            }
            else
            {
                var newUsr = new IdentityUser
                {
                    UserName = vm.Username,
                    Email = vm.Email,
                };
                _userManager.CreateAsync(newUsr, vm.Password).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(newUsr, vm.Role).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index", "Panel");
        }
    }
}
