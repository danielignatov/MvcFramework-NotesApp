namespace SimpleMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class AllUsersIdUsernameViewModel
    {
        public AllUsersIdUsernameViewModel()
        {
            this.Users = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Users { get; set; }
    }
}