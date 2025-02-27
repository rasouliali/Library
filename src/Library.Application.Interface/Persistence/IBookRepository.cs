using Library.Application.Dto;
using Library.Application.Interface.Persistence;
using Library.Domain.Entities.BookEntities;

namespace Library.Application.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        //Task<List<Post>> GetAllForAdminDashboardAsync(int UserId);
        Task<List<Book>> GetRemainsBookAsync();
        //Task<int> AddEditPost(Post input);
        //Task<bool> DeletePost(int Id);

    }
}