﻿using RegistrationWeb.Client.Models;
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
                a.MergeAttribute("href", "/registration/student/" + student.Person.Id);
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
            StringBuilder builder = new StringBuilder();
            builder.Append(@"<ul class=""nav nav-pills nav-stacked"">");

            foreach (var course in courseListViewModel.Courses.OrderBy(c => c.Title).GroupBy(c => c.Id))
            {
                TagBuilder li = new TagBuilder("li");
                li.MergeAttribute("role", "presentation");

                TagBuilder a = new TagBuilder("a");
                a.MergeAttribute("href", "/registration/course/" + course.First().Id);
                a.InnerHtml = course.First().Title;

                if (courseListViewModel.CurrentCourseId == course.First().Id)
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