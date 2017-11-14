using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinanzasCF.Helpers
{
    public static class HelpersMain
    {        
        public enum TIPOFLUJO {Ingreso,Egreso};
        public enum ROL { Admin, Usuario};
        public enum MESES { Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Setiembre, Octubre, Noviembre, Diciembre};
        public enum TIPOFLUJOABR { ING,EGR};
        public const String FIRSTOPTION = "TODOS";
        public const String FIRSTOPTIONNONE = "NINGUN";
        
    }
}