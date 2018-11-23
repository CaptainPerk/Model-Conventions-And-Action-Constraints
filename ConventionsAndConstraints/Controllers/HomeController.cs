﻿using ConventionsAndConstraints.Infrastructure;
using ConventionsAndConstraints.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConventionsAndConstraints.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("Result", new Result {Controller = nameof(HomeController), Action = nameof(Index)});

        [ActionName("Index")]
        public IActionResult Other() => View("Result", new Result { Controller = nameof(HomeController), Action = nameof(Other) });

        [AddAction("Details")]
        public IActionResult List() => View("Result", new Result {Controller = nameof(HomeController), Action = nameof(List)});
    }
}
