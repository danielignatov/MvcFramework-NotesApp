namespace SimpleMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class AllUsernamesViewModel
    {
        public AllUsernamesViewModel()
        {
            this.Usernames = new List<string>();
        }

        public IList<string> Usernames { get; set; }
    }
}