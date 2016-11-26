namespace OnlineLibrary.Data
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class OnlineLibraryDbData:IOnlineLibraryDbData
    {
        private IOnlineLibraryDbContext context;
        private IDictionary<Type, object> repositories;

        public OnlineLibraryDbData(IOnlineLibraryDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }
        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                //                if (type.IsAssignableFrom(typeof(Game)))
                //                {
                //                    typeOfRepository = typeof(GamesRepository);
                //                }

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
