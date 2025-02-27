using Library.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.UseCases.UserManager.Commands.Register
{
    public class RegisterCommand : IRequest<BaseResponse<int>>
    {
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public string Tel { get; set; }
        public string Password { get; set; }
    }
}