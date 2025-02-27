using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Library.Application.Commands.Borrowing.AddEdit;

namespace Library.Application.UseCases.Borrowings.Commands.Update
{
    public class UpdateBorrowingCommandHandler : IRequestHandler<UpdateBorrowingCommand, BaseResponse<bool>>
    {
        private readonly IValidator<UpdateBorrowingCommand> _validator;
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IExtentBorrowingRepository _extentBorrowingRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UpdateBorrowingCommandHandler(
            ILogger<UpdateBorrowingCommandHandler> logger, IMapper mapper,
            IBorrowingRepository BorrowingRepository,
            IExtentBorrowingRepository extentBorrowingRepository,
            IValidator<UpdateBorrowingCommand> validator)
        {
            _mapper = mapper;
            _logger = logger;
            _borrowingRepository = BorrowingRepository;
            _validator = validator;
            _extentBorrowingRepository= extentBorrowingRepository;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateBorrowingCommand command, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(command);

            if (!validation.IsValid)
            {
                _logger.LogError("Update Borrowing Command with id: {id} produced errors on validation {Errors}", command.Id, validation.ToString());
                return new BaseResponse<bool> { Data = false, success = false, Message = "InvalidInput" };
            }
            bool res;
            if (command.IsExtend)
            {
                var before_borrowing = await _borrowingRepository.GetAsync(command.Id);
                before_borrowing.ExtentCounter = before_borrowing.ExtentCounter + 1;
                before_borrowing.MaximumReturnDate = before_borrowing.MaximumReturnDate.AddDays(7);
                res = await _borrowingRepository.UpdateAsync(before_borrowing);
            }
            else if(command.IsReturn)
            {
                var before_borrowing = await _borrowingRepository.GetAsync(command.Id);
                before_borrowing.IsReturn = true;
                before_borrowing.ReturnDate = DateTime.Now;
                res = await _borrowingRepository.UpdateAsync(before_borrowing);
            }
            else
            {
                _logger.LogError("At least one of IsReturn or IsExtend must be true {Id} ", command.Id);
                return new BaseResponse<bool> { Data = false, success = false, Message = "At least one of IsReturn or IsExtend must be true" };
            }


            await _extentBorrowingRepository.AddAsync(new Domain.Entities.BookEntities.ExtentBorrowing { BorrowingId = command.Id, CreatedUserId = command.UpddaterUserId });

            return new BaseResponse<bool> { Data = res, success = true, Message = "" };
        }
    }
}