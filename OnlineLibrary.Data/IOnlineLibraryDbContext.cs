namespace OnlineLibrary.Data
{
    using System.Data.Entity;
    using Models;

    public interface IOnlineLibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        int SaveChanges();
    }
}
