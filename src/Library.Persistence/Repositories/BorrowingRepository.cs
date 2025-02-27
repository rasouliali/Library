using Library.Application.Interface.Persistence;
using Library.Application.Interfaces;
using Library.Domain.Entities.BookEntities;
using Library.Persistence.Contexts;
using Library.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BorrowingRepository : GenericRepository<Borrowing>, IBorrowingRepository
    {
        private LibraryContext db;
        public BorrowingRepository(LibraryContext db) : base(db)
        {
            this.db = db;
        }

    }
}
