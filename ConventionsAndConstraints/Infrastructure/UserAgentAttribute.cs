using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConventionsAndConstraints.Infrastructure
{
    public class UserAgentAttribute : Attribute, IActionConstraintFactory
    {
        private readonly string _subString;

        public UserAgentAttribute(string subString)
        {
            _subString = subString.ToLower();
        }

        public bool IsReusable => false;

        public IActionConstraint CreateInstance(IServiceProvider services)
        {
            return new UserAgentConstraint(services.GetService<UserAgentComparer>(), _subString);
        }
    }

    public class UserAgentConstraint : IActionConstraint
    {
        private readonly UserAgentComparer _comparer;
        private readonly string _subString;

        public UserAgentConstraint(UserAgentComparer comparer, string subString)
        {
            _comparer = comparer;
            _subString = subString.ToLower();
        }

        public int Order { get; set; } = 0;

        public bool Accept(ActionConstraintContext context)
        {
            return _comparer.ContainsString(context.RouteContext.HttpContext.Request, _subString) || context.Candidates.Count == 1;
        }
    }
}
