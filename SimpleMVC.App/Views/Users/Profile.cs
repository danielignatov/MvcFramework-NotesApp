using SimpleMVC.App.BindingModels;
using SimpleMVC.App.MVC.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App.Views.Users
{
    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            string page = File.ReadAllText("../../Views/Users/Profile.html");
            StringBuilder sb = new StringBuilder();

            if (Model.Notes.Count() > 0)
            {
                foreach (var note in Model.Notes)
                {
                    sb.AppendLine($"<p><strong>{note.Title}</strong> - {note.Content}</p>");
                }

                page = String.Format(page, Model.Username, Model.UserId, sb.ToString());
            }
            else
            {
                sb.AppendLine("<p>No notes</p>");

                page = String.Format(page, Model.Username, Model.UserId, sb.ToString());
            }

            return page;
        }
    }
}
