using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Models
{
    public class MessageModel
    {
        public string Text { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Convert the message to HTML for display.
        /// </summary>
        /// <returns>The HTML representation of the message.</returns>
        public virtual MvcHtmlString ToHTML()
        {
            TagBuilder msg = new TagBuilder("div");
            msg.AddCssClass("alert");
            msg.AddCssClass("alert-" + Type);
            msg.InnerHtml = Text;

            return MvcHtmlString.Create(msg.ToString());
        }
    }
}