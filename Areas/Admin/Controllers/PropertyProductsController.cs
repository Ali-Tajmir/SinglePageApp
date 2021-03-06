using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SinglePageApp;
using SinglePageApp.Repository;

namespace SinglePageApp.Areas.Admin.Controllers
{
    [Authorize]
    public class PropertyProductsController : Controller
    {
        private DbSinglePageContext db = new DbSinglePageContext();
        PropertyProductRepository PropertyProductRepository;
        ProductRepository productRepository;
        public PropertyProductsController()
        {
            PropertyProductRepository = new PropertyProductRepository(db);
            productRepository = new ProductRepository(db);
        }

        // GET: Admin/PropertyProducts
        public ActionResult Index(int id)
        {
            var product = productRepository.GetById(id);
            ViewBag.ProductId = id;
            return View(product.PropertyProduct);
        }

        // GET: Admin/PropertyProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyProduct propertyProduct = db.PropertyProducts.Find(id);
            if (propertyProduct == null)
            {
                return HttpNotFound();
            }
            return View(propertyProduct);
        }

        // GET: Admin/PropertyProducts/Create
        [HttpGet]
        public ActionResult Create(int id)
        {
            PropertyProduct propertyProduct = new PropertyProduct()
            { 
                ProductId = id
            };
            return PartialView(propertyProduct);
        }

        // POST: Admin/PropertyProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProductId,Name")] PropertyProduct propertyProduct)
        {
            if (ModelState.IsValid)
            {
                db.PropertyProducts.Add(propertyProduct);
                db.SaveChanges();
                return RedirectToAction("Index",new {id=propertyProduct.ProductId });
            }

           
            return View(propertyProduct);
        }

        // GET: Admin/PropertyProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyProduct propertyProduct = PropertyProductRepository.GetById(id.Value);
            if (propertyProduct == null)
            {
                return HttpNotFound();
            }
            return PartialView(propertyProduct);
        }

        // POST: Admin/PropertyProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ProductId,Name")] PropertyProduct propertyProduct)
        {
            if (ModelState.IsValid)
            {
                PropertyProductRepository.update(propertyProduct);
                return RedirectToAction("Index",new {id=propertyProduct.ProductId });
            }
            return View(propertyProduct);
        }

        // GET: Admin/PropertyProducts/Delete/5
        public void Delete(int? id)
        {

            PropertyProductRepository.delete(id.Value);
         
        }

        // POST: Admin/PropertyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyProduct propertyProduct = db.PropertyProducts.Find(id);
            db.PropertyProducts.Remove(propertyProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
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
