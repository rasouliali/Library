using Library.Domain.Entities.Base;
using Library.Domain.Entities.UserEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities.BookEntities
{
    public class Borrowing : EntityBaseWithUserData
    {
        [ForeignKey("CurrentBook")]
        public int BookId { get; set; }
        public virtual Book CurrentBook { get; set; }
        [StringLength(250)]
        public string BorrowingFullName { set; get; }
        [StringLength(10)]
        public string BorrowingNationalCode { set; get; }
        [StringLength(50)]
        public string BorrowingMobile { set; get; }
        public int ExtentCounter { get; set; }
        public DateTime MaximumReturnDate { get; set; }
        public bool IsReturn { get; set; }
        public DateTime? ReturnDate { get; set; }
        public virtual List<ExtentBorrowing> ExtentBorrowings { get; set; }
    }
}
