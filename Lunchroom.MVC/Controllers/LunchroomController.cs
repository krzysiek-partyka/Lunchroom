using AutoMapper;
using Humanizer;
using Lunchroom.Application.Lunchroom;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Application.Lunchroom.Commands.EditLunchroom;
using Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms;
using Lunchroom.Application.Lunchroom.Queries.GetLunchroomByEncodedName;
using Lunchroom.Application.Services;
using Lunchroom.Application.Student;
using Lunchroom.Application.Student.Commands.AddLunch;
using Lunchroom.Application.Student.Commands.CreateStudent;
using Lunchroom.Application.Student.Commands.EditStudent;
using Lunchroom.Application.Student.Commands.RemoveLunch;
using Lunchroom.Application.Student.Queries.CreateRaport;
using Lunchroom.Application.Student.Queries.GetAllStudents;
using Lunchroom.Application.Student.Queries.GetStudentById;
using Lunchroom.Domain.Interfaces;
using Lunchroom.MVC.Extensions;
using Lunchroom.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Lunchroom.MVC.Controllers
{
    public class LunchroomController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LunchroomController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var lunchrooms = await _mediator.Send(new GetAllLunchroomsQuery());
            return View(lunchrooms);
        }
        [HttpPost]
        [Route("Lunchroom/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditLunchroomCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            
            this.SetNotification("success",$"{command.Name} has Edit");

            return RedirectToAction(nameof(Index));
        }

        [Route("Lunchroom/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetLunchroomByEncodedNameQuery(encodedName));
            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess","Home");
            }
            EditLunchroomCommand model = _mapper.Map<EditLunchroomCommand>(dto);
            return View(model);
        }
        [Route("Lunchroom/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await  _mediator.Send(new GetLunchroomByEncodedNameQuery(encodedName));
            return View(dto);
        }

        //[Authorize(Roles = ("Owner"))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles =("Owner"))]
        public async Task<IActionResult> Create(CreateLunchroomCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created Lunchroom {command.Name}");

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Authorize(Roles = ("Owner,Moderator"))]
        [Route("Lunchroom/CreateStudent")]
        public async Task<IActionResult> CreateStudent(CreateStudentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Lunchroom/{encodedName}/GetStudent")]
        public async Task<IActionResult> GetStudents(string encodedName)
        {
            var result = await _mediator.Send(new LunchroomGetStudentQuery() { EncodedName = encodedName });
            return Ok(result);
        }

        [HttpGet]
        [Route("Lunchroom/{encodedName}/Student/{id}")]
        public async Task<IActionResult> EditStudent(string encodedName, int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery() { EncodedName = encodedName, Id = id });
            //if (!dto.IsEditable)
            //{
            //    return RedirectToAction("NoAccess", "Home");
            //}
            return View(result);
        }

        [HttpPost]
        [Route("Lunchroom/{encodedName}/Student/{studentId}")]
        public async Task<IActionResult> EditStudent(EditStudentCommand dto, string encodedName, int studentId)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _mediator.Send(dto);

            this.SetNotification("success", $"{dto.FirstName} {dto.LastName} has Edit");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Student/{studentId}/AddLunch")]
        public async Task<IActionResult> AddLunch(int studentId)
        {
            var command = await _mediator.Send(new AddLunchCommand()
            {Id = studentId});

            return Ok();
        }

        [HttpPost]
        [Route("Student/{studentId}/RemoveLunch")]
        public async Task<IActionResult> RemovedLunch(int studentId)
        {
            var command = await _mediator.Send(new RemoveLunchCommand()
            { Id = studentId });

            return Ok();
        }

        [HttpGet]
        [Route("Student/CreateRaport")]
        public async Task<IActionResult> CreateRaport()
        {
            var command = await _mediator.Send(new CreateRaportQuery());
            return View(command);
        }


    }
}
