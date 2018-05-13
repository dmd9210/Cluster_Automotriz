using ClusterAutomotriz_DataAccess;
using ClusterAutomotriz_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace ClusterAutomotriz_MVC.Controllers
{
    public class ActividadController : Controller
    {
        // GET: Actividad
        public ActionResult Index()
        {
            ActividadRepository actividad = new ActividadRepository();
            var actividades = ActividadRepository.GetActividades();
            return View(actividades);
        }

        // GET: Actividad/Details/5
        public ActionResult Details(int id)
        {
            var actividad = ActividadRepository.GetActividad(id);
            return View(actividad);
        }

        // GET: Actividad/Create
        public ActionResult Create()
        {
            Actividad actividad = new Actividad();

            return View();
        }

        // POST: Actividad/Create
        [HttpPost]
        public ActionResult Create(Actividad actividad)
        {
            try
            {
                bool success = ActividadRepository.InsertActividad(actividad);
                if (success)
                    return RedirectToAction("Index");
                else
                {
                    return View();
                }

            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Actividad/Edit/5
        public ActionResult Edit(int id)
        {
            var actividad = ActividadRepository.GetActividad(id);
            return View(actividad);
        }

        // POST: Actividad/Edit/5
        [HttpPost]
        public ActionResult Edit(Actividad actividad, FormCollection collection)
        {
            try
            {                
                bool success = ActividadRepository.UpdateActividad(actividad);

                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Actividad/Delete/5
        public ActionResult Delete(int? id)
        {
           var actividad = ActividadRepository.GetActividad(id);
           return View(actividad);
        }

        // POST: Actividad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bool success = ActividadRepository.DeleteActividad(id);
                if (success)

                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
    }
}
