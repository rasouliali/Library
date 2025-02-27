using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using Library.Domain.Entities.UserEntities;
using MediatR;

namespace Library.Application.UseCases.UserManager.Queries.TokenValidation
{
    public class TokenValidationQuery : IRequest<BaseResponse<bool>>
    {
        public string Token { get; set; }
        public string Role { get; set; }
        public int UserId{ get; set; }
    }
}