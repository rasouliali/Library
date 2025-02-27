//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using Library.Application.UseCases.Commons.Bases;
//using Library.Application.Interfaces;
//using FluentValidation;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using Library.Application.Commands.Borrowing.AddEdit;

//namespace Library.Application.UseCases.ExtentBorrowings.Commands.Add
//{
//    public class AddExtentBorrowingCommandHandler : IRequestHandler<AddExtentBorrowingCommand, BaseResponse<int>>
//    {
//        private readonly IValidator<AddExtentBorrowingCommand> _validator;
//        private readonly IExtentBorrowingRepository _BorrowingRepository;
//        private readonly ILogger _logger;
//        private readonly IMapper _mapper;

//        public AddExtentBorrowingCommandHandler(
//            ILogger<AddBorrowingCommandHandler> logger, IMapper mapper,
//            IExtentBorrowingRepository BorrowingRepository,
//            IValidator<AddExtentBorrowingCommand> validator)
//        {
//            _mapper = mapper;
//            _logger = logger;
//            _BorrowingRepository = BorrowingRepository;
//            _validator = validator;
//        }

//        public async Task<BaseResponse<int>> Handle(AddExtentBorrowingCommand command, CancellationToken cancellationToken)
//        {
//            command.CommentId = command.CommentId == 0 ? null : command.CommentId;
//            var validation = _validator.Validate(command);

//            if (!validation.IsValid)
//            {
//                _logger.LogError("AddEdit Borrowing Command with id: {id} produced errors on validation {Errors}", command.Id, validation.ToString());
//                return new BaseResponse<int> { Data = 0, success = false, Message = "InvalidInput" };
//            }
//            var Borrowing = _mapper.Map<Domain.Entities.BookEntities.ExtentBorrowing>(command);
//            var id = await _BorrowingRepository.AddAsync(Borrowing);

//            return new BaseResponse<int> { Data = id, success = true, Message = "NotFound" };
//        }
//    }
//}