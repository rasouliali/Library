using Library.Application.UseCases.Commons.Bases;
using Library.Application.Commands.Borrowing.AddEdit;
using Library.Application.Interfaces;
using Library.WebApi.Extensions.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Library.Domain.Entities.BookEntities;
using Library.Application.UseCases.Borrowings.Commands.Add;
using Library.Application.UseCases.Borrowings.Commands.Update;
using Library.Application.UseCases.Borrowings.Queries.GetAll;
using Library.Application.Dto;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IBorrowingRepository _BorrowingRepository;
        private readonly IMediator _mediator;

        public BorrowingController(ILogger<BorrowingController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllBorrowings")]
        public async Task<BaseResponse<List<BorrowingDto>>> GetBorrowingsAsync()
        {
            var input = new GetBorrowingsQuery();
            _logger.LogDebug("GetBorrowingsAsync");
            var result = await _mediator.Send(input);
            return result;
        }

        [BearerAuth]
        [HttpPost(Name = "AddBorrowing")]
        public async Task<BaseResponse<int>> AddBorrowing(AddBorrowingCommand item)
        {
            _logger.LogDebug("AddEditBorrowing item:" + JsonConvert.SerializeObject(item));
            item.CreatedUserId = SharedLogic.GetUserId(Request);
            var result = await _mediator.Send(item);
            return result;
        }
        [BearerAuth]
        [HttpPut(Name = "UpdateBorrowing")]
        public async Task<BaseResponse<bool>> UpdateBorrowing(UpdateBorrowingCommand item)
        {
            _logger.LogDebug("UpdateBorrowing item:" + JsonConvert.SerializeObject(item));
            item.SetUpddaterUserId(SharedLogic.GetUserId(Request));
            var result = await _mediator.Send(item);
            return result;
        }
    }
}
