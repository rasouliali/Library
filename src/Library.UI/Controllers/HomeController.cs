using Library.Application.Dto;
using Library.UI.Helpers;
using Library.UI.Models;
using Library.UI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Library.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiCaller _apiCaller;
        private readonly string _apiUrl;
        private readonly BookRepository _repository;

        public HomeController(ILogger<HomeController> logger, ApiCaller apiCaller, IConfiguration config, BookRepository bookRepository)
        {
            _logger = logger;
            this._apiCaller = apiCaller;
            _apiUrl = config.GetValue<string>("ApiUrl");
            _repository = bookRepository;
        }

        public async Task<IActionResult> Index(SearchViewModel searchInput)
        {
            searchInput = searchInput ?? new SearchViewModel();
            var res = await _repository.GetFiltersBooksAsync(searchInput);
            searchInput.Books = res;
            return View(searchInput);
        }
        [Authorize]
        public async Task<IActionResult> Report()
        {
            var dt = AuthData.GetUserData(HttpContext);
            var report = new ReportViewModel();
            report.NotReturnedBooks = await _repository.GetNotReturnedBooksAsync(dt);
            report.BorrowingBooks = await _repository.GetBorrowingBooksAsync(dt);
            return View(report);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
