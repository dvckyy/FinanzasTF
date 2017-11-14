using FinanzasCF.Models;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanzasCF.Helpers;
using static FinanzasCF.Helpers.HelpersMain;

namespace FinanzasCF.ViewModel.Flujo
{
    public class AddEditViewModel
    {        
        public Int32? IDFlujo { get; set; }
        public Int32? IDPersona { get; set; }
        public Int32? IDCategoria { get; set; }
        public Decimal? Monto { get; set; }
        public String Descripcion{ get; set; }
        public DateTime FlujoFecha { get; set; }
        public List<Models.Persona> listPersonas { get; set; }
        public List<Models.Categoria> listCategoriaEgreso { get; set; }
        public List<Models.Categoria> listCategoriaIngreso { get; set; }


        public void CargarDatos(FlujoDBEntities context,HttpSessionStateBase session, Int32? idFlujo)
        {
            IDFlujo = idFlujo;
            int idUsuario = session.GetIDUsuario(0);
            var flujo = context.Flujo.Find(IDFlujo);
            if (flujo != null)
            {
                IDPersona = flujo.IDPersona;
                IDCategoria = flujo.IDCategoria;
                Monto = flujo.Monto;
                Descripcion = flujo.Descripcion;
                FlujoFecha = flujo.FlujoFecha;
            }
            else
            {
                FlujoFecha = DateTime.Now.Date;
            }
            listPersonas = context.Persona.Where(x => x.IDUsuario == idUsuario).ToList();
            listCategoriaEgreso = context.Categoria.Where(x => x.Tipo == TIPOFLUJOABR.EGR.ToString()).ToList();
            listCategoriaIngreso = context.Categoria.Where(x => x.Tipo == TIPOFLUJOABR.ING.ToString()).ToList();
        }    
        
        public bool AddEdit(FlujoDBEntities context, HttpSessionStateBase session)
        {
            bool flag = false;
            try { 
                using (var transactionScope = new TransactionScope())
                {
                    int idUsuario = session.GetIDUsuario(0);
                    Models.Flujo flujo = new Models.Flujo();
                    if (IDFlujo != 0)
                    {
                        flujo = context.Flujo.Find(IDFlujo);
                    }                    
                    flujo.IDPersona = IDPersona;
                    flujo.IDCategoria = IDCategoria;
                    flujo.Monto = Monto;
                    flujo.Descripcion = Descripcion;
                    flujo.FlujoFecha = FlujoFecha;
                    if (IDFlujo == 0)
                    {
                        context.Flujo.Add(flujo);
                    }                  
                    context.SaveChanges();                    
                    transactionScope.Complete();
                    flag = true;
                }
                return flag;
            }
            catch (Exception e)
            {
                return flag;
            }
        }   
    }
}