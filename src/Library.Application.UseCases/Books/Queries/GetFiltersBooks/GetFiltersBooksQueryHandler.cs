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

namespace Library.Application.UseCases.Books.Queries.GetFiltersBooks
{
    public class GetFiltersBooksQueryHandler : IRequestHandler<GetFiltersBooksQuery, BaseResponse<List<BookDto>>>
    {
        private readonly IValidator<GetFiltersBooksQuery> _validator;
        private readonly IBookRepository _BookRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetFiltersBooksQueryHandler(
            ILogger<GetFiltersBooksQueryHandler> logger,
            IBookRepository BookRepository,
            IValidator<GetFiltersBooksQuery> validator, IMapper mapper)
        {
            _logger = logger;
            _BookRepository = BookRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<BookDto>>> Handle(GetFiltersBooksQuery request, CancellationToken cancellationToken)
        {
            var validation = _validator.Validate(request);

            if (!validation.IsValid)
            {
                _logger.LogError("GetFiltersBooksQuery produced errors on validation {Errors}", validation.ToString());
                return new BaseResponse<List<BookDto>> { Data = default, success = false, Message = "InvalidInput." };
            }

            List<Book> Books = await _BookRepository.GetByFilterAsync(r =>
                   (string.IsNullOrEmpty(request.Title) || r.Title.Contains(request.Title))
                && (string.IsNullOrEmpty(request.Author) || r.Author.Contains(request.Author))
                && (string.IsNullOrEmpty(request.Category) || r.BookCategory.Contains(request.Category))
                && ((request.PublishYear ?? 0) == 0 || r.PublishYear == request.PublishYear)
                );
            if (Books == null)
            {
                return new BaseResponse<List<BookDto>> { Data = null, success = false, Message = "NotFound" };
            }
            var BooksDto = _mapper.Map<List<BookDto>>(Books);
            return new BaseResponse<List<BookDto>> { Data = BooksDto, success = true, Message = "Success" };
        }
    }
}