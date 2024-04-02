using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Fairy.WebApi.Handler
{
    public class HttpMethodOverrideHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> methodOverrideHeader;
            if (request.Headers.TryGetValues("X-HTTP-Method-Override", out methodOverrideHeader))
            {
                request.Method = new HttpMethod(methodOverrideHeader.First());
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}