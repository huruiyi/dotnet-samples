using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApp.Infrastructure;
using WebApp.Models;

namespace WebApp.Controllers
{
    [LogFilter]
    public class Product1Controller : Controller
    {
        #region 自定义验证

        public JsonResult IsProductNameExist(string ProductName)
        {
            return Json(!db.Product1s.Any(x => x.ProductName == ProductName), JsonRequestBehavior.AllowGet);
        }

        #endregion 自定义验证

        #region 自动生成

        private ProductDbContext db = new ProductDbContext();

        // GET: Product1
        public ActionResult Index()
        {
            return View(db.Product1s.ToList());
        }

        // GET: Product1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1s.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // GET: Product1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product1/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,ProductQuantity,UnitPrice")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Product1s.Add(product1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product1);
        }

        // GET: Product1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1s.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Product1/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,ProductQuantity,UnitPrice")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product1);
        }

        // GET: Product1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1s.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product1 product1 = db.Product1s.Find(id);
            db.Product1s.Remove(product1);
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

        #endregion 自动生成
    }
}
