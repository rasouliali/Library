using Library.Application.Interfaces;
using MediatR;
using FluentValidation;
using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Library.Domain.Entities.BookEntities;
using System.Linq.Expressions;
using System.Linq;

namespace Library.Application.UseCases.Books.Queries.GetBorrowingBooks
{
    public class GetBorrowingBooksQueryHandler : IRequestHandler<GetBorrowingBooksQuery, BaseResponse<List<BookDto>>>
    {
        private readonly IValidator<GetBorrowingBooksQuery> _validator;
        private readonly IBookRepository _BookRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetBorrowingBooksQueryHandler(
            ILogger<GetBorrowingBooksQueryHandler> logger,
            IBookRepository BookRepository,
            IValidator<GetBorrowingBooksQuery> validator, IMapper mapper)
        {
            _logger = logger;
            _BookRepository = BookRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<BookDto>>> Handle(GetBorrowingBooksQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("Get Book by id with id {ReportIndex} produced errors on validation {Errors}", request.ReportIndex, validation.ToString());
                return new BaseResponse<List<BookDto>> { Data = default, success = false, Message = "InvalidInput." };
            }

            List<Book> Books =  await _BookRepository.GetByFilterAsync(r => r.Borrowings.Count > 0);
                        
            if (Books == null)
            {
                return new BaseResponse<List<BookDto>> { Data = null, success = false, Message = "NotFound" };
            }

            var BooksDto = _mapper.Map<List<BookDto>>(Books);
            return new BaseResponse<List<BookDto>> { Data = BooksDto, success = true, Message = "Success" };
        }
    }
}