//using Library.Application.Interfaces;
//using MediatR;
//using FluentValidation;
//using Library.Application.UseCases.Commons.Bases;
//using Microsoft.Extensions.Logging;
//using Library.Application.UseCases.Borrowings.Queries.GetAllByBookId;
//using Library.Application.UseCases.Postborrowing.Queries.GetAllByPostId;

//namespace Library.Application.UseCases.ExtentBorrowings.Queries.GetAllByBorrowingId
//{
//    public class GetExtentBorrowingByBorrowingIdQueryHandler : IRequestHandler<GetExtentBorrowingByBorrowingIdQuery, BaseResponse<List<Domain.Entities.BookEntities.ExtentBorrowing>>>
//    {
//        private readonly IValidator<GetExtentBorrowingByBorrowingIdQuery> _validator;
//        private readonly IExtentBorrowingRepository _borrowingRepository;
//        private readonly ILogger _logger;

//        public GetExtentBorrowingByBorrowingIdQueryHandler(
//            ILogger<GetBorrowingByBookIdQueryHandler> logger,
//            IExtentBorrowingRepository borrowingRepository,
//            IValidator<GetExtentBorrowingByBorrowingIdQuery> validator)
//        {
//            _logger = logger;
//            _borrowingRepository = borrowingRepository;
//            _validator = validator;
//        }

//        public async Task<BaseResponse<List<Domain.Entities.BookEntities.ExtentBorrowing>>> Handle(GetExtentBorrowingByBorrowingIdQuery request, CancellationToken cancellationToken)
//        {
//            var validation = _validator.Validate(request);

//            if (!validation.IsValid)
//            {
//                _logger.LogError("Get Postborrowing by postId with {0} produced errors on validation {1}", request.BorrowingId, validation.ToString());
//                return new BaseResponse<List<Domain.Entities.BookEntities.ExtentBorrowing>> { Data = default, success = false, Message = "InvalidInput" };
//            }
//            var borrowing = await _borrowingRepository.GetByFilterAsync(r => r.BorrowingId == request.BorrowingId);

//            if (borrowing == null)
//            {
//                return new BaseResponse<List<Domain.Entities.BookEntities.ExtentBorrowing>> { Data = null, success = false, Message = "NotFound" };
//            }
//            return new BaseResponse<List<Domain.Entities.BookEntities.ExtentBorrowing>> { Data = borrowing.ToList(), success = true, Message = "Success" };
//        }
//    }
//}