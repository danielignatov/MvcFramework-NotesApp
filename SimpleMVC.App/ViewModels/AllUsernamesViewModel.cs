namespace SimpleMVC.App.ViewModels
{
    using System.Collections.Generic;

    public class AllUsersIdUsernameViewModel
    {
        public AllUsersIdUsernameViewModel()
        {
            this.Users = new Dictionary<string, string>();
        }

        #region Properties
        public IDictionary<string, string> Users { get; set; }
        #endregion
    }
}