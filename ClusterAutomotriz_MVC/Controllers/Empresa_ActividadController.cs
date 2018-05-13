using ClusterAutomotriz_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClusterAutomotriz_MVC.Controllers
{
    public class Empresa_ActividadController : Controller
    {
        // GET: Empresa_Actividad
        public ActionResult Index()
        {
            var empresas = Empresa_ActividadRepository.GetEmpresas();
            return View(empresas);
        }

        // GET: Empresa_Actividad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa_Actividad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa_Actividad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa_Actividad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empresa_Actividad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa_Actividad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresa_Actividad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
