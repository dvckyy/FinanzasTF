using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinanzasCF.Models;
using FinanzasCF.Helpers;
namespace FinanzasCF.ViewModel.Persona
{
    public class ListViewModel
    {
        public List<Models.Persona> listPersonas { get; set; }
        
        public void CargarDatos(FlujoDBEntities context, HttpSessionStateBase session)
        {
            int idUsuario = session.GetIDUsuario(0);
            listPersonas = context.Persona.Where(x => x.IDUsuario == idUsuario).ToList();
        }
    }
}