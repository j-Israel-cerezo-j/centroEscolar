﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.recoverDates
{
    public class RecoverDataDivision
    {
        private DatosDivisions datos = new DatosDivisions();

        public Division recoverData(int id)
        {
            return datos.recoverData(id);
        }
    }
}
