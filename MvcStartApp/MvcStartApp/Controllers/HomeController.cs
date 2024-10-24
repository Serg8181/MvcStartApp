using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models;
using MvcStartApp.Models.Db;
using System.Diagnostics;

namespace MvcStartApp.Controllers
{
    public class HomeController : Controller
    {
        // ������ �� �����������
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        // ����� ������� ������������� � �����������
        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        // ������� ����� �����������
        public async Task<IActionResult> Index()
        {
            // ������� �������� ������ ������������
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // ������� � ����
            await _repo.AddUser(newUser);

            // ������� ���������
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();
        }

        public async Task<IActionResult> Authors()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }

    }
}
