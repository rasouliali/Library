using Library.Application.Dto;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Application.UseCases.UserManager.Queries.SignIn;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Library.UI.Models
{
    public class ReportViewModel
    {
        public List<BookDto> NotReturnedBooks { get; set; }
        public List<BookDto> BorrowingBooks { get; set; }
    }
}
