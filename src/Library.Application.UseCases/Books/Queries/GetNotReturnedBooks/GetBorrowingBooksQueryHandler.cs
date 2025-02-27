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

namespace Library.Application.UseCases.Books.Queries.GetNotReturnedBooks
{
    public class GetNotReturnedBooksQueryHandler : IRequestHandler<GetNotReturnedBooksQuery, BaseResponse<List<BookDto>>>
    {
        private readonly IValidator<GetNotReturnedBooksQuery> _validator;
        private readonly IBookRepository _BookRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetNotReturnedBooksQueryHandler(
            ILogger<GetNotReturnedBooksQueryHandler> logger,
            IBookRepository BookRepository,
            IValidator<GetNotReturnedBooksQuery> validator, IMapper mapper)
        {
            _logger = logger;
            _BookRepository = BookRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<BookDto>>> Handle(GetNotReturnedBooksQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("GetNotReturnedBooksQuery produced errors on validation {Errors}", validation.ToString());
                return new BaseResponse<List<BookDto>> { Data = default, success = false, Message = "InvalidInput." };
            }

            List<Book> Books = await _BookRepository.GetByFilterAsync(r => r.Borrowings.Any(t => t.IsReturn == false));
                        
            if (Books == null)
            {
                return new BaseResponse<List<BookDto>> { Data = null, success = false, Message = "NotFound" };
            }
            var BooksDto = _mapper.Map<List<BookDto>>(Books);
            return new BaseResponse<List<BookDto>> { Data = BooksDto, success = true, Message = "Success" };
        }
    }
}