namespace OnlineLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineLibraryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(OnlineLibraryDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUser(context);
            }
            if (!context.Books.Any())
            {
                this.SeedBooks(context);
            }
        }

        private void SeedUser(OnlineLibraryDbContext context)
        {
            var manager = new UserManager<User>(new UserStore<User>(context));
            var demoUser = new User { UserName = "demouser", Email = "demo@demo.bg" };
            manager.Create(demoUser, "demo123");
            context.SaveChanges();
        }

        private void SeedBooks(OnlineLibraryDbContext context)
        {
            var now = DateTime.Now;
            for (int i = 0; i < 29; i++)
            {
                var newBook = new Book
                {
                    CreatedOn = now.AddDays(i),
                    Name = "Book" + i,
                    PageCount = 150 + i,
                    Creator = context.Users.FirstOrDefault(),
                    Genre = (GenreType) i,
                    ImagePath = "demo.jpg"
                };
                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        
    }
}
