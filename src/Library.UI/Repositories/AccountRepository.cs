using Library.Application.Dto;
using Library.Application.UseCases.UserManager.Commands.Register;
using Library.Application.UseCases.UserManager.Queries.SignIn;
using Library.Application.UseCases.UserManager.Queries.SignOut;
using Library.UI.Controllers;
using Library.UI.Helpers;
using Library.UI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;

namespace Library.UI.Repositories
{
    public class AccountRepository
    {
        private readonly ApiCaller _apiCaller;
        private readonly string _apiUrl;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(ILogger<AccountRepository> logger, ApiCaller apiCaller, IConfiguration config)
        {
            this._apiCaller = apiCaller;
            _apiUrl = config.GetValue<string>("ApiUrl");
            _logger = logger;
        }

        internal async Task<(UserLoginDto, string)> LoginAsync(SignInViewModel input)
        {
            try
            {
                var json = JsonConvert.SerializeObject(input);
                var res = await _apiCaller.CallPostApiAsync(_apiUrl + Helpers.APIMethodUrls.Login, APIMethodUrls.JsonContent, json, "", 0);
                if (res.StartsWith("errorOccured:") == false)
                {
                    var obj = JObject.Parse(res);
                    if (obj.Value<bool>("success"))
                    {
                        var data = JsonConvert.DeserializeObject<UserLoginDto>(obj.GetValue("data").ToString());
                        return (data, "");
                    }
                    return (null, obj.Value<string>("message"));
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return (null, "");
        }

        internal async Task<bool> LogoutAsync(string Token, int userId)
        {
            try
            {
                var input = new SignOutQuery() { Token = Token };
                var json = JsonConvert.SerializeObject(input);
                var res = await _apiCaller.CallPostApiAsync(_apiUrl + Helpers.APIMethodUrls.Logout, APIMethodUrls.JsonContent, json, Token, userId);
                if (res.StartsWith("errorOccured:") == false)
                {
                    var obj = JObject.Parse(res);
                    return obj.Value<bool>("success") && obj.Value<int>("data") > 0;
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return false;
        }

        internal async Task<bool> SignUpAsync(SignUpViewModel input)
        {
            try
            {
                var json = JsonConvert.SerializeObject(input);
                var res = await _apiCaller.CallPostApiAsync(_apiUrl + Helpers.APIMethodUrls.SignUp, APIMethodUrls.JsonContent, json, "", 0);
                if (res.StartsWith("errorOccured:") == false)
                {
                    var obj = JObject.Parse(res);
                    return obj.Value<bool>("success") && obj.Value<int>("data") > 0;
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return false;
        }
    }
}
