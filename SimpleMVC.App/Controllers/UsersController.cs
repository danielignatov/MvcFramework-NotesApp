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
        public IActionResult<AllUsersIdUsernameViewModel> All()
        {
            Dictionary<string, string> users = null;

            using (var context = new NotesApplicationContext())
            {
                users = context.Users.Select(u => new { u.Id, u.Username }).ToDictionary(u => u.Id.ToString(), u => u.Username);
            }

            var viewModel = new AllUsersIdUsernameViewModel()
            {
                Users = users
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NotesApplicationContext())
            {
                var user = context.Users.Find(id);

                var viewModel = new UserProfileViewModel
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes
                        .Select(x =>
                        new NoteViewModel()
                        {
                            Title = x.Title,
                            Content = x.Content
                        })
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NotesApplicationContext())
            {
                var user = context.Users.Find(model.UserId);

                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.SaveChanges();
            };

            return Profile(model.UserId);
        }
    }
}