﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAssignment.Controllers
{
    public class TimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
