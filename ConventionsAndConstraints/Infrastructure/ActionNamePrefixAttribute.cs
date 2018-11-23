using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace ConventionsAndConstraints.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ActionNamePrefixAttribute : Attribute, IActionModelConvention
    {
        private readonly string _prefix;

        public ActionNamePrefixAttribute(string prefix)
        {
            _prefix = prefix;
        }

        public void Apply(ActionModel action)
        {
            action.ActionName = $"{_prefix}{action.ActionName}";
        }
    }
}
