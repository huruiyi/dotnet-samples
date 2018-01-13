using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using WebApi.Models;

namespace WebApi.Controllers
{
    //[Authorize]
    public class CommentsController : ApiController
    {
        private ICommentRepository repository;

        public CommentsController(ICommentRepository repository)
        {
            this.repository = repository;
        }

        #region GET

        [EnableQuery]
        public IQueryable<Comment> GetComments()
        {
            return repository.Get().AsQueryable();
        }

        public Comment GetComment(int id)
        {
            Comment comment;
            if (!repository.TryGet(id, out comment))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            return comment;
        }

        #endregion GET

        #region POST

        public HttpResponseMessage PostComment(Comment comment)
        {
            comment = repository.Add(comment);
            var response = Request.CreateResponse<Comment>(HttpStatusCode.Created, comment);
            response.Headers.Location = new Uri(Request.RequestUri, "/api/comments/" + comment.ID);
            return response;
        }

        #endregion POST

        #region DELETE

        public Comment DeleteComment(int id)
        {
            Comment comment;
            if (!repository.TryGet(id, out comment))
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            repository.Delete(id);
            return comment;
        }

        #endregion DELETE

        #region Paging GET

        public IEnumerable<Comment> GetComments(int pageIndex, int pageSize)
        {
            return repository.Get().Skip(pageIndex * pageSize).Take(pageSize);
        }

        #endregion Paging GET
    }
}