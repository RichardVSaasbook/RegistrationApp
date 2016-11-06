using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Models
{
    public class NullMessageModel : MessageModel
    {
        public override MvcHtmlString ToHTML()
        {
            return MvcHtmlString.Empty;
        }
    }
}