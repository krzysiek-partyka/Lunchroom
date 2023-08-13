using AutoMapper;
using Lunchroom.Application.Lunchroom;
using Lunchroom.Application.Lunchroom.Commands.CreateLunchroom;
using Lunchroom.Application.Lunchroom.Commands.EditLunchroom;
using Lunchroom.Application.Lunchroom.Queries.GetAllLunchrooms;
using Lunchroom.Application.Lunchroom.Queries.GetLunchroomByEncodedName;
using Lunchroom.Application.Services;
using Lunchroom.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            return RedirectToAction(nameof(Index));
        }
        [Route("Lunchroom/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetLunchroomByEncodedNameQuery(encodedName));
            EditLunchroomCommand model = _mapper.Map<EditLunchroomCommand>(dto);
            return View(model); ;
        }
        [Route("Lunchroom/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await  _mediator.Send(new GetLunchroomByEncodedNameQuery(encodedName));
            return View(dto);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLunchroomCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        } 
    }
}
