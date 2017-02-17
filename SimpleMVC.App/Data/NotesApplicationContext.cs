namespace SimpleMVC.App.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NotesApplicationContext : DbContext
    {
        // Your context has been configured to use a 'NotesApplicationContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SimpleMVC.App.Data.NotesApplicationContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'NotesApplicationContext' 
        // connection string in the application configuration file.
        public NotesApplicationContext()
            : base("name=NotesApplicationContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }
    }
}