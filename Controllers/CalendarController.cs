using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using StudentAffiairs.Models;
using DHTMLX.Scheduler.Settings;

namespace StudentAffiairs.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Material;
            scheduler.Config.highlight_displayed_event = true;
            scheduler.Config.touch = true;
            scheduler.Config.touch_tip = true;
            scheduler.Config.touch_tooltip = true;
            scheduler.Config.cascade_event_display = true;
            scheduler.Localization.Set(SchedulerLocalization.Localizations.English, false);
            scheduler.Config.timeline_swap_resize = true;
            scheduler.Config.default_date = "%j %M %Y";
            scheduler.Config.display_marked_timespans = true;
            scheduler.Config.drag_lightbox = true;
            scheduler.Config.multi_day = true;
            scheduler.Config.show_loading = true;
            scheduler.Config.separate_short_events = true;
            //scheduler.Config.map_resolve_user_location = true;
            scheduler.Config.map_resolve_event_location = true;
            scheduler.Extensions.Add(SchedulerExtensions.Extension.Serialize);
            scheduler.Extensions.Add(SchedulerExtensions.Extension.PDF);

            scheduler.Config.map_resolve_user_location = true;
// HYBRID - displays a transparent layer of major streets on satellite images.
//ROADMAP - displays a normal street map.
//SATELLITE - displays satellite images.
//TERRAIN - displays maps with physical features such as terrain and vegetation.

            //scheduler.Config.cascade_event_count = 5;
            scheduler.Config.displayed_event_color = "#554994";
           scheduler.InitialDate = new DateTime(2012, 09, 03);
            scheduler.Config.touch_drag = 700;
            //To enable the extension you just need to add the related extension file on the page: 
            
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

            var grid = new GridView("grid");//initializes the view
            grid.Columns.Add(// adds the columns to the grid
               new GridViewColumn("text", "Event")
               {//initializes a column          
                   Width = 300// sets the width of the column
               });

            grid.Columns.Add(
               new GridViewColumn("start_date", "Date")
               {
                   Template = "{start_date:date(%d-%m-%Y %H:%i)}"//sets the template for the column
               });

            grid.Columns.Add(
                new GridViewColumn("details", "Details")
                {
                    Align = GridViewColumn.Aligns.Left// sets the alignment in the column
                });
            scheduler.Views.Add(grid);//adds the view to the scheduler
            //date picker
            var cal = scheduler.Calendars.AttachMiniCalendar();
            cal.Navigation = true;
            //adding agender
            var agenda = new AgendaView();//initializes the view
            scheduler.Views.Add(agenda);//adds the view to the scheduler

            //map view  initializes the view
            var map = new MapView { ApiKey = "AIzaSyBjsINSH5x39Ks6c0_CoS1yr1Mb3cB3cVo" };
               
            scheduler.Views.Add(map);//adds the view to the scheduler

            return View(scheduler);
        }

        public ContentResult Data()
        {
            var data = new SchedulerAjaxData(
                    new List<CalendarEvent>{ 
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
                    }
                );
            return (ContentResult)data;
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            
            try
            {
                var changedEvent = (CalendarEvent)DHXEventsHelper.Bind(typeof(CalendarEvent), actionValues);

     

                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        //do insert
                        // action.TargetId = changedEvent.id;//assign postoperational id
                        break;
                    case DataActionTypes.Delete:
                        //do delete
                        break;
                    default:// "update"                          
                        //do update
                        break;
                }
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (ContentResult)new AjaxSaveResponse(action);
        }
        public ActionResult Export()
        {
            Response.ContentType = "text/plain";
            Response.AppendHeader("content-disposition", "attachment; filename=dhtmlxScheduler.ics");
            return Content(Request.Form["data"].ToString());
        }
    }
}

