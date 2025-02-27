using Library.Domain.Entities.BookEntities;
using Library.Domain.Entities.UserEntities;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ExtentBorrowing>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Entity<Session>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Entity<Book>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Entity<Borrowing>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Entity<UserInfo>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Entity<Role>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Entity<UserRole>().Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");

            builder.Entity<UserInfo>().HasData(
                new UserInfo()
                {
                    FullName = "Ali Rasouli",
                    UserName = "rasouli",
                    IsDeleted = false,
                    PasswordHash = "nucYY3XECcoPL4ucgRt+ND/iVyP0xsmiB6z31UeuBdU=",
                    Salt = "157,165,66,15,197,109,172,34,78,58,246,140,174,1,216,161",
                    Id = 1,
                    Tel = "09127433108,09011454747"
                }
            );
            builder.Entity<Role>().HasData(
                new Role() { Title = "Admin", IsDeleted = false, Id = 1 },
                new Role() { Title = "Normal", IsDeleted = false, Id = 2 }
            );

            builder.Entity<UserRole>().HasData(
                new UserRole() { UserId = 1, RoleId = 1, IsDeleted = false, Id = 1, }
            );

            builder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Title = "Pro ASP.NET Core MVC",
                    Author = "ADAM FREEMAN",
                    BookCategory = "Web Programming",
                    PublishYear = 2016,
                    CreatedUserId = 1,
                    IsDeleted = false,
                    
                },
                new Book()
                {
                    Id = 2,
                    Title = "SQL Server",
                    Author = "Benjamin Nevarez",
                    BookCategory = "Programming",
                    PublishYear = 2020,
                    CreatedUserId = 1,
                    IsDeleted = false
                },
                new Book()
                {
                    Id = 3,
                    Title = "C#",
                    Author = "Svetlin Nakov,Veselin Kolev",
                    BookCategory = "Programming",
                    PublishYear = 2010,
                    CreatedUserId = 1,
                    IsDeleted = false
                }
            );

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<ExtentBorrowing> ExtentBorrowings { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
