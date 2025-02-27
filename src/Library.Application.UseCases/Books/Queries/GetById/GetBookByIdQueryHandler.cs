using Library.Application.Interfaces;
using MediatR;
using FluentValidation;
using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Library.Application.UseCases.Books.Queries.GetAll
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BaseResponse<BookDto>>
    {
        private readonly IValidator<GetAllBooksQuery> _validator;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(
            ILogger<GetAllBooksQueryHandler> logger,
            IBookRepository bookRepository,
            IValidator<GetAllBooksQuery> validator, IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            //var validation = _validator.Validate(request);

            //if (!validation.IsValid)
            //{
            //    _logger.Error("Get Post by id with id {Id} produced errors on validation {Errors}", request.Id, validation.ToString());
            //    return new QueryResult<List<Domain.PostData.Post>>(result: default(List<Domain.PostData.Post>), type: QueryResultTypeEnum.InvalidInput);
            //}
            var books = await _bookRepository.GetAsync(request.Id);

            if (books == null)
            {
                return new BaseResponse<BookDto> { Data = null, success = false, Message = "NotFound" };
            }
            var postsDto = _mapper.Map<BookDto>(books);
            return new BaseResponse<BookDto> { Data = postsDto, success = true, Message = "Success" };
        }
    }
}