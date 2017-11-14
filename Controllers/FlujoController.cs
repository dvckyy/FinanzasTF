using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanzasCF.ViewModel.Flujo;
using FinanzasCF.Helpers;

namespace FinanzasCF.Controllers
{
    public class FlujoController : BaseController
    {
        // GET: Flujo
        public ActionResult Listado()
        {
            Session["IDUsuario"] = 1;
            ListViewModel viewModel = new ListViewModel();
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Listado(Int32? Anio, Int32? Mes)
        {
            ListViewModel viewModel = new ListViewModel();
            viewModel.Anio = Anio;
            viewModel.Mes = Mes;
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session);
            return View(viewModel);
        }

        public ActionResult AddEdit(Int32? IDFlujo)
        {
            AddEditViewModel viewModel = new AddEditViewModel();
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session, IDFlujo);
            return View(viewModel);
        }

        public ActionResult Resultados()
        {
            ResultadosViewModel viewModel = new ResultadosViewModel();
            Session["IDUsuario"] = 1;
            var session = Request.RequestContext.HttpContext.Session;
            viewModel.CargarDatos(context, session);            
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Resultados(Int32? Anio)
        {
            ResultadosViewModel viewModel = new ResultadosViewModel();
            Session["IDUsuario"] = 1;
            var session = Request.RequestContext.HttpContext.Session;

            viewModel.Anio = Anio.Value;
            viewModel.CargarDatos(context, session);
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
                viewModel.CargarDatos(context,session, viewModel.IDFlujo);
                TryUpdateModel(viewModel);
                return View(viewModel);
            }            
        }
    }
}