using Library.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace Library.UI.Models
{
    public class SignUpViewModel
    {
        [StringLength(250,MinimumLength =3)]
        public string FullName { get; set; }
        [StringLength(250,MinimumLength =3)]
        public string UserName { get; set; }
        [StringLength(50,MinimumLength =10)]
        public string Tel { get; set; }
        [StringLength(50,MinimumLength =6)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Password and PasswordRepeat do not match.")]
        public string PasswordRepeat { get; set; }
    }
}
