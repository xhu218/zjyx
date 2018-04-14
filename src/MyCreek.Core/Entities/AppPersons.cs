﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCreek.Entities
{
    [Table("AppPersons")]
    public class Person : AuditedEntity<Guid>
    {
        public const int MaxNameLength = 32;

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public Person()
        {

        }

        public Person(string name)
        {
            Name = name;
        }
    }
}
