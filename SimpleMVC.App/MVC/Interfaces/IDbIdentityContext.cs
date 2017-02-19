namespace SimpleMVC.App.MVC.Interfaces
{
    using Models;
    using System.Data.Entity;

    public interface IDbIdentityContext
    {
        DbSet<Login> Logins { get; }

        DbSet<User> Users { get; }

        void SaveChanges();
    }
}