namespace SimpleMVC.App.Views.Users
{
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using System;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class All : IRenderable<AllUsersIdUsernameViewModel>
    {
        public AllUsersIdUsernameViewModel Model { get; set; }

        public string Render()
        {
            string page = File.ReadAllText("../../Views/Users/All.html");
            StringBuilder nameCollection = new StringBuilder();

            if (Model.Users.Count > 0)
            {
                foreach (var user in Model.Users)
                {
                    nameCollection.AppendLine($"<p><a href=\"profile?id={user.Key}\">{user.Value}</a></p>");
                }

                page = String.Format(page, nameCollection.ToString());
            }
            else
            {
                nameCollection.AppendLine("<p>No users in database</p>");

                page = String.Format(page, nameCollection.ToString());
            }

            return page;
        }
    }
}