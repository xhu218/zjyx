using MyCreek.Events.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCreek.Web.Models.Events
{
    public class IndexViewModel
    {
        public IReadOnlyList<EventListDto> Events { get; }

        public IndexViewModel(IReadOnlyList<EventListDto> events)
        {
            Events = events;
        } 
    }
}
