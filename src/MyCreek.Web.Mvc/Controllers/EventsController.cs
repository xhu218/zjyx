using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCreek.Events;
using MyCreek.Controllers;
using MyCreek.Web.Models.Events;
using MyCreek.Events.Dtos;

namespace MyCreek.Web.Mvc.Controllers
{
    public class EventsController : MyCreekControllerBase
    {
        private readonly IEventAppService _eventAppService;
        public EventsController(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }
        public async Task<IActionResult> Index(GetEventListInput input)
        {
            var output = await _eventAppService.GetListAsync(input);
            var model = new IndexViewModel(output.Items)
            {
              
            };
          
            return View(model);
        }
    }
}