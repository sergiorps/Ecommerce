﻿using ECommerce.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class DepartamentsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Departaments
        public ActionResult Index()
        {
            return View(db.Departaments.ToList());
        }

        // GET: Departaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // GET: Departaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departaments/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentsId,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                db.Departaments.Add(departaments);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {   //Abaixo estou verificando se já existe o Departamento em questão!
                    if (ex.InnerException != null &&
                            ex.InnerException.InnerException != null &&
                                    ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Esse Departamento já existe!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    return View(departaments);
                }
            }

            return View(departaments);
        }

        // GET: Departaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentsId,Name")] Departaments departaments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departaments).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {

                    if (ex.InnerException != null &&
                            ex.InnerException.InnerException != null &&
                                    ex.InnerException.InnerException.Message.Contains("_Index"))
                    {
                        ModelState.AddModelError(string.Empty, "Esse Departamento já existe!");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    return View(departaments);
                }
            }
            return View(departaments);
        }

        // GET: Departaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departaments departaments = db.Departaments.Find(id);
            if (departaments == null)
            {
                return HttpNotFound();
            }
            return View(departaments);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departaments departaments = db.Departaments.Find(id);
            db.Departaments.Remove(departaments);
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {   //Abaixo estou verificando se tenho uma informação nula na aplicação e no banco de dados e depois
                //se realmente estou tratando a questão do delete em cascata.
                if(ex.InnerException != null && 
                        ex.InnerException.InnerException != null &&
                                ex.InnerException.InnerException.Message.Contains("REFERENCE")){
                    ModelState.AddModelError(string.Empty, "Não é possivel remover o Departamento porque existem cidades relacionadas a eles. Primeiro remova as cidades e volte a excluir!");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(departaments);

            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
