namespace SimpleMVC.App.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        #region Constructors
        public User()
        {
            this.Notes = new HashSet<Note>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
        #endregion
    }
}