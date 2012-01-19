using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;
using Norm;
using Norm.BSON.DbTypes;
using Portfolio.Data;

namespace Portfolio.Controllers
{   
    [Authorize]
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ViewResult Index()
        {
            var projects = new mongo().GetCollection<Project>();
            return View(projects);
        }

        //
        // GET: /Projects/Details/5

        public ViewResult Details(int id)
        {
            Project project = new mongo().FindOne<Project>(p => p.Id == id);
            return View(project);
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                new mongo().SaveItem<Project>(project);
                return RedirectToAction("Index");  
            }

            return View(project);
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            Project project = new mongo().FindOne<Project>(p => p.Id == id);
            return View(project);
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (ModelState.IsValid && project.Id.HasValue)
            {
                new mongo().SaveItem<Project>(project);
                return RedirectToAction("Index");
            }
            return View(project);
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project project = new mongo().FindOne<Project>(p => p.Id == id);
            return View(project);
        }

        //
        // POST: /Projects/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = new mongo().FindOne<Project>(p => p.Id == id);
            new mongo().Delete<Project>(new { Id = project.Id });
            return RedirectToAction("Index");
        }
    }
}