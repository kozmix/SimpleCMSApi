using Microsoft.AspNetCore.Mvc;
using SimpleCMSApi.Data;
using SimpleCMSApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCMSApi.Controllers
{
    [Route("api/[controller]")]
    public class PagesController : Controller
    {
        private readonly SimpleCmsApiContext _context;

        public PagesController(SimpleCmsApiContext context)
        {
            _context = context;
        }

        //GET api/pages
        public IActionResult Get()
        {
            List<Page> pages = _context.Pages.ToList();
            return Json(pages);
        }

        //GET api/pages/slug
        [HttpGet("{slug}")]
        public IActionResult Get(string slug)
        {
            Page page = _context.Pages.SingleOrDefault(x => x.Slug == slug);
            if (page == null)
            {
                return Json("PageNotFound");
            }

            return Json(page);
        }

        // POST api/pages/create
        [HttpPost("{create}")]
        public IActionResult Create([FromBody] Page page)
        {
            page.Slug = page.Title.Replace(" ", "-").ToLower();
            page.HasSidebar = page.HasSidebar ?? "no";

            var slug = _context.Pages.FirstOrDefault(x => x.Slug == page.Slug);
            if (slug != null)
            {
                return Json("pageExists");
            }
            else
            {
                _context.Pages.Add(page);
                _context.SaveChanges();

                return Json("ok");
            }
        }

        //GET api/pages/edit/id
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            Page page = _context.Pages.SingleOrDefault(x => x.ID == id);
            if (page == null)
            {
                return Json("PageNotFound");
            }

            return Json(page);
        }

        // PUT api/pages/edit/id
        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Page page)
        {
            page.Slug = page.Title.Replace(" ", "-").ToLower();
            page.HasSidebar = page.HasSidebar ?? "no";

            var pg = _context.Pages.FirstOrDefault(x => x.ID != id && x.Slug == page.Slug);
            if (pg != null)
            {
                return Json("pageExists");
            }
            else
            {
                _context.Update(page);
                _context.SaveChanges();

                return Json("ok");
            }
        }

        // PUT api/pages/delete/id
        [HttpDelete("delete/{id}")]
        public IActionResult Dlete(int id)
        {
            Page page = _context.Pages.SingleOrDefault(x => x.ID == id);
            _context.Remove(page);
            _context.SaveChanges();

            return Json("ok");
        }
    }
}