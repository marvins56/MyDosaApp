using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Linq;
using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

namespace StudentAffiairs
{
    public partial class Calendar : System.Web.UI.Page
    {
        public string RenderScheduler(){
            var sched = new DHXScheduler();
            /*
             * The default codebase folder is ~/Scripts/dhtmlxScheduler. It can be overriden:
             *      sched.Codebase = this.ResolveUrl("~/customCodebaseFolder");
             */

            sched.InitialDate = new DateTime(2012, 09, 03);// Remove to use current date
            sched.Width = 960;

            sched.SaveAction = ResolveUrl("~/Save.ashx");
            sched.DataAction = ResolveUrl("~/Data.ashx");
            sched.LoadData = true;
            sched.EnableDataprocessor = true;
         
            return sched.Render();
        }
    }
    
}