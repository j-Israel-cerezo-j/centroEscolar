﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.Lists
{
    public class ListHours
    {
        private DatosHour datos = new DatosHour();

        public List<Hour> listar()
        {
            return datos.listarHours();
        }
    }
}
