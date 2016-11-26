namespace OnlineLibrary.Data
{
    using Models;
    using Repositories;

    public interface IOnlineLibraryDbData
    {
        IRepository<User> Users { get; } 
        IRepository<Book> Books { get; }
        int SaveChanges();
    }
}
