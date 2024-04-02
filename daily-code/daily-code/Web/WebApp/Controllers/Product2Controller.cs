using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class Product2Controller : Controller
    {
        #region 自定义验证

        public JsonResult IsProductNameExist(string ProductName)
        {
            return Json(!db.Product2s.Any(x => x.ProductName == ProductName), JsonRequestBehavior.AllowGet);
        }

        #endregion 自定义验证

        #region 自动生成

        private ProductDbContext db = new ProductDbContext();

        // GET: Product2
        public ActionResult Index()
        {
            return View(db.Product2s.ToList());
        }

        // GET: Product2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product2 product2 = db.Product2s.Find(id);
            if (product2 == null)
            {
                return HttpNotFound();
            }
            return View(product2);
        }

        // GET: Product2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product2/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,ProductQuantity,UnitPrice")] Product2 product2)
        {
            if (ModelState.IsValid)
            {
                db.Product2s.Add(product2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product2);
        }

        // GET: Product2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product2 product2 = db.Product2s.Find(id);
            if (product2 == null)
            {
                return HttpNotFound();
            }
            return View(product2);
        }

        // POST: Product2/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,ProductQuantity,UnitPrice")] Product2 product2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product2);
        }

        // GET: Product2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product2 product2 = db.Product2s.Find(id);
            if (product2 == null)
            {
                return HttpNotFound();
            }
            return View(product2);
        }

        // POST: Product2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product2 product2 = db.Product2s.Find(id);
            db.Product2s.Remove(product2);
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
