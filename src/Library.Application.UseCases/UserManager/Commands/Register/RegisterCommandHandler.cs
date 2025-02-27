using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.UseCases.UserManager.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse<int>>
    {
        private readonly IValidator<RegisterCommand> _validator;
        private readonly IUserManagerRepository _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(
            ILogger<RegisterCommandHandler> logger, IMapper mapper,
            IUserManagerRepository repository,
            IValidator<RegisterCommand> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _validator = validator;
        }

        public async Task<BaseResponse<int>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.LogError("RegisterCommand err. produced errors on validation {Errors}", validation.ToString());
                return new BaseResponse<int> { Data = 0, success = false, Message = "InvalidInput" };
            }
            var item = _mapper.Map<Domain.Entities.UserEntities.UserInfo>(command);
            var id = await _repository.RegisterUser(item);

            return new BaseResponse<int> { Data = id, success = true, Message = "Success" };
        }
    }
}