using PlutoWeb.Persistence;
using PlutoWeb.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlutoWeb.Core;

namespace PlutoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly PlutoContext _context;
        //public HomeController()
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_context = new PlutoContext();
        }

        public ActionResult Index()
        {
            //var courses = _context.Courses.ToList();
            var courses = _unitOfWork.Courses.GetAll();
            
            return View(courses);
        }

        [HttpPost]
        public ActionResult AddCourse()
        {
            //_context.Courses.Add(new Course
            _unitOfWork.Courses.Add(new Course
            {
                Name = "New Course at " + DateTime.Now.ToShortDateString(),
                Description = "Description",
                AuthorId = 1,
                FullPrice = 49,
                Level = 1
            });
            //_context.SaveChanges();
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();

        //    base.Dispose(disposing);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}