// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace CommunityCourses.Web.Controllers {
    public partial class CourseController {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CourseController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected CourseController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result) {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Index() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Index);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Details() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Edit() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult AddStudent() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.AddStudent);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult UpdateSessionComplete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.UpdateSessionComplete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult UpdateModuleComplete() {
            return new T4MVC_ActionResult(Area, Name, ActionNames.UpdateModuleComplete);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public CourseController Actions { get { return MVC.Course; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Course";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass {
            public readonly string Index = "Index";
            public readonly string Details = "Details";
            public readonly string Create = "Create";
            public readonly string Edit = "Edit";
            public readonly string AddStudent = "AddStudent";
            public readonly string UpdateSessionComplete = "UpdateSessionComplete";
            public readonly string UpdateModuleComplete = "UpdateModuleComplete";
        }


        static readonly ViewNames s_views = new ViewNames();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewNames Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewNames {
            public readonly string Create = "~/Views/Course/Create.aspx";
            public readonly string Details = "~/Views/Course/Details.ascx";
            public readonly string Edit = "~/Views/Course/Edit.aspx";
            public readonly string Index = "~/Views/Course/Index.aspx";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_CourseController: CommunityCourses.Web.Controllers.CourseController {
        public T4MVC_CourseController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Index(int page) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Index);
            callInfo.RouteValueDictionary.Add("page", page);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Details(string id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Details);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create() {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Create);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Create(CommunityCourses.Web.Model.Course course) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Create);
            callInfo.RouteValueDictionary.Add("course", course);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(string id) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AddStudent(string id, string studentId) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.AddStudent);
            callInfo.RouteValueDictionary.Add("id", id);
            callInfo.RouteValueDictionary.Add("studentId", studentId);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UpdateSessionComplete(string courseId, string studentId, string sessionId, bool complete) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UpdateSessionComplete);
            callInfo.RouteValueDictionary.Add("courseId", courseId);
            callInfo.RouteValueDictionary.Add("studentId", studentId);
            callInfo.RouteValueDictionary.Add("sessionId", sessionId);
            callInfo.RouteValueDictionary.Add("complete", complete);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UpdateModuleComplete(string courseId, string studentId, string moduleId, bool complete) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.UpdateModuleComplete);
            callInfo.RouteValueDictionary.Add("courseId", courseId);
            callInfo.RouteValueDictionary.Add("studentId", studentId);
            callInfo.RouteValueDictionary.Add("moduleId", moduleId);
            callInfo.RouteValueDictionary.Add("complete", complete);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Edit(CommunityCourses.Web.Model.Course course) {
            var callInfo = new T4MVC_ActionResult(Area, Name, ActionNames.Edit);
            callInfo.RouteValueDictionary.Add("course", course);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
