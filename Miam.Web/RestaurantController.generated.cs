// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Miam.Web.Controllers
{
    public partial class RestaurantController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RestaurantController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult DeleteConfirmed()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public RestaurantController Actions { get { return MVC.Restaurant; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Restaurant";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Restaurant";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Edit = "Edit";
            public readonly string Delete = "Delete";
            public readonly string DeleteConfirmed = "Delete";
            public readonly string Create = "Create";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string DeleteConfirmed = "Delete";
            public const string Create = "Create";
        }


        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string restaurantID = "restaurantID";
            public readonly string restaurantEditViewModel = "restaurantEditViewModel";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string restaurantId = "restaurantId";
        }
        static readonly ActionParamsClass_DeleteConfirmed s_params_DeleteConfirmed = new ActionParamsClass_DeleteConfirmed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteConfirmed DeleteConfirmedParams { get { return s_params_DeleteConfirmed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteConfirmed
        {
            public readonly string restaurantId = "restaurantId";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string restaurantViewModel = "restaurantViewModel";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string Create = "Create";
                public readonly string Delete = "Delete";
                public readonly string Edit = "Edit";
                public readonly string Index = "Index";
            }
            public readonly string Create = "~/Views/Restaurant/Create.cshtml";
            public readonly string Delete = "~/Views/Restaurant/Delete.cshtml";
            public readonly string Edit = "~/Views/Restaurant/Edit.cshtml";
            public readonly string Index = "~/Views/Restaurant/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_RestaurantController : Miam.Web.Controllers.RestaurantController
    {
        public T4MVC_RestaurantController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int restaurantID);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int restaurantID)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "restaurantID", restaurantID);
            EditOverride(callInfo, restaurantID);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Miam.Web.ViewModels.Restaurant.RestaurantEditViewModel restaurantEditViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(Miam.Web.ViewModels.Restaurant.RestaurantEditViewModel restaurantEditViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "restaurantEditViewModel", restaurantEditViewModel);
            EditOverride(callInfo, restaurantEditViewModel);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int restaurantId);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int restaurantId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "restaurantId", restaurantId);
            DeleteOverride(callInfo, restaurantId);
            return callInfo;
        }

        [NonAction]
        partial void DeleteConfirmedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int restaurantId);

        [NonAction]
        public override System.Web.Mvc.ActionResult DeleteConfirmed(int restaurantId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteConfirmed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "restaurantId", restaurantId);
            DeleteConfirmedOverride(callInfo, restaurantId);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ViewResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ViewResult Create()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ViewResult(Area, Name, ActionNames.Create);
            CreateOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Miam.Web.ViewModels.Restaurant.RestaurantCreateViewModel restaurantViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(Miam.Web.ViewModels.Restaurant.RestaurantCreateViewModel restaurantViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "restaurantViewModel", restaurantViewModel);
            CreateOverride(callInfo, restaurantViewModel);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
