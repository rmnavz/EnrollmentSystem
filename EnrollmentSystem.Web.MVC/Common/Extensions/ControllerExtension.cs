using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public class ControllerExtension : Controller
    {
        protected internal ViewResult ViewModal()
        {
            return ViewModal(viewName: null, model: null, dynamicModalOptions: null);
        }

        protected internal ViewResult ViewModal(object model)
        {
            return ViewModal(null /* viewName */, model, dynamicModalOptions: null);
        }

        protected internal ViewResult ViewModal(string viewName)
        {
            return ViewModal(viewName, model: null, dynamicModalOptions: null);
        }

        protected internal ViewResult ViewModal(string viewName, object model)
        {
            return ViewModal(viewName, model, dynamicModalOptions: null);
        }

        protected internal ViewResult ViewModal(DynamicModalOptions dynamicModalOptions)
        {
            return ViewModal(viewName: null, model: null, dynamicModalOptions: dynamicModalOptions);
        }

        protected internal ViewResult ViewModal(object model, DynamicModalOptions dynamicModalOptions)
        {
            return ViewModal(null /* viewName */, model, dynamicModalOptions: dynamicModalOptions);
        }

        protected internal ViewResult ViewModal(string viewName, DynamicModalOptions dynamicModalOptions)
        {
            return ViewModal(viewName, model: null, dynamicModalOptions: dynamicModalOptions);
        }

        protected internal ViewResult ViewModal(string viewName, object model, DynamicModalOptions dynamicModalOptions)
        {
            ViewBag.IsForm = false;

            if (dynamicModalOptions != null)
            {
                if (dynamicModalOptions.Title != null)
                {
                    ViewBag.Title = dynamicModalOptions.Title;
                }
                else
                {
                    ViewBag.Title = null;
                }

                if (dynamicModalOptions.ActionName != null)
                {
                    ViewBag.ActionName = dynamicModalOptions.ActionName;
                }
                else
                {
                    ViewBag.ActionName = null;
                }

                if (dynamicModalOptions.ControllerName != null)
                {
                    ViewBag.ControllerName = dynamicModalOptions.ControllerName;
                }
                else
                {
                    ViewBag.ControllerName = null;
                }

                if (dynamicModalOptions.FormMethod != null)
                {
                    ViewBag.FormMethod = dynamicModalOptions.FormMethod;
                    ViewBag.FormType = dynamicModalOptions.FormType;
                    ViewBag.IsForm = true;
                }
            }

            return View(viewName, "~/Views/Shared/_DynamicModalLayout.cshtml", model);
        }
    }

    public class DynamicModalOptions
    {
        public string Title { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public FormMethod? FormMethod { get; set; }
        public FormType FormType { get; set; }
    }

    public enum FormType
    {
        Create,
        Add,
        Edit
    }
}