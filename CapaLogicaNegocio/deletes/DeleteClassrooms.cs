﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.deletes
{
    public class DeleteClassrooms
    {
        private DatosClassroom datos = new DatosClassroom();
        public bool delete(string strIds)
        {
            return datos.eliminarClassrooms(strIds);
        }
    }
}
