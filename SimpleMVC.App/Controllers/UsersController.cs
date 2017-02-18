namespace SimpleMVC.App.Controllers
{
    using BindingModels;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            using (var context = new NotesApplicationContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All()
        {
            List<string> usernames = null;

            using (var context = new NotesApplicationContext())
            {
                usernames = context.Users.Select(u => u.Username).ToList();
            }

            var viewModel = new AllUsernamesViewModel()
            {
                Usernames = usernames
            };

            return View(viewModel);
        }
    }
}