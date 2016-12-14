using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_Ent;
using WPFSample_DAL;


namespace WPFSample_BL.Listados
{
    public class clsListadoPersonaBL
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> ListadoPersonasBL()
        {
            List<clsPersona> resultado;
            clsListadosPersonaDAL listado = new clsListadosPersonaDAL();
            resultado = listado.getListadoPersonasDAL();
            return resultado;
        } //Fin List

    }
}
