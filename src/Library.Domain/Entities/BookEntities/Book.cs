using Library.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities.BookEntities
{
    public class Book : EntityBaseWithUserData
    {
        [StringLength(4000)]
        public required string Title { get; set; }
        [StringLength(50)]
        public required string BookCategory { get; set; }
        [StringLength(250)]
        public required string Author { get; set; }
        public required int PublishYear { get; set; }
        public virtual List<Borrowing> Borrowings { get; set; }
    }
}
