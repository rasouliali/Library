
using Library.Application.Dto;
using Library.Application.UseCases.Commons.Bases;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Application.UseCases.UserManager.Queries.SignIn;
using Library.Application.UseCases.UserManager.Queries.SignOut;
using Library.Domain.Entities.UserEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserManagerController : ControllerBase
    {

        private readonly ILogger<UserManagerController> _logger;
        private readonly IMediator _mediator;

        public UserManagerController(ILogger<UserManagerController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("Register", Name = "Register")]
        public async Task<BaseResponse<int>> Register([FromBody] RegisterCommand input)
        {
            _logger.LogDebug("Register input:" + JsonConvert.SerializeObject(input));

            var res = await _mediator.Send(input);
            return res;
        }

        [HttpPost("Login", Name = "Login")]
        public async Task<BaseResponse<UserLoginDto>> Login(SignInQuery input)
        {
            _logger.LogDebug("Login input:" + JsonConvert.SerializeObject(input));

            var res = await _mediator.Send(input);

            var newRes = new BaseResponse<UserLoginDto>();
            (newRes.success, newRes.Data) = res.Data;
            newRes.Message = res.Message;
            return newRes;
        }

        [HttpPost("Logout", Name = "Logout")]
        public async Task<BaseResponse<bool>> Logout(SignOutQuery input)
        {
            _logger.LogDebug("Login input:" + JsonConvert.SerializeObject(input));

            var res = await _mediator.Send(input);
            return res;
        }

        private static string GetJsonData(UserLoginDto userdto)
        {
            var newData = JsonConvert.SerializeObject(userdto, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            newData = newData.Replace("\"", "'");
            return newData;
        }
    }
}
