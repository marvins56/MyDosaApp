<%@ WebHandler Language="C#" Class="StudentAffiairs.Save" %>

using System;
using System.Collections.Generic;
using System.Web;
using DHTMLX.Common;
using DHTMLX.Helpers;
using System.Linq;

namespace StudentAffiairs
{
    /// <summary>
    /// DHXScheduler, process changes, render response
    /// </summary>
    public class Save : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var action = new DataAction(context.Request.Form);
            try
            {
                var changedEvent = (CalendarEvent)DHXEventsHelper.Bind(typeof(CalendarEvent), context.Request.Form);//create event object from request

                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        // define here your Insert logic

                        //action.TargetId = changedEvent.id;//assign postoperational id
                        break;
                    case DataActionTypes.Delete:
                        // define here your Delete logic
                        break;
                    default:// "update" 
                        // define here your Update logic
                        break;
                }                
            }
            catch{ action.Type = DataActionTypes.Error;}
            
            context.Response.ContentType = "text/xml";
            context.Response.Write(new AjaxSaveResponse(action).Render());
        }

        public bool IsReusable{get {return false;}}
    }
}