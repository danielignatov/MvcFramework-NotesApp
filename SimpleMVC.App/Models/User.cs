namespace SimpleMVC.App.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        #region Constructors
        public User()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual IList<Note> Notes { get; set; }
        #endregion
    }
}