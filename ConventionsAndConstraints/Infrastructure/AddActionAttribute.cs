using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace ConventionsAndConstraints.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AddActionAttribute : Attribute, IActionModelConvention
    {
        private readonly string _name;

        public AddActionAttribute(string name)
        {
            _name = name;
        }

        public void Apply(ActionModel action)
        {
            action.Controller.Actions.Add(new ActionModel(action) {ActionName = _name});
        }
    }
}
