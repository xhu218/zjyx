using MyCreek.Entities.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCreek.Events.Dtos
{
    public class CreateEventInput
    {
        [Required]
        [StringLength(CreekEvent.MaxTitleLength)]
        public string Title { get; set; }

        [StringLength(CreekEvent.MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Range(0, int.MaxValue)]
        public int MaxRegistrationCount { get; set; }
    }
}
