using Library.Application.Dto;
using Library.UI.Helpers;
using Library.UI.Models;
using Library.UI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Library.UI.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiCaller _apiCaller;
        private readonly string _apiUrl;
        private readonly BookRepository _repository;

        public BooksController(ILogger<HomeController> logger, ApiCaller apiCaller, IConfiguration config, BookRepository postRepository)
        {
            _logger = logger;
            this._apiCaller = apiCaller;
            _apiUrl = config.GetValue<string>("ApiUrl");
            _repository = postRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var res = await _repository.GetBookListAsync();
            return View(res);
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel input)
        {
            if (ModelState.IsValid)
            {
                var dt = AuthData.GetUserData(HttpContext);
                var res = await _repository.AddBookAsync(input, dt);
                if (res == "401")
                    return RedirectToAction("Logout", "Account");
                else if (res.Length > 0)
                    ModelState.AddModelError("", res);
                else
                    ViewBag.IsSuccess = true;
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var dt = AuthData.GetUserData(HttpContext);
            var res = await _repository.GetBookByIdAsync(id, dt);
            return View(res);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel input)
        {
            if (ModelState.IsValid)
            {
                var dt = AuthData.GetUserData(HttpContext);
                var res = await _repository.UpdateBookAsync(input, dt);
                if (res == "401")
                    return RedirectToAction("Logout", "Account");
                else if (res.Length > 0)
                    ModelState.AddModelError("", res);
                else
                    ViewBag.IsSuccess = true;
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var dt = AuthData.GetUserData(HttpContext);
            var res = await _repository.DelBookAsync(id, dt);
            return RedirectToAction("Index","Books");
        }
    }
}
