
using Library.Application.UseCases.Commons.Bases;
using Library.Application.Dto;
using Library.Application.UseCases.Books.Commands.Add;
//using Library.Application.UseCases.Books.Commands.AddEditByAdmin;
using Library.Application.UseCases.Books.Commands.Delete;
using Library.Application.UseCases.Books.Queries.GetAll;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Domain.Entities.BookEntities;
using Library.Persistence.Contexts;
using Library.WebApi.Extensions.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Library.Application.UseCases.Books.Commands.Update;
using Library.Application.UseCases.Books.Queries.GetRemainsBook;
using Library.Application.UseCases.Books.Queries.GetBorrowingBooks;
using Library.Application.UseCases.Books.Queries.GetNotReturnedBooks;
using Library.Application.UseCases.Books.Queries.GetFiltersBooks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly ILogger<BookController> _logger;
        private readonly IMediator _mediator;

        public BookController(ILogger<BookController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetBooks")]
        public async Task<BaseResponse<List<BookDto>>> GetBooksAsync()
        {
            GetAllBooksQuery input = new GetAllBooksQuery();
            _logger.LogDebug("GetBooksAsync");
            var result = await _mediator.Send(input);
            return result;
        }

        [BearerAuth]
        [HttpGet("GetBorrowingBooksQuery", Name = "GetBorrowingBooksQuery")]
        public async Task<BaseResponse<List<BookDto>>> GetBorrowingBooksQuery()
        {
            GetBorrowingBooksQuery input = new GetBorrowingBooksQuery();
            _logger.LogDebug("GetBorrowingBooksQuery");
            var result = await _mediator.Send(input);
            return result;
        }

        [BearerAuth]
        [HttpGet("GetNotReturnedBooksQuery", Name = "GetNotReturnedBooksQuery")]
        public async Task<BaseResponse<List<BookDto>>> GetNotReturnedBooksQuery()
        {
            GetNotReturnedBooksQuery input = new GetNotReturnedBooksQuery();
            _logger.LogDebug("GetNotReturnedBooksQuery");
            var result = await _mediator.Send(input);
            return result;
        }

        [HttpGet("GetFiltersBooksQuery", Name = "GetFiltersBooksQuery")]
        public async Task<BaseResponse<List<BookDto>>> GetFiltersBooksQuery([FromQuery]GetFiltersBooksQuery input)
        {
            _logger.LogDebug("GetFiltersBooksQuery");
            var result = await _mediator.Send(input);
            return result;
        }
        

        [BearerAuth]
        [HttpGet("GetRemainBooks", Name = "GetRemainBooksAsync")]
        public async Task<BaseResponse<List<BookSimpleDto>>> GetRemainBooksAsync()
        {
            GetRemainsBookQuery input = new GetRemainsBookQuery();
            _logger.LogDebug("GetBooksAsync");
            var result = await _mediator.Send(input);
            return result;
        }

        [BearerAuth]
        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<BaseResponse<BookDto>> GetBookByIdAsync(int id)
        {
            var input = new GetBookByIdQuery() { Id=id};
            _logger.LogDebug("GetBookByIdAsync");
            var result = await _mediator.Send(input);
            return result;
        }
        [BearerAuth]
        [HttpPost(Name = "AddBook")]
        public async Task<BaseResponse<int>> AddBook(AddBookCommand item)
        {
            _logger.LogDebug("AddEditBook item:" + JsonConvert.SerializeObject(item));
            item.SetCreatedUserId(SharedLogic.GetUserId(Request));
            var result = await _mediator.Send(item);
            return result;
        }

        [BearerAuth]
        [HttpPut(Name = "UpdateBook")]
        public async Task<BaseResponse<bool>> UpdateBook(UpdateBookCommand item)
        {
            _logger.LogDebug("UpdateBook item:" + JsonConvert.SerializeObject(item));
            var result = await _mediator.Send(item);
            return result;
        }
        [BearerAuth]
        [HttpDelete(Name = "DeleteBook")]
        public async Task<BaseResponse<bool>> DeleteBook(DeleteBookCommand input)
        {
            _logger.LogDebug("DeleteBook Id:" + input.Id);
            var result = await _mediator.Send(input);
            return result;
        }
    }
}
