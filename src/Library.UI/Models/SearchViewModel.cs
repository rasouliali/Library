using Library.Application.Dto;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Application.UseCases.UserManager.Queries.SignIn;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Library.UI.Models
{
    public class SearchViewModel 
    {
        [StringLength(4000)]
        public string Title { get; set; }
        public string PublishYear { get; set; }
        [StringLength(250)]
        public string Author { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
