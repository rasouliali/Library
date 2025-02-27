using Library.Application.Interfaces;
using Library.Domain.Entities.BookEntities;
using Library.Persistence.Contexts;
using Library.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>,IBookRepository
    {
        private LibraryContext db;

        public BookRepository(LibraryContext db) : base(db)
        {
            this.db = db;
        }
        public async Task<List<Book>> GetRemainsBookAsync()
        {
            return await db.Books.Where(r=>r.IsDeleted==false && r.Borrowings.Count(t=>t.IsReturn==false)==0).ToListAsync();
        }
        //public BookRepository(LibraryContext db)
        //{
        //    this.db = db;
        //}
        //public async Task<int> AddEditAsync(Post input)
        //{
        //    if (input.Id == 0)
        //    {
        //        db.Posts.Add(input);
        //    }
        //    else
        //    {
        //        var before = db.Posts.Find(input.Id);//update must not be change createuserid and createddate
        //        if (before != null)
        //        {
        //            input.CreatedDate = before.CreatedDate;
        //            input.CreatedUserId = before.CreatedUserId;
        //            db.Posts.Update(input);
        //        }
        //        else
        //            return 0;
        //    }
        //    await db.SaveChangesAsync();
        //    return input.Id;
        //}
        //public async Task<bool> DeleteAsync(int Id)
        //{
        //    var found = false;
        //    if (Id > 0)
        //    {
        //        var post = db.Posts.SingleOrDefault(r=>r.Id== Id);
        //        if (post != null)
        //        {
        //            post.IsDeleted = true;
        //            found = true;
        //        }
        //    }
        //    await db.SaveChangesAsync();
        //    return found;
        //}

        //public async Task<List<Post>> GetAllAsync()
        //{
        //    var list = await db.Posts.Where(r => r.IsDeleted == false).Include(r => r.PostComments).Include(r => r.CurrentCreatedUser).OrderByDescending(r=>r.Id).ToListAsync();
        //    return list;
        //}
        //public async Task<List<Post>> GetAllForAdminDashboardAsync(int UserId)
        //{
        //    var isAdmin=db.UserRoles.Any(r => r.CurrentRole.Title == "Admin" && r.UserId == UserId);
        //    if (isAdmin)
        //    {
        //        var list = await db.Posts.Where(r => r.IsDeleted == false)
        //            .Include(r => r.SelectedPosts).OrderByDescending(r => r.Id).ToListAsync();
        //        list.ForEach(r =>
        //        {
        //            r.RegisterCount = r.SelectedPosts.Count;
        //            r.SelectedPosts = null;
        //        });
        //        return list;
        //    }
        //    return null;
        //}

        //public async Task<Post> GetAsync(int id)
        //{
        //    var item = await db.Posts.Where(r => r.IsDeleted == false && r.Id==id).Include(r => r.PostComments).FirstOrDefaultAsync();
        //    return item;
        //}

    }

}
