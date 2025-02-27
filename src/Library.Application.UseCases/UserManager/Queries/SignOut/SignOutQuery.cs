using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using Library.Domain.Entities.UserEntities;
using MediatR;

namespace Library.Application.UseCases.UserManager.Queries.SignOut
{
    public class SignOutQuery : IRequest<BaseResponse<bool>>
    {
        public string Token { get; set; }
    }
}