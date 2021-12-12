using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ITP245_Model;

namespace ITP245_2021_Fall.htmlHelpers
{
    public static class HtmlExtensions
    {

        public static MvcHtmlString EmailAnchor(this HtmlHelper html, IEmail email)
        {
            var anchor = new TagBuilder("a") { InnerHtml = email.VendorEmail };
            anchor.MergeAttribute("href", "mailto:" + email.VendorEmail + "?subject=" + email.VendorContact);
            anchor.MergeAttribute("subject", email.VendorContact);
            anchor.MergeAttribute("class", "email");
            string emailAnchor = anchor.ToString(TagRenderMode.Normal);

            return new MvcHtmlString(emailAnchor);
        }
        public static MvcHtmlString SearchBox(this HtmlHelper html, string message)
        {
            var label = new TagBuilder("label") { InnerHtml = "Search" };
            label.MergeAttribute("id", "SearchLabel");
            label.MergeAttribute("style", "margin-left: 1rem; margin-right: 1rem;");
            string labelBox = label.ToString(TagRenderMode.Normal);

            var tag = new TagBuilder("input");
            tag.MergeAttribute("id", "search");
            tag.MergeAttribute("size", "36");
            tag.MergeAttribute("style", "margin-left: .5rem");
            tag.MergeAttribute("type", "text");
            tag.MergeAttribute("value", String.Empty);
            tag.MergeAttribute("placeholder", $"{message} Press Tab");
            tag.MergeAttribute("onchange", "SearchByName();");
            string searchBox = tag.ToString(TagRenderMode.Normal);

            return new MvcHtmlString(labelBox + searchBox);
        }

    }
}