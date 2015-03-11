using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_GenericRepositoryPattern2.Models;

namespace MVC_GenericRepositoryPattern2.Controllers
{
    public class DefaultController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ViewResult Index()
        {
            var users = unitOfWork.UserRepository.Get();

            return View(users.ToList());
        }


        public ViewResult Details(int id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.Insert(user);

                unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(user);
        }


        public ActionResult Delete(int id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = unitOfWork.UserRepository.GetByID(id);
            unitOfWork.UserRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}

    }
}
