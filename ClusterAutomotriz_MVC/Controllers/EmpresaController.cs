using ClusterAutomotriz_DataAccess;
using ClusterAutomotriz_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClusterAutomotriz_MVC.Controllers
{
    public class EmpresaController : Controller
    {



        // GET: Empresa
        public ActionResult Index()
        {
            EmpresaRepository empresa = new EmpresaRepository();
            var empresas = EmpresaRepository.GetEmpresas();
            return View(empresas);
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {

            var empresa = EmpresaRepository.GetEmpresa(id);
            return View(empresa);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View(new Empresa());
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult Create(Empresa empresa)
        {
           
            try
            {
                bool success = EmpresaRepository.InsertEmpresa(empresa);
                if (success)
                    return RedirectToAction("Index");
                else
                {
                    return View();
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
       
            // GET: Empresa/Edit/5
            public ActionResult Edit(int id)
            {

            var empresa = EmpresaRepository.GetEmpresa(id);
            return View(empresa);

            }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empresa empresa)
        {
            try
            {
                // TODO: Add update logic here
                bool success = EmpresaRepository.UpdateEmpresa(empresa);

                if (success)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }

        // GET: Empresa/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            var empresa = EmpresaRepository.GetEmpresa(id);
            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bool success = EmpresaRepository.DeleteEmpresa(id);
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
