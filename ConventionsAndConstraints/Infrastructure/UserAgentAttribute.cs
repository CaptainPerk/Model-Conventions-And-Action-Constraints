using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Linq;

namespace ConventionsAndConstraints.Infrastructure
{
    public class UserAgentAttribute : Attribute, IActionConstraint
    {
        private readonly string _subString;

        public UserAgentAttribute(string subString)
        {
            _subString = subString.ToLower();
        }

        public int Order { get; set; } = 0;

        public bool Accept(ActionConstraintContext context)
        {
            return context.RouteContext.HttpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains(_subString));
        }
    }
}
