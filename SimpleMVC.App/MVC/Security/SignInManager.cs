namespace SimpleMVC.App.MVC.Security
{
    using Data;
    using Interfaces;
    using Models;
    using SimpleHttpServer.Models;
    using System.Linq;

    public class SignInManager
    {
        #region Fields
        private IDbIdentityContext dbContext;
        #endregion

        #region Constructors
        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }
        #endregion

        #region Methods
        public bool IsAuthenticated(HttpSession session)
        {
            if (this.dbContext.Logins.Where(s => s.SessionId == session.Id).Select(a => a.IsActive).FirstOrDefault() == true)
            {
                return true;
            }

            return false;
        }

        public void LogOut(HttpSession session)
        {
            using (var context = new NotesApplicationContext())
            {
                Login login = context.Logins.Where(s => s.SessionId == session.Id).FirstOrDefault();

                context.Logins.Remove(login);
                context.SaveChanges();
            }
        }
        #endregion
    }
}