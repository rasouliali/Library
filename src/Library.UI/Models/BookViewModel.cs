using System.ComponentModel.DataAnnotations;

namespace Library.UI.Models
{
    public class BookViewModel
    {
        [StringLength(4000,MinimumLength =3)]
        public required string Title { get; set; }
        [StringLength(250,MinimumLength =3)]
        public required string Author { get; set; }
        [StringLength(50,MinimumLength =3)]
        public required string BookCategory { get; set; }
        public required int PublishYear { get; set; }
    }
}
