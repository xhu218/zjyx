using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyCreek.Services.dto;
using Abp.Domain.Repositories;
using MyCreek.Entities;
using Abp.Collections.Extensions;
using System.Linq;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.Events.Bus;
using MyCreek.Services.TaskEnent;
using Abp.Dapper.Repositories;

namespace MyCreek.Services
{
    public class MyTaskAppService : MyCreekAppServiceBase, IMyTaskAppService
    {
        private readonly IRepository<MyTask> _taskRepository;

        private readonly IDapperRepository<MeetingRoom> _meetingRoomDapperRepository;

        public IEventBus EventBus { get; set; }
        public MyTaskAppService(IRepository<MyTask> taskRepository, IDapperRepository<MeetingRoom> meetingRoomDapperRepository)
        {
            _taskRepository = taskRepository;
            EventBus = NullEventBus.Instance;
            _meetingRoomDapperRepository = meetingRoomDapperRepository;
        }



        public async Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            //var tasks = await _taskRepository
            //    .GetAll().Include(c=>c.AssignedPerson)
            //    .WhereIf(input.State.HasValue, t => t.State == input.State.Value)
            //    .OrderByDescending(t => t.CreationTime)
            //    .ToListAsync();


            var people = _meetingRoomDapperRepository.Query("select * from meetingrooms");

            var tasks = await _taskRepository
                .GetAll()
                .ToListAsync();

            // EventBus.Trigger(new TaskCompletedEventData { Task= tasks.FirstOrDefault() });

            return new ListResultDto<TaskListDto>(
                ObjectMapper.Map<List<TaskListDto>>(tasks)
            );
        }

        public async System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<MyTask>(input);
            try
            {
                await _taskRepository.InsertAsync(task);
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
    }
}
