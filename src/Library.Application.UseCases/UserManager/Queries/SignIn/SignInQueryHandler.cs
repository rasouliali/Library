using Library.Application.Interfaces;
using MediatR;
using FluentValidation;
using Library.Application.UseCases.Commons.Bases;
using Microsoft.Extensions.Logging;
using Library.Domain.Entities.UserEntities;
using Library.Application.Dto;
using AutoMapper;

namespace Library.Application.UseCases.UserManager.Queries.SignIn
{
    public class SignInQueryHandler : IRequestHandler<SignInQuery, BaseResponse<(bool, UserLoginDto)>>
    {
        private readonly IValidator<SignInQuery> _validator;
        private readonly IUserManagerRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public SignInQueryHandler(
            ILogger<SignInQueryHandler> logger,
            IUserManagerRepository repository,
            IMapper mapper,
            IValidator<SignInQuery> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _validator = validator;

        }

        public async Task<BaseResponse<(bool, UserLoginDto)>> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Get CheckUserPassQuery by username with {0} produced errors on validation {1}", request.UserName, validation.ToString());
                return new BaseResponse<(bool, UserLoginDto)> { Data = default, success = false, Message = "InvalidInput" };
            }
            var isSignIn = false;
            UserLoginDto userDto = null;
            UserInfo userInfo = null;
            (isSignIn, userInfo) = await _repository.SignIn(request.UserName, request.Password);
            userDto = _mapper.Map<UserLoginDto>(userInfo);

            return new BaseResponse<(bool, UserLoginDto)> { Data = (isSignIn, userDto), success = true, Message = userDto==null?"User or pass is incorrect.":"Success" };
        }
    }
}