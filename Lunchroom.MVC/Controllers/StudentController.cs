using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Application.Student.Commands.CreateStudent;
using Lunchroom.Application.Student.Queries;
using Lunchroom.Application.Student.Queries.GetAllStudents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lunchroom.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IActionResult> Index(string encodedName)
        {
            var students = await _mediator.Send(new GetAllStudentsQuery(encodedName));
            return View(students);
        }
        [Route("/Lunchroom/{encodedName}/Student/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Lunchroom/{encodedName}/Student/Create")]
        public async Task<IActionResult> Create (string encodedName, CreateStudentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(new CreateStudentCommand(encodedName));
            return RedirectToAction(nameof(Index));
        }
    }
}
