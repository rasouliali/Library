using Library.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities.BookEntities
{
    public class ExtentBorrowing : EntityBaseWithUserData
    {
        [ForeignKey("CurrentBorrowing")]
        public int BorrowingId { get; set; }
        public Borrowing CurrentBorrowing { get; set; }
    }
}
