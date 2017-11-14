using FinanzasCF.Models;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinanzasCF.Helpers;

namespace FinanzasCF.ViewModel.Persona
{
    public class AddEditViewModel
    {
        public Int32? IDPersona { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public Int32? IDUsuario { get; set; }
        
        public void CargarDatos(FlujoDBEntities context,HttpSessionStateBase session , Int32? idPersona)
        {
            IDPersona = idPersona;
            var persona = context.Persona.Find(IDPersona);
            if (persona != null)
            {
                Nombre = persona.Nombre;
                Apellido = persona.Apellido;
            }
        }    
        
        public bool AddEdit(FlujoDBEntities context, HttpSessionStateBase session)
        {
            bool flag = false;
            try { 
                using (var transactionScope = new TransactionScope())
                {
                    int idUsuario = session.GetIDUsuario(0);
                    Models.Persona persona = new Models.Persona();
                    if (IDPersona != 0)
                    {
                        persona = context.Persona.FirstOrDefault(x => x.IDPersona == IDPersona);
                    }
                    persona.Nombre = Nombre;
                    persona.Apellido = Apellido;
                    persona.IDUsuario = idUsuario;
                    if (IDPersona == 0)
                    {
                        context.Persona.Add(persona);
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