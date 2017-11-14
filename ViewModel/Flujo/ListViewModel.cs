using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinanzasCF.Models;
using FinanzasCF.Helpers;
namespace FinanzasCF.ViewModel.Flujo
{
    public class ListViewModel
    {
        public Int32? Anio { get; set; }
        public Int32? Mes { get; set; }
        public List<Models.Flujo> listFlujosIngreso { get; set; }
        public List<Models.Flujo> listFlujosEgreso { get; set; }

        public void CargarDatos(FlujoDBEntities context, HttpSessionStateBase session)
        {
            int idUsuario = session.GetIDUsuario(0);
            listFlujosEgreso = context.Flujo.Where(x => x.Persona.IDUsuario==idUsuario && x.Monto < 0).ToList();
            listFlujosIngreso = context.Flujo.Where(x => x.Persona.IDUsuario == idUsuario && x.Monto > 0).ToList();

            if (Anio.HasValue && Mes.HasValue)
            {
                listFlujosEgreso = listFlujosEgreso.Where(x => x.FlujoFecha.Year == Anio && x.FlujoFecha.Month == Mes).ToList();
                listFlujosIngreso = listFlujosIngreso.Where(x => x.FlujoFecha.Year == Anio && x.FlujoFecha.Month == Mes).ToList();
            }
        }
    }
}