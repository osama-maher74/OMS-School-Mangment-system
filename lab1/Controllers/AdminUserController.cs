using System.Threading.Tasks;
using lab1.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminUserController : Controller
    {
        public UserManager<IdentityUser> UserManger;
        public RoleManager<IdentityRole> RoleManager;
        public AdminUserController(UserManager<IdentityUser> _userManger,RoleManager<IdentityRole> _roleManager)
        {

            UserManger= _userManger;
            RoleManager= _roleManager;
        }

        public async Task<IActionResult> Delete(string id)
        {

            var model = await  UserManger.FindByIdAsync(id);
            if (model != null)
            {

                var delmodel=await UserManger.DeleteAsync(model);
            }
            return RedirectToAction("Index");


        }
      
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

          
            var user = await UserManger.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

           
            var allRoles = RoleManager.Roles.ToList();

            
            var userRoles = await UserManger.GetRolesAsync(user);

            
            var model = new EditUserVM
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                UserRoles = userRoles,
                
                AllRoles = allRoles
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditUserVM model)
        {
            if (!ModelState.IsValid)
            {
                model.AllRoles = RoleManager.Roles.ToList();
                return View(model);
            }

            
            var user = await UserManger.FindByIdAsync(model.Id);
            if (user == null)
            {
                return NotFound();
            }

          
            model.SelectedRoles = model.SelectedRoles
                .Where(r => !string.IsNullOrEmpty(r))
                .ToList();

           
            user.UserName = model.UserName;
    

            var result = await UserManger.UpdateAsync(user);

            if (result.Succeeded)
            {
                
                var currentRoles = await UserManger.GetRolesAsync(user);

               
                var rolesToRemove = currentRoles.Except(model.SelectedRoles).ToList();
                await UserManger.RemoveFromRolesAsync(user, rolesToRemove);

                
                var rolesToAdd = model.SelectedRoles.Except(currentRoles).ToList();
                await UserManger.AddToRolesAsync(user, rolesToAdd); 

                return RedirectToAction(nameof(Index));
            }

           
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

           
            model.AllRoles = RoleManager.Roles.ToList();
            return View(model);
        }


        //public async Task<IActionResult> ShowRoles(string id)
        //{
        //    var user = await UserManger.FindByIdAsync(id);
        //    //var model = RoleManager.Roles.ToList();
        //    if (user != null)
        //    {
        //        var userroles=await UserManger.GetRolesAsync(user);

        //        return View(user);
        //    }

        //        return View("Index");
        //}


        public async Task<IActionResult> Index()
        {
            var users = UserManger.Users.ToList();

            var model = new List<UsersVM>();

            foreach (var user in users)
            {
                var userRoles = await UserManger.GetRolesAsync(user);

                model.Add(new UsersVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Roles = userRoles
                });
            }
            return View(model);
        }
    }
}
