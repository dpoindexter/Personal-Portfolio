using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Controllers
{
    public class WorkController : Controller
    {
        //
        // GET: /Work/

        public ActionResult Index(int? id)
        {
            var projects = new mongo().GetCollection<Project>();
            return View(projects);
        }

        public ActionResult Project(int id)
        {
            var project = new mongo().FindOne<Project>(p => p.Id == id);
            return View(project);
        }
    }
}
