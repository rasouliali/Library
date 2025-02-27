using Library.Application.Dto;
using Library.Application.UseCases.Borrowings.Commands.Add;
using Library.Application.UseCases.Borrowings.Commands.Update;
using Library.UI.Helpers;
using Library.UI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.UI.Controllers
{
    [Authorize]
    public class BorrowingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiCaller _apiCaller;
        private readonly string _apiUrl;
        private readonly BorrowingRepository _repository;
        private readonly BookRepository _bookrepository;

        public BorrowingController(ILogger<HomeController> logger, ApiCaller apiCaller, IConfiguration config, BookRepository bookrepository, BorrowingRepository repository)
        {
            _logger = logger;
            this._apiCaller = apiCaller;
            _apiUrl = config.GetValue<string>("ApiUrl");
            _repository = repository;
            _bookrepository = bookrepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var res = await _repository.GetBorrowingListAsync();
            return View(res);
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            var dt = AuthData.GetUserData(HttpContext);
            var res = await _bookrepository.GetRemainBooksAsync(dt);
            ViewBag.Books = new SelectList(res, "Id", "Title");
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AddBorrowingCommand input)
        {
            if (ModelState.IsValid)
            {
                var dt = AuthData.GetUserData(HttpContext);
                var res = await _repository.AddBorrowingAsync(input, dt);
                if (res == "401")
                    return RedirectToAction("Logout", "Account");
                else if (res.Length > 0)
                    ModelState.AddModelError("", res);
                else
                    ViewBag.IsSuccess = true;
            }
            else
            {
                var dt = AuthData.GetUserData(HttpContext);
                var res = await _bookrepository.GetRemainBooksAsync(dt);
                ViewBag.Books = new SelectList(res, "Id", "Title");
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> ExtentBook(int id)
        {
            var dt = AuthData.GetUserData(HttpContext);
            UpdateBorrowingCommand input = new UpdateBorrowingCommand() { Id = id, IsReturn = false, IsExtend= true };
            var res = await _repository.UpdateBorrowingAsync(input, dt);
            return RedirectToAction("Index","Borrowing");
        }
        [Authorize]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var dt = AuthData.GetUserData(HttpContext);
            UpdateBorrowingCommand input = new UpdateBorrowingCommand() { Id = id, IsReturn =true,IsExtend=false};
            var res = await _repository.UpdateBorrowingAsync(input, dt);
            return RedirectToAction("Index","Borrowing");
        }
    }
}
