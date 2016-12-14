﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_DAL.Manejadoras;
using WPFSample_Ent;

namespace WPFSample_BL.Manejadoras
{
   public class clsManejadoraPersonaBL
    {
        public int insertPersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL miManejadora = new clsManejadoraPersonaDAL();
            return miManejadora.insertarPersonaDAL(persona);
        }

        public int deletePersonaBL(int id)
        {
            clsManejadoraPersonaDAL miManejadora = new clsManejadoraPersonaDAL();
            return miManejadora.deletepersonaDAL(id);
        }

        public int updatePersonaBL(clsPersona persona)
        {
            clsManejadoraPersonaDAL miManejadora = new clsManejadoraPersonaDAL();
            return miManejadora.updatePersonaDAL(persona);
        }

        public clsPersona selectPersonaBL(int id)
        {
            clsManejadoraPersonaDAL miManejadora = new clsManejadoraPersonaDAL();
            return miManejadora.selectPersonaDAL(id);
        }

    }
}
