//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using Library.Application.UseCases.Commons.Bases;
//using Library.Application.Interfaces;
//using FluentValidation;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using Library.Application.Commands.Borrowing.AddEdit;

//namespace Library.Application.UseCases.Borrowings.Commands.Update
//{
//    public class UpdateExtentBorrowingCommandHandler : IRequestHandler<UpdateExtentBorrowingCommand, BaseResponse<bool>>
//    {
//        private readonly IValidator<UpdateExtentBorrowingCommand> _validator;
//        private readonly IExtentBorrowingRepository _BorrowingRepository;
//        private readonly ILogger _logger;
//        private readonly IMapper _mapper;

//        public UpdateExtentBorrowingCommandHandler(
//            ILogger<UpdateBorrowingCommandHandler> logger, IMapper mapper,
//            IExtentBorrowingRepository BorrowingRepository,
//            IValidator<UpdateExtentBorrowingCommand> validator)
//        {
//            _mapper = mapper;
//            _logger = logger;
//            _BorrowingRepository = BorrowingRepository;
//            _validator = validator;
//        }

//        public async Task<BaseResponse<bool>> Handle(UpdateExtentBorrowingCommand command, CancellationToken cancellationToken)
//        {
//            command.CommentId = command.CommentId == 0 ? null : command.CommentId;
//            var validation = _validator.Validate(command);

//            if (!validation.IsValid)
//            {
//                _logger.LogError("AddEdit Borrowing Command with id: {id} produced errors on validation {Errors}", command.Id, validation.ToString());
//                return new BaseResponse<bool> { Data = false, success = false, Message = "InvalidInput" };
//            }
//            var Borrowing = _mapper.Map<Library.Domain.Entities.BookEntities.ExtentBorrowing>(command);
//            var res = await _BorrowingRepository.UpdateAsync(Borrowing);

//            return new BaseResponse<bool> { Data = res, success = true, Message = "" };
//        }
//    }
//}