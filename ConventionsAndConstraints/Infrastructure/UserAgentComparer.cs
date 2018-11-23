using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ConventionsAndConstraints.Infrastructure
{
    public class UserAgentComparer
    {
        public bool ContainsString(HttpRequest request, string agent)
        {
            var searchTeerm = agent.ToLower();
            return request.Headers["User-Agent"].Any(h => h.ToLower().Contains(searchTeerm));
        }
    }
}
