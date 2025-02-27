using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.UseCases.Books.Commands.Add
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BaseResponse<int>>
    {
        private readonly IValidator<AddBookCommand> _validator;
        private readonly IBookRepository _BookRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(
            ILogger<AddBookCommandHandler> logger, IMapper mapper,
            IBookRepository BookRepository,
            IValidator<AddBookCommand> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _BookRepository = BookRepository;
            _validator = validator;
        }

        public async Task<BaseResponse<int>> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.LogError("Update Book Name Command, produced errors on validation {Errors}", validation.ToString());
                return new BaseResponse<int> { Data = 0, success = false, Message = "InvalidInput" };
            }
            var Book = _mapper.Map<Domain.Entities.BookEntities.Book>(command);
            var id = await _BookRepository.AddAsync(Book);

            return new BaseResponse<int> { Data = id, success = true, Message = "Success" };
        }
    }
}