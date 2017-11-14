using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanzasCF.Models;

namespace FinanzasCF.Controllers
{
    public class BaseController : Controller
    {
        public FlujoDBEntities context = new FlujoDBEntities();
    }
}