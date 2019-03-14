using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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

    public static class NavigationHtmlHelpers
    {
        #region MenuLink
        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, null /* controllerName */, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, null /* controllerName */, new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, null /* controllerName */, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, null /* controllerName */, routeValues, new RouteValueDictionary());
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, null /* controllerName */, routeValues, htmlAttributes);
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (actionName == currentAction && controllerName == currentController)
            {
                htmlAttributes["class"] = htmlAttributes["class"] + " selected";
            }
            return MvcHtmlString.Create(GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null /* routeName */, actionName, controllerName, routeValues, htmlAttributes));
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return NavigationMenuActionLink(htmlHelper, linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString NavigationMenuActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            if (actionName == currentAction && controllerName == currentController)
            {
                htmlAttributes["class"] = htmlAttributes["class"] + " selected";
            }
            return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null /* routeName */, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes));
        }

        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(requestContext, routeCollection, linkText, routeName, actionName, controllerName, null /* protocol */, null /* hostName */, null /* fragment */, routeValues, htmlAttributes);
        }

        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLinkInternal(requestContext, routeCollection, linkText, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true /* includeImplicitMvcValues */);
        }

        private static string GenerateLinkInternal(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool includeImplicitMvcValues)
        {
            string url = UrlHelper.GenerateUrl(routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, routeCollection, requestContext, includeImplicitMvcValues);
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = (!String.IsNullOrEmpty(linkText)) ? HttpUtility.HtmlEncode(linkText) : string.Empty
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
        #endregion
    }

    public static class FontAwesomeHtmlHelpers
    {
        #region FontAwesomeActionLink
        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, null /* controllerName */, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, object routeValues)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, null /* controllerName */, new RouteValueDictionary(routeValues), new RouteValueDictionary());
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, object routeValues, object htmlAttributes)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, null /* controllerName */, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, RouteValueDictionary routeValues)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, null /* controllerName */, routeValues, new RouteValueDictionary());
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, null /* controllerName */, routeValues, htmlAttributes);
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, string controllerName)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, controllerName, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create(GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, fontAwesomeClass, linkText, null /* routeName */, actionName, controllerName, routeValues, htmlAttributes));
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return FontAwesomeActionLink(htmlHelper, fontAwesomeClass, linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString FontAwesomeActionLink(this HtmlHelper htmlHelper, string fontAwesomeClass, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null /* routeName */, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes));
        }

        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string fontAwesomeClass, string linkText, string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(requestContext, routeCollection, fontAwesomeClass, linkText, routeName, actionName, controllerName, null /* protocol */, null /* hostName */, null /* fragment */, routeValues, htmlAttributes);
        }

        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string fontAwesomeClass, string linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLinkInternal(requestContext, routeCollection, fontAwesomeClass , linkText, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true /* includeImplicitMvcValues */);
        }

        private static string GenerateLinkInternal(RequestContext requestContext, RouteCollection routeCollection,string fontAwesomeClass , string linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool includeImplicitMvcValues)
        {
            string url = UrlHelper.GenerateUrl(routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, routeCollection, requestContext, includeImplicitMvcValues);
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = (!String.IsNullOrEmpty(linkText)) ? $"<i class=\"{ fontAwesomeClass }\"></i> { HttpUtility.HtmlEncode(linkText) }" : $"<i class=\"{ fontAwesomeClass }\"></i>"
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
        #endregion

    }
}