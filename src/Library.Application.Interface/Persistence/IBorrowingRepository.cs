using Library.Application.Interface.Persistence;
using Library.Domain.Entities.BookEntities;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBorrowingRepository : IGenericRepository<Borrowing>
    {

    }
}