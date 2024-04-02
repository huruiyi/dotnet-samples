using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace SelfHostAPI
{
    public class ProductsController : ApiController
    {
        private readonly ExampleDbEntities _dbEntities = new ExampleDbEntities();

        public ProductsController()
        {
            List<Product> products = _dbEntities.Products.ToList();
            if (!products.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    _dbEntities.Products.Add(new Product { ProductId = i, ProductName = "Pn" + i });
                }
                _dbEntities.SaveChanges();
            }
        }

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return _dbEntities.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = _dbEntities.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _dbEntities.Entry(product).State = EntityState.Modified;

            try
            {
                _dbEntities.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbEntities.Products.Add(product);
            _dbEntities.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = _dbEntities.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _dbEntities.Products.Remove(product);
            _dbEntities.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbEntities.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return _dbEntities.Products.Count(e => e.ProductId == id) > 0;
        }
    }
}