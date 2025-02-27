using Library.Application.Interfaces;
using MediatR;
using FluentValidation;
using Library.Application.UseCases.Commons.Bases;
using Microsoft.Extensions.Logging;
using Library.Domain.Entities.UserEntities;
using Library.Application.Dto;
using Library.Application.UseCases.UserManager.Queries.SignOut;

namespace Library.Application.UseCases.UserManager.Queries.TokenValidation
{
    public class TokenValidationQueryHandler : IRequestHandler<TokenValidationQuery, BaseResponse<bool>>
    {
        private readonly IValidator<TokenValidationQuery> _validator;
        private readonly IUserManagerRepository _repository;
        private readonly ILogger _logger;

        public TokenValidationQueryHandler(
            ILogger<TokenValidationQueryHandler> logger,
            IUserManagerRepository repository,
            IValidator<TokenValidationQuery> validator)
        {
            _logger = logger;
            _repository = repository;
            _validator = validator;
        }

        public async Task<BaseResponse<bool>> Handle(TokenValidationQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Get SignOutQueryHandler by Token with {0} produced errors on validation {1}", request.Token, validation.ToString());
                return new BaseResponse<bool> { Data = default, success = false, Message = "InvalidInput" };
            }
            var IsOk = await _repository.TokenValidation(request.Token,request.Role,request.UserId);

            return new BaseResponse<bool> { Data = IsOk, success = true, Message = "Success" };
        }
    }
}