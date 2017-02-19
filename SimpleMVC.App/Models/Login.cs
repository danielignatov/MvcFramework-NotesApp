namespace SimpleMVC.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Login
    {
        #region Constructors
        public Login()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string SessionId { get; set; }

        public bool IsActive { get; set; }

        public virtual User User { get; set; }
        #endregion
    }
}