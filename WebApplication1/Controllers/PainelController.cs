﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PainelController : Controller
    {
        // GET: Painel

        [Authorize]
        public ActionResult Index(){
            return View();
        }
    }
}