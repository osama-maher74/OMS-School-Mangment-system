using System.Security.Claims;
using System.Threading.Tasks;
using lab1.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    public class TestAccountController : Controller
    {
        public IActionResult Login()
        { 
        

        return View();
        
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            //search for user name in db 
            // if not exists
            if (model.UsserName=="osama")
            {
                ModelState.AddModelError("", "Invalid Username or Password");
              //  return View(model);
            }
            // if exists
            Claim c1 = new Claim(ClaimTypes.Name, model.UsserName);//1
            Claim c2 = new Claim(ClaimTypes.Email, "osama@iti.gov");//2
            ClaimsIdentity ci = new ClaimsIdentity(new Claim[] { c1, c2 }, "MyCookiesAuth");//3
            ClaimsPrincipal cp = new ClaimsPrincipal(ci);//4
            await HttpContext.SignInAsync(cp);//5

            return RedirectToAction("Index", "Department");         //cookie created here !!!
      
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
