using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Scheduler;

namespace StudentAffiairs.Controllers
{
    public class ExportToPDFController : Controller
    {
        // GET: ExportToPDF
        public  ActionResult Index()
        {
            var sched = new DHXScheduler
            {
                Controller = "BasicScheduler",
                Config = {first_hour = 8},
                LoadData = true,
                EnableDataprocessor = true
            };

            // 'PDF' extension is required
            sched.Extensions.Add(SchedulerExtensions.Extension.PDF);
            
            sched.InitialDate = new DateTime(2017, 9, 19);
            return View(sched);
        }
    }
}