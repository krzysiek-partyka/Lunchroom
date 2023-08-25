using AutoMapper;
using Lunchroom.Application.Lunchroom;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Application.Lunchroom.Commands.EditLunchroom;
using Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms;
using Lunchroom.Application.Lunchroom.Queries.GetLunchroomByEncodedName;
using Lunchroom.Application.Services;
using Lunchroom.Application.Student.Commands.CreateStudent;
using Lunchroom.Application.Student.Queries.GetAllStudents;
using Lunchroom.Domain.Interfaces;
using Lunchroom.MVC.Extensions;
using Lunchroom.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return View(model); ;
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
        [Route("Lunchroom/{enodedName}/GetStudent")]
        public async Task<IActionResult> GetStudents(string enodedName)
        {
            var result = await _mediator.Send(new LunchroomGetStudentQuery() { EncodedName = enodedName });
            return Ok(result);
        }

        public async Task AddLunch()
        {

        }
    }
}
