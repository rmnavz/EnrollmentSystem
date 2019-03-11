using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Common.PartialModels
{
    public class EditableDisplay
    {
        public MvcHtmlString DisplayName { get; set; }
        public MvcHtmlString DisplayText { get; set; }
        public MvcHtmlString Editor { get; set; }
    }
}