using Cars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cars.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Carros.ToList());
            }
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                // Obtén el primer elemento que coincida con el ID
                var carro = context.Carros.FirstOrDefault(x => x.Id == id);

                // Si no se encuentra, retorna un error 404
                if (carro == null)
                {
                    return HttpNotFound();
                }

                // Pasa el objeto encontrado a la vista
                return View(carro);
            }
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        [HttpPost]
        public ActionResult Create(Carros carros)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Carros.Add(carros);
                    context.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Carros.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Carro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Carros carros)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(carros).State = EntityState.Modified;
                    context.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Carros.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Carro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels context = new DbModels())
                {
                    Carros carro = context.Carros.Where(x=>x.Id == id).FirstOrDefault();
                    context.Carros.Remove(carro);
                    context.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
