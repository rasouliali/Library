using Library.Application.Dto;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Application.UseCases.UserManager.Queries.SignIn;
using System.ComponentModel.DataAnnotations;

namespace Library.UI.Models
{
    public class SignInViewModel 
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
