using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinanzasCF.Models;
using FinanzasCF.Helpers;
namespace FinanzasCF.ViewModel.Flujo
{
    public class ResultadosViewModel
    {
        public Int32? Anio { get; set; }
        public List<Decimal> listFlujosIngreso { get; set; }
        public List<Decimal> listFlujosEgreso { get; set; }
        public List<Decimal> listFlujosResult { get; set; }

        public void CargarDatos(FlujoDBEntities context, HttpSessionStateBase session)
        {
            int idUsuario = session.GetIDUsuario(0);
            listFlujosIngreso = new List<Decimal>();
            listFlujosEgreso = new List<Decimal>();
            listFlujosResult = new List<Decimal>();
            if (!Anio.HasValue)
            {
                Anio = DateTime.Now.Date.Year;
            }  
            for(int i=1;i<=12;++i)
            {
                listFlujosIngreso.Add((context.Flujo.Where(x => x.FlujoFecha.Year == Anio.Value
                    && x.FlujoFecha.Month == i 
                    && x.Persona.IDUsuario == idUsuario 
                    && x.Monto > 0).Select(x=>x.Monto).Sum() ?? 0).Round());

                listFlujosEgreso.Add((context.Flujo.Where(x => x.FlujoFecha.Year == Anio.Value
                    && x.FlujoFecha.Month == i
                    && x.Persona.IDUsuario == idUsuario
                    && x.Monto < 0).Select(x => x.Monto).Sum() ?? 0).Round());
                listFlujosResult.Add(listFlujosIngreso[i-1] + listFlujosEgreso[i-1]);
            }          
        }
    }
}