using Microsoft.AspNetCore.Mvc;
using SimpleCMSApi.Data;
using SimpleCMSApi.Models;
using System.Linq;

namespace SimpleCMSApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Sidebar")]
    public class SidebarController : Controller
    {
        private readonly SimpleCmsApiContext _context;

        public SidebarController(SimpleCmsApiContext context)
        {
            _context = context;
        }

        //GET api/sidebar
        public IActionResult Get()
        {
            Sidebar sidebar = _context.Sidebar.FirstOrDefault();
            return Json(sidebar);
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

        // PUT api/sidebar/edit
        [HttpPut("edit")]
        public IActionResult Edit([FromBody] Sidebar sidebar)
        {
            _context.Update(sidebar);
            _context.SaveChanges();

            return Json("ok");
        }
    }
}