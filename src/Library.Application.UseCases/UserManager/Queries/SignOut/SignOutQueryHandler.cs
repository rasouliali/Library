using Library.Application.Interfaces;
using MediatR;
using FluentValidation;
using Library.Application.UseCases.Commons.Bases;
using Microsoft.Extensions.Logging;
using Library.Domain.Entities.UserEntities;
using Library.Application.Dto;

namespace Library.Application.UseCases.UserManager.Queries.SignOut
{
    public class SignOutQueryHandler : IRequestHandler<SignOutQuery, BaseResponse<bool>>
    {
        private readonly IValidator<SignOutQuery> _validator;
        private readonly IUserManagerRepository _repository;
        private readonly ILogger _logger;

        public SignOutQueryHandler(
            ILogger<SignOutQueryHandler> logger,
            IUserManagerRepository repository,
            IValidator<SignOutQuery> validator)
        {
            _logger = logger;
            _repository = repository;
            _validator = validator;
        }

        public async Task<BaseResponse<bool>> Handle(SignOutQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Get SignOutQueryHandler by Token with {0} produced errors on validation {1}", request.Token, validation.ToString());
                return new BaseResponse<bool> { Data = default, success = false, Message = "InvalidInput" };
            }
            var IsOk = await _repository.SignOut(request.Token);

            return new BaseResponse<bool> { Data = IsOk, success = true, Message = "Success" };
        }
    }
}