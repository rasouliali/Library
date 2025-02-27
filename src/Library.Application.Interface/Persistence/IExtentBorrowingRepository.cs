using Library.Application.Interface.Persistence;
using Library.Domain.Entities.BookEntities;

namespace Library.Application.Interfaces
{
    public interface IExtentBorrowingRepository : IGenericRepository<ExtentBorrowing>
    {
        //Task<List<SelectedPost>> GetAllByCurrentUserIdAsync(int userId);

        //Task<List<Post>> GetAll();
        //Task<int> AddEditPost(Post input);
        //Task<bool> DeletePost(int Id);

    }
}