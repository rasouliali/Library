
using Library.Application.UseCases.UserManager.Queries.TokenValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library.WebApi.Extensions.Middleware
{

    public class BearerAuthAttribute : TypeFilterAttribute
    {
        public BearerAuthAttribute(string policyName = "")
           : base(typeof(NativeAuthorizeAsyncActionFilterAttribute))
        {
            Arguments = new object[] { policyName };
        }
    }

    public class NativeAuthorizeAsyncActionFilterAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IAuthorizationService _authorizationService;
        //private readonly AuthSettings _authSettings;
        private readonly string _policyName;
        private readonly IMediator _mediator;

        public NativeAuthorizeAsyncActionFilterAttribute(
           IAuthorizationService authorizationService, IMediator mediator,
           string policyName = "")
        {
            _mediator = mediator;
            _policyName = policyName;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            string authHeader = context.HttpContext.Request.Headers["Authorization"];
            string UserId = context.HttpContext.Request.Headers["UserId"];// ("/Account/Login", new { area = "Identity" });
            if (UserId != null&& authHeader != null && authHeader.ToLower().StartsWith("bearer "))
            {
                authHeader = authHeader.Substring("bearer ".Length).Trim();
                var res = _mediator.Send(new TokenValidationQuery { Token = authHeader, Role = _policyName,UserId=int.Parse(UserId) }).Result;
                if (res.Data)
                    await next.Invoke();
                else
                    context.Result = new UnauthorizedResult();// ("/Account/Login", new { area = "Identity" });

            }
            else 
                context.Result = new UnauthorizedResult();// ("/Account/Login", new { area = "Identity" });

        }
    }
}