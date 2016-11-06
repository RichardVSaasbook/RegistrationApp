using RegistrationWeb.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.HtmlHelpers
{
    public static class MessageHelpers
    {
        public static MvcHtmlString DisplayMessage(this HtmlHelper html, object o)
        {
            MessageModel message = (MessageModel)o;

            if (message == null)
            {
                return MvcHtmlString.Empty;
            }

            return message.ToHTML();
        }
    }
}