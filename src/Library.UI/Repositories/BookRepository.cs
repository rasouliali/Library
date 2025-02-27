using Library.Application.Dto;
using Library.Application.Dto;
using Library.Application.UseCases.Books.Queries.GetFiltersBooks;
using Library.UI.Helpers;
using Library.UI.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library.UI.Repositories
{
    public class BookRepository
    {
        private readonly ApiCaller _apiCaller;
        private readonly string _apiUrl;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(ILogger<BookRepository> logger, ApiCaller apiCaller, IConfiguration config)
        {
            this._apiCaller = apiCaller;
            _apiUrl = config.GetValue<string>("ApiUrl");
            _logger = logger;
        }

        internal async Task<string> AddBorrowingAsync(BorrowingDto input, UserLoginDto dt)
        {
            var res = await _apiCaller.CallPostApiAsync(_apiUrl + APIMethodUrls.Borrowing, APIMethodUrls.JsonContent, JsonConvert.SerializeObject(input), dt.Token, dt.UserId);
            return SharedLogic.CalcResult(res);
        }

        internal async Task<string> AddBookAsync(BookViewModel input, UserLoginDto dt)
        {
            //input.ImageFileName = FileHelper.GetFile(fileData);

            var url = _apiUrl + APIMethodUrls.Book;
            //if (dt.Roles == "Admin")
            //    url = _apiUrl + APIMethodUrls.Book_AddBookByAdmin;

            var res = await _apiCaller.CallPostApiAsync(url, APIMethodUrls.JsonContent, JsonConvert.SerializeObject(input), dt.Token, dt.UserId);
            return SharedLogic.CalcResult(res);
        }


        internal async Task<string> UpdateBookAsync(BookViewModel input, UserLoginDto dt)
        {
            //input.ImageFileName = FileHelper.GetFile(fileData);

            var url = _apiUrl + APIMethodUrls.Book;
            //if (dt.Roles == "Admin")
            //    url = _apiUrl + APIMethodUrls.Book_AddBookByAdmin;

            var res = await _apiCaller.CallPutApiAsync(url, APIMethodUrls.JsonContent, JsonConvert.SerializeObject(input), dt.Token, dt.UserId);


            return SharedLogic.CalcResult(res);
        }

        internal async Task<string> AddSelectedBook(BorrowingDto input, UserLoginDto dt)
        {
            var inputJson = JsonConvert.SerializeObject(input);
            var res = await _apiCaller.CallPostApiAsync(_apiUrl + Helpers.APIMethodUrls.SelectedBook, APIMethodUrls.JsonContent, inputJson, dt.Token, dt.UserId);
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

        internal async Task<bool> DelBookAsync(int Bookid, UserLoginDto dt)
        {
            var res = await _apiCaller.CallDeleteApiAsync(_apiUrl + Helpers.APIMethodUrls.Book, Helpers.APIMethodUrls.JsonContent, @"{""Id"":" + Bookid + "}", dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    return obj.Value<bool>("data");
                    //var data = JsonConvert.DeserializeObject<List<BookDto>>(obj.GetValue("data").ToString());
                    //return data;
                }
            }
            return false;
        }

        internal async Task<List<BookDto>> GetBookListAsync()
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.Book,"", 0);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BookDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }

        internal async Task<List<BookSimpleDto>> GetRemainBooksAsync(UserLoginDto dt)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.RemainBooks, dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BookSimpleDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }
        internal async Task<BookDto> GetBookByIdAsync(int id,UserLoginDto dt)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.Book + "/" + id, dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<BookDto>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }

        internal async Task<List<BookDto>> GetFiltersBooksAsync(SearchViewModel input)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.FiltersBooksQuery+ 
                "?Author=" + input.Author+
                "&Category=" + input.Category+
                "&PublishYear=" + input.PublishYear+
                "&Title=" + input.Title
                , "", 0);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BookDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }
        
        internal async Task<List<BookDto>> GetNotReturnedBooksAsync(UserLoginDto dt)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.NotReturnedBooksQuery, dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BookDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }
        
        internal async Task<List<BookDto>> GetBorrowingBooksAsync(UserLoginDto dt)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.BorrowingBooksQuery, dt.Token, dt.UserId);
            if (res.StartsWith("errorOccured:") == false)
            {
                var obj = JObject.Parse(res);
                if (obj.Value<bool>("success"))
                {
                    var data = JsonConvert.DeserializeObject<List<BookDto>>(obj.GetValue("data").ToString());
                    return data;
                }
            }
            return null;
        }

        internal async Task<List<BorrowingDto>> GetSelectedBook(UserLoginDto dt)
        {
            var res = await _apiCaller.CallGetApiAsync(_apiUrl + Helpers.APIMethodUrls.SelectedBook, dt.Token, dt.UserId);
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
