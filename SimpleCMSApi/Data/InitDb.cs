using SimpleCMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCMSApi.Data
{
    public class InitDb
    {
        public static void Init(SimpleCmsApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pages.Any())
            {
                return;
            }

            var pages = new Page[]
            {
                new Page { Title = "Home", Slug = "home", Content = "Home Content", HasSidebar = "No"},
                new Page { Title = "About", Slug = "about", Content = "About Content", HasSidebar = "No" },
                new Page { Title = "Services", Slug = "services", Content = "Services Content", HasSidebar = "No" },
                new Page { Title = "Contact", Slug = "contact", Content = "Contact Content", HasSidebar = "No" }
            };

            foreach (Page page in pages)
            {
                context.Pages.Add(page);
            }
            context.SaveChanges();

            var sidebar = new Sidebar
            {
                Content = "sidebar contend"
            };

            context.Sidebar.Add(sidebar);
            context.SaveChanges();

            var user = new User
            {
                Username = "admin",
                Password = "pass",
                IsAdmin = "yes"
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}

