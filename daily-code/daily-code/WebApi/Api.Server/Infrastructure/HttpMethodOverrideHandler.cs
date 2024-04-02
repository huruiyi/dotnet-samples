using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Server.Infrastructure
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