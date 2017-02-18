namespace SimpleMVC.App.Views.Users
{
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using System;
    using System.IO;
    using System.Text;
    using ViewModels;

    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            string page = File.ReadAllText("../../Views/Users/All.html");
            StringBuilder nameCollection = new StringBuilder();

            if (Model.Usernames.Count > 0)
            {
                foreach (var username in Model.Usernames)
                {
                    nameCollection.AppendLine($"<p>{username}</p>");
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