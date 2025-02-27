using Library.Application.Dto;
using Library.Application.Dto;
using Library.Application.UseCases.Borrowings.Commands.Add;
using Library.Application.UseCases.Borrowings.Commands.Update;
using Library.UI.Helpers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.UI.Repositories
{
    public class BorrowingRepository
    {
        private readonly ApiCaller _apiCaller;
        private readonly string _apiUrl;
        private readonly ILogger<BorrowingRepository> _logger;
        public BorrowingRepository(ILogger<BorrowingRepository> logger, ApiCaller apiCaller, IConfiguration config)
        {
            this._apiCaller = apiCaller;
            _apiUrl = config.GetValue<string>("ApiUrl");
            _logger = logger;
        }

        internal async Task<string> AddBorrowingAsync(AddBorrowingCommand input, UserLoginDto dt)
        {
            var res = await _apiCaller.CallPostApiAsync(_apiUrl + APIMethodUrls.Borrowing, APIMethodUrls.JsonContent, JsonConvert.SerializeObject(input), dt.Token, dt.UserId);
            return SharedLogic.CalcResult(res);
        }

        

        internal async Task<string> UpdateBorrowingAsync(BorrowingDto input, UserLoginDto dt)
        {
            //input.ImageFileName = FileHelper.GetFile(fileData);

            var url = _apiUrl + APIMethodUrls.Borrowing;
            //if (dt.Roles == "Admin")
            //    url = _apiUrl + APIMethodUrls.Borrowing_AddBorrowingByAdmin;

            var res = await _apiCaller.CallPutApiAsync(url, APIMethodUrls.JsonContent, JsonConvert.SerializeObject(input), dt.Token, dt.UserId);


            return SharedLogic.CalcResult(res);
        }

        internal async Task<string> AddSelectedBorrowing(BorrowingDto input, UserLoginDto dt)
        {
            var inputJson = JsonConvert.SerializeObject(input);
            var res = await _apiCaller.CallPostApiAsync(_apiUrl + Helpers.APIMethodUrls.Borrowing, APIMethodUrls.JsonContent, inputJson, dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = obj.Value<int>("data");
                    return data + "";
                }
                return SharedLogic.CalcResult(res);
            }
            return null;
        }

        internal async Task<bool> DelBorrowingAsync(int Borrowingid, UserLoginDto dt)
        {
            var res = await _apiCaller.CallDeleteApiAsync(_apiUrl + Helpers.APIMethodUrls.Borrowing, Helpers.APIMethodUrls.JsonContent, @"{""Id"":" + Borrowingid + "}", dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    return obj.Value<bool>("data");
                    //var data = JsonConvert.DeserializeObject<List<BorrowingDto>>(obj.GetValue("data").ToString());
                    //return data;
                }
            }
            return false;
        }

        internal async Task<List<BorrowingDto>> GetBorrowingListAsync()
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.Borrowing, "", 0);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BorrowingDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }
        internal async Task<bool> UpdateBorrowingAsync(UpdateBorrowingCommand input,UserLoginDto dt)
        {
            var res = await _apiCaller.CallPutApiAsync(_apiUrl + Helpers.APIMethodUrls.Borrowing, Helpers.APIMethodUrls.JsonContent, JsonConvert.SerializeObject(input), dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = bool.Parse(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return false;
        }

        //internal async Task<List<BorrowingDto>> GetBorrowingsForDashboardAdminAsync(UserLoginDto dt)
        //{
        //    var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.BorrowingForDashboardAdmin, dt.Token, dt.UserId);
        //    if (res.StartsWith("errorOccured:") == false)
        //    {
        //        var obj = JObject.Parse(res);
        //        if (obj.Value<bool>("success"))
        //        {
        //            var data = JsonConvert.DeserializeObject<List<BorrowingDto>>(obj.GetValue("data").ToString());
        //            return data;
        //        }
        //    }
        //    return null;
        //}

        internal async Task<List<BorrowingDto>> GetSelectedBorrowing(UserLoginDto dt)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.Borrowing, dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BorrowingDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }
    }
}
