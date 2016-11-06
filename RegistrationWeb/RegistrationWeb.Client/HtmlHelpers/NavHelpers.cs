using RegistrationWeb.Client.Models;
using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.HtmlHelpers
{
    public static class NavHelpers
    {
        public static MvcHtmlString StudentNav(this HtmlHelper html, StudentsListViewModel studentListViewModel)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(@"<ul class=""nav nav-pills nav-stacked"">");

            foreach (StudentDAO student in studentListViewModel.Students)
            {
                TagBuilder li = new TagBuilder("li");
                li.MergeAttribute("role", "presentation");

                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", "/student/" + student.Person.Id);
                a.InnerHtml = student.Person.Name;

                if (studentListViewModel.CurrentStudentId == student.Person.Id)
                {
                    li.AddCssClass("active");
                }

                li.InnerHtml = a.ToString();
                builder.Append(li.ToString());
            }

            builder.Append("</ul>");

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString CourseNav(this HtmlHelper html, CourseListViewModel courseListViewModel)
        {
            /*StringBuilder builder = new StringBuilder();
            builder.Append(@"<ul class=""list-group"">");

            foreach (var times in courseListViewModel.CourseSchedules.Select(c => new { c.Schedule.StartTime, c.Schedule.EndTime }).OrderBy(c => c.StartTime).ThenBy(c => c.EndTime).GroupBy(c => new { c.StartTime, c.EndTime }))
            {
                TagBuilder listGroupLi = new TagBuilder("li");
                listGroupLi.AddCssClass("list-group-item");

                StringBuilder linksUl = new StringBuilder();
                linksUl.Append(@"<ul class=""nav nav-pills nav-stacked"">");

                foreach (CourseScheduleDAO courseSchedule in courseListViewModel.CourseSchedules.Where(c => c.Schedule.StartTime == times.Key.StartTime && c.Schedule.EndTime == times.Key.EndTime))
                {
                    TagBuilder linksLi = new TagBuilder("li");
                    linksLi.MergeAttribute("role", "presentation");

                    TagBuilder a = new TagBuilder("a");
                    a.MergeAttribute("href", "/course/" + courseSchedule.Id);
                    a.InnerHtml = courseSchedule.Course.Title + " (Taught by " + courseSchedule.Professor.Name + ")";

                    linksLi.InnerHtml = a.ToString();
                    linksUl.Append(linksLi.ToString());
                }

                linksUl.Append("</ul>");

                listGroupLi.InnerHtml = @"<div>" + html.TimeFormat(times.Key.StartTime) + " - " + html.TimeFormat(times.Key.EndTime) + "</div>" + linksUl.ToString();
                builder.Append(listGroupLi.ToString());
            }

            builder.Append("</ul>");

            return MvcHtmlString.Create(builder.ToString());*/

            StringBuilder builder = new StringBuilder();
            builder.Append(@"<ul class=""nav nav-pills nav-stacked"">");

            foreach (var courseSchedule in courseListViewModel.CourseSchedules.OrderBy(c => c.Course.Title).GroupBy(c => c.Course.Id))
            {
                TagBuilder li = new TagBuilder("li");
                li.MergeAttribute("role", "presentation");

                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", "/course/" + courseSchedule.First().Course.Id);
                a.InnerHtml = courseSchedule.First().Course.Title;

                if (courseListViewModel.CurrentCourseId == courseSchedule.First().Course.Id)
                {
                    li.AddCssClass("active");
                }

                li.InnerHtml = a.ToString();
                builder.Append(li.ToString());
            }

            builder.Append("</ul>");

            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString LinkItem(this HtmlHelper html, string currentAction, string expectedAction, string href, string text)
        {
            TagBuilder li = new TagBuilder("li");
            
            if (currentAction == expectedAction)
            {
                li.AddCssClass("active");
            }

            TagBuilder a = new TagBuilder("a");
            a.MergeAttribute("href", href);
            a.InnerHtml = text;

            li.InnerHtml = a.ToString();

            return MvcHtmlString.Create(li.ToString());
        }
    }
}