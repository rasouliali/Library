using Library.Application.Interfaces;
using Library.Domain.Entities.BookEntities;
using Library.Persistence.Contexts;
using Library.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class ExtentBorrowingRepository : GenericRepository<ExtentBorrowing>, IExtentBorrowingRepository
    {
        private LibraryContext db;
        public ExtentBorrowingRepository(LibraryContext db) : base(db)
        {
            this.db = db;
        }
        //public async Task<int> AddEditAsync(SelectedPost input)
        //{
        //    if (input.Id == 0)
        //    {
        //        db.SelectedPosts.Add(input);
        //    }
        //    else
        //    {
        //        var before = db.Posts.Find(input.Id);//update must not be change createuserid and createddate
        //        if (before != null)
        //        {
        //            input.CreatedDate = before.CreatedDate;
        //            input.CreatedUserId = before.CreatedUserId;
        //            db.SelectedPosts.Update(input);
        //        }
        //        else
        //            return 0;
        //    }
        //    await db.SaveChangesAsync();
        //    return input.Id;
        //}

        //public Task<bool> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<SelectedPost>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}
        
        //public async Task<List<SelectedPost>> GetAllByCurrentUserIdAsync(int userId)
        //{
        //    var res = await db.SelectedPosts.Where(r=>r.CreatedUserId==userId).ToListAsync();
        //    return res;
        //}

        //public Task<SelectedPost> GetAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
