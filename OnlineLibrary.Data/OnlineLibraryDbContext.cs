namespace OnlineLibrary.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;
    using Migrations;

    public class OnlineLibraryDbContext : IdentityDbContext<User>, IOnlineLibraryDbContext
    {
        public OnlineLibraryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OnlineLibraryDbContext,Configuration>());
        }

        public static OnlineLibraryDbContext Create()
        {
            return new OnlineLibraryDbContext();
        }

        public DbSet<Book> Books { get; set; }
    }
}
