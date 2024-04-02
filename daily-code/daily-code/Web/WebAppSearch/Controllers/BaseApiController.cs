using System.Web;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebAppSearch.Controllers
{
    public class BaseApiController : ApiController
    {
        public IMongoDatabase db;
        public IMongoCollection<BsonDocument> col = null;//用于直接返回查询的json

        public BaseApiController()
        {

        }

        public BaseApiController(string collectionName)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("foo");
            col = db.GetCollection<BsonDocument>("bar");
        }

        public string GetStringRequest(string paramter)
        {
            return HttpContext.Current.Request.QueryString[paramter] ?? "";
        }

        public int? GetIntRequest(string paramter)
        {
            string tmp = HttpContext.Current.Request.QueryString[paramter] ?? "";
            int tag = 0;
            if (!int.TryParse(tmp, out tag))
            {
                return null;
            }
            return tag;
        }
    }
}
