<%@ WebHandler Language="C#" Class="StudentAffiairs.Data" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DHTMLX.Scheduler.Data;

namespace StudentAffiairs
{    
    /// <summary>
    /// DHXScheduler, Data loading
    /// </summary>
    public class Data : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            context.Response.Write( new SchedulerAjaxData(_GetData()).Render());
            
        }

        protected IEnumerable<CalendarEvent> _GetData()
        {
            return new List<CalendarEvent>{ 
                        new CalendarEvent{
                            id = 1, 
                            text = "Sample Event", 
                            start_date = new DateTime(2012, 09, 03, 6, 00, 00), 
                            end_date = new DateTime(2012, 09, 03, 8, 00, 00)
                        },
                        new CalendarEvent{
                            id = 2, 
                            text = "New Event", 
                            start_date = new DateTime(2012, 09, 05, 9, 00, 00), 
                            end_date = new DateTime(2012, 09, 05, 12, 00, 00)
                        },
                        new CalendarEvent{
                            id = 3, 
                            text = "Multiday Event", 
                            start_date = new DateTime(2012, 09, 03, 10, 00, 00), 
                            end_date = new DateTime(2012, 09, 10, 12, 00, 00)
                        }
                    };
               
        }
        
        public bool IsReusable {get{return false;}}
    }
}