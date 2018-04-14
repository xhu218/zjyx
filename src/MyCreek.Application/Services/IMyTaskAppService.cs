using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCreek.Services.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Services
{
    public interface IMyTaskAppService: IApplicationService
    {
        /// <summary>
        /// ListResultDto:是用来表达列表dto的
        /// 注意：这时还不具备分页功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ListResultDto<TaskListDto>> GetAll(GetAllTasksInput input);
        System.Threading.Tasks.Task Create(CreateTaskInput input);
    }
}
