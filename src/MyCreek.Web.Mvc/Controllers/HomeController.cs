using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyCreek.Controllers;
using Abp.Quartz;
using System.Threading.Tasks;
using CreekQuartz;
using Quartz;

namespace MyCreek.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyCreekControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }


        private readonly IQuartzScheduleJobManager _jobManager;

        public HomeController(IQuartzScheduleJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public async Task<ActionResult> ScheduleJob()
        {
            await _jobManager.ScheduleAsync<MyLogJob>(
                job =>
                {
                    job.WithIdentity("MyLogJobIdentity", "MyGroup")
                        .WithDescription("A job to simply write logs.");
                },
                trigger =>
                {
                    trigger.StartNow()
                        .WithSimpleSchedule(schedule =>
                        {
                            schedule.RepeatForever()
                                .WithIntervalInSeconds(5)
                                .Build();
                        });
                });

            return Content("OK, scheduled!");
        }

    }
}
