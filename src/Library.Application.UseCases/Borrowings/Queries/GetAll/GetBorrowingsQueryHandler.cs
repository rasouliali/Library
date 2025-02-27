using Library.Application.Interfaces;
using MediatR;
using FluentValidation;
using Library.Application.UseCases.Commons.Bases;
using Microsoft.Extensions.Logging;
using Library.Application.Dto;
using AutoMapper;

namespace Library.Application.UseCases.Borrowings.Queries.GetAll
{
    public class GetBorrowingsQueryHandler : IRequestHandler<GetBorrowingsQuery, BaseResponse<List<BorrowingDto>>>
    {
        private readonly IValidator<GetBorrowingsQuery> _validator;
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetBorrowingsQueryHandler(
            ILogger<GetBorrowingsQueryHandler> logger,
            IBorrowingRepository borrowingRepository,
            IMapper mapper,
            IValidator<GetBorrowingsQuery> validator)
        {
            _logger = logger;
            _borrowingRepository = borrowingRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<BorrowingDto>>> Handle(GetBorrowingsQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Get borrowing  produced errors on validation {0}", validation.ToString());
                return new BaseResponse<List<BorrowingDto>> { Data = default, success = false, Message = "InvalidInput" };
            }
            var borrowing = await _borrowingRepository.GetAllAsync(new string[] { "CurrentBook"});

            if (borrowing == null)
            {
                return new BaseResponse<List<BorrowingDto>> { Data = null, success = false, Message = "NotFound" };
            }
            var dataDto = _mapper.Map<List<BorrowingDto>>(borrowing);
            return new BaseResponse<List<BorrowingDto>> { Data = dataDto, success = true, Message = "Success" };
        }
    }
}