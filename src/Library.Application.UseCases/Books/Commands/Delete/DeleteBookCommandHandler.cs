using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Library.Application.UseCases.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BaseResponse<bool>>
    {
        private readonly IValidator<DeleteBookCommand> _validator;
        private readonly IBookRepository _BookRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(
            ILogger<DeleteBookCommandHandler> logger, IMapper mapper,
            IBookRepository BookRepository,
            IValidator<DeleteBookCommand> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _BookRepository = BookRepository;
            _validator = validator;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.LogError("Update Book Name Command with id: {id} produced errors on validation {Errors}", command.Id, validation.ToString());
                return new BaseResponse<bool> { Data = false, success = false, Message = "InvalidInput" };
            }
            var res = await _BookRepository.DeleteAsync(command.Id);

            return new BaseResponse<bool> { Data = res, success = true, Message = "Success" };
        }
    }
}