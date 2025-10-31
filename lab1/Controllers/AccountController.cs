using System.Security.Claims;
using System.Threading.Tasks;
using lab1.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace lab1.Controllers
{
    public class AccountController : Controller
    {
       public  UserManager<IdentityUser> UserManger;
        public SignInManager<IdentityUser> SignInManager;
        public AccountController(UserManager<IdentityUser> _userManger,SignInManager<IdentityUser> _signInManager)
        {
            UserManger=_userManger;
            SignInManager=_signInManager;
        }

        public IActionResult Register()
        { 
        return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model )
        {
            //Register logic here

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.UserName


                };
                //hash password
                var res = await UserManger.CreateAsync(user, model.Password);

                if (res.Succeeded)
                {
                    await UserManger.AddToRoleAsync(user, "Student");

                    return RedirectToAction("Login");
                }
                foreach (var item in res.Errors)
                {  
                    ModelState.AddModelError("", item.Description);
                }

            }
        return View(model);
        
        }
        public IActionResult Login()
        {


            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            ////search for user name in db 
            //// if not exists
            //if (model.UsserName == "osama")
            //{
            //    ModelState.AddModelError("", "Invalid Username or Password");
            //    //  return View(model);
            //}
            //// if exists
            //Claim c1 = new Claim(ClaimTypes.Name, model.UsserName);//1
            //Claim c2 = new Claim(ClaimTypes.Email, "osama@iti.gov");//2
            //ClaimsIdentity ci = new ClaimsIdentity(new Claim[] { c1, c2 }, "MyCookiesAuth");//3
            //ClaimsPrincipal cp = new ClaimsPrincipal(ci);//4
            //await HttpContext.SignInAsync(cp);//5

            if(ModelState.IsValid)
            {

                var res = await SignInManager.PasswordSignInAsync(
                    model.UsserName, model.Password, false, false);
                if(res .Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
            }


            return RedirectToAction("Register");       

        }

        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync(); 
            return RedirectToAction("Login");

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
