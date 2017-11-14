using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanzasCF.ViewModel.Persona;
using FinanzasCF.Helpers;

namespace FinanzasCF.Controllers
{
    public class PersonaController : BaseController
    {
        // GET: Persona
        public ActionResult Listado()
        {
            Session["IDUsuario"] = 1;
            ListViewModel viewModel = new ListViewModel();
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Listado(String filtroFamilia)
        {
            ListViewModel viewModel = new ListViewModel();
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session);
            return View(viewModel);
        }

        public ActionResult AddEdit(Int32? IDPersona)
        {
            AddEditViewModel viewModel = new AddEditViewModel();
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session, IDPersona);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddEdit(AddEditViewModel viewModel)
        {
            var session = Request.RequestContext.HttpContext.Session;
            if (viewModel.AddEdit(context,session))
            {
                return RedirectToAction("Listado");
            }
            else
            {
                //Error
                viewModel.CargarDatos(context,session, viewModel.IDPersona);
                TryUpdateModel(viewModel);
                return View(viewModel);
            }            
        }
    }
}