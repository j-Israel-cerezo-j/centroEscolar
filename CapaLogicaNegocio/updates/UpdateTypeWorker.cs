﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidades;
namespace CapaLogicaNegocio.updates
{
    public class UpdateTypeWorker
    {
        private DatosTypeWorker datos = new DatosTypeWorker();
        public bool update(TypeWorker typeWorker)
        {
            return datos.updateTypeWorker(typeWorker);
        }
    }
}
