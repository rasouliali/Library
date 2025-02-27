using Library.Application.Interface.Persistence;
using Library.Persistence.Contexts;
using Library.Application.Interfaces;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Library.Persistence.Repositories;
using Library.Domain.Entities.BookEntities;

namespace Library.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddScoped<IGenericRepository<T>, GenericRepository<T>>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBorrowingRepository, BorrowingRepository>();
            services.AddTransient<IUserManagerRepository, UserManagerRepository>();
            services.AddScoped<IExtentBorrowingRepository, ExtentBorrowingRepository>();
            services.AddDbContext<LibraryContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("LibraryContextConnection")));

            return services;
        }
    }
}
