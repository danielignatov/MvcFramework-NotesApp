namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        #region Constructors
        public Note()
        {

        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Owner { get; set; }
        #endregion
    }
}