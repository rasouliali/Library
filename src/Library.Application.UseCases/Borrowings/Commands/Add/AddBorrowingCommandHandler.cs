using AutoMapper;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Library.Application.UseCases.Borrowings.Commands.Add;

namespace Library.Application.Commands.Borrowing.AddEdit
{
    public class AddBorrowingCommandHandler : IRequestHandler<AddBorrowingCommand, BaseResponse<int>>
    {
        private readonly IValidator<AddBorrowingCommand> _validator;
        private readonly IBorrowingRepository _BorrowingRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AddBorrowingCommandHandler(
            ILogger<AddBorrowingCommandHandler> logger, IMapper mapper,
            IBorrowingRepository BorrowingRepository,
            IValidator<AddBorrowingCommand> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _BorrowingRepository = BorrowingRepository;
            _validator = validator;
        }

        public async Task<BaseResponse<int>> Handle(AddBorrowingCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.LogError("AddBorrowing Command with produced errors on validation {Errors}", validation.ToString());
                return new BaseResponse<int> { Data = 0, success = false, Message = "InvalidInput" };
            }
            var Borrowing = _mapper.Map<Domain.Entities.BookEntities.Borrowing>(command);

            Borrowing.MaximumReturnDate = DateTime.Now.AddDays(7);
            Borrowing.ExtentCounter = 0;

            var id = await _BorrowingRepository.AddAsync(Borrowing);

            return new BaseResponse<int> { Data = id, success = true, Message = "" };
        }
    }
}