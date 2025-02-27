using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using Library.Domain.Entities.UserEntities;
using MediatR;

namespace Library.Application.UseCases.UserManager.Queries.SignIn
{
    public class SignInQuery : IRequest<BaseResponse<(bool, UserLoginDto)>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}