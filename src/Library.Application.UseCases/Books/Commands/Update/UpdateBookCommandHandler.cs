using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Library.Application.UseCases.Books.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseResponse<bool>>
    {
        private readonly IValidator<UpdateBookCommand> _validator;
        private readonly IBookRepository _PostRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(
            ILogger<UpdateBookCommandHandler> logger, IMapper mapper,
            IBookRepository PostRepository,
            IValidator<UpdateBookCommand> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _PostRepository = PostRepository;
            _validator = validator;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.LogError("Update Post Name Command with id: {id} produced errors on validation {Errors}", command.Id, validation.ToString());
                return new BaseResponse<bool> { Data = false, success = false, Message = "InvalidInput" };
            }
            var post = _mapper.Map<Domain.Entities.BookEntities.Book>(command);
            var res = await _PostRepository.UpdateAsync(post);

            return new BaseResponse<bool> { Data = res, success = true, Message = "Success" };
        }
    }
}