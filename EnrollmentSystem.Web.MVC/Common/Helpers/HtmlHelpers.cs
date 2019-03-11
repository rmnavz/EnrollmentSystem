using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EnrollmentSystem.Web.MVC.Common.Helpers
{
    public static class HtmlHelpers
    {

        public static MvcHtmlString UploadFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            Type paramType = expression.Parameters[0].Type;
            var memberInfo = paramType.GetMember((expression.Body as MemberExpression).Member.Name)[0];
            string InputStr = $"<input type=\"file\" id=\"{memberInfo.Name}\" name=\"{memberInfo.Name}\" class=\"form-control-input\">";
            return new MvcHtmlString(InputStr);
        }

    }
}