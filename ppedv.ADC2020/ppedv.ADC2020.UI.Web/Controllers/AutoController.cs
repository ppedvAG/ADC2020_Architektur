using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.ADC2020.Logic;
using ppedv.ADC2020.Model;

namespace ppedv.ADC2020.UI.Web.Controllers
{
    public class AutoController : Controller
    {
        Core core = new Core();
        // GET: Auto
        public ActionResult Index()
        {
            return View(core.Repository.Query<Auto>().ToList());
        }

        // GET: Auto/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Auto>(id));
        }

        // GET: Auto/Create
        public ActionResult Create()
        {
            return View(new Auto() { Farbe = "rosa" });
        }

        // POST: Auto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auto auto)
        {
            try
            {
                core.Repository.Add(auto);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auto/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetById<Auto>(id));
        }

        // POST: Auto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auto auto)
        {
            try
            {
                core.Repository.Update(auto);
                core.Repository.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Auto/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Auto>(id));
        }

        // POST: Auto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auto auto)
        {
            try
            {
                var loaded = core.Repository.GetById<Auto>(auto.Id);
                if (loaded != null)
                {
                    core.Repository.Delete(loaded);
                    core.Repository.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}