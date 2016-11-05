using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.HtmlHelpers
{
    public static class TimeHelpers
    {
        public static MvcHtmlString TimeFormat(this HtmlHelper html, TimeSpan time)
        {
            DateTime dateTime = DateTime.Today.Add(time);
            return MvcHtmlString.Create(dateTime.ToString("hh:mm tt"));
        }
    }
}