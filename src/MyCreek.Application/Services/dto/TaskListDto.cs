using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using MyCreek.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Services.dto
{
    /// <summary>
    /// 返回任务列表，其中的某一行的对象
    /// </summary>
    [AutoMapFrom(typeof(MyTask))]
    public class TaskListDto : EntityDto, IHasCreationTime
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        public Guid? AssignedPersonId { get; set; }

        public string AssignedPersonName { get; set; }
    }

    /// <summary>
    /// getall  是接口的名称 input 是指：传入
    /// 
    /// 这个类名称的意思就是：针对getall方法，需要传入的参数对象
    /// getall：是指获取所有实体。里面的属性：就是用来过滤的条件
    /// </summary>
    public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }
}
