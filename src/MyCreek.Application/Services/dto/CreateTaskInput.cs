using Abp.AutoMapper;
using MyCreek.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCreek.Services.dto
{
    [AutoMapTo(typeof(MyTask))]
    public class CreateTaskInput
    {
        [Required]
        [MaxLength(MyTask.MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(MyTask.MaxDescriptionLength)]
        public string Description { get; set; }

        public Guid? AssignedPersonId { get; set; }
    }
}
