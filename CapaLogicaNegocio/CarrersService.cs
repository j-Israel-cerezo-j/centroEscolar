using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.Adds;
using Entidades;
using CapaLogicaNegocio.retrieveAtributesValues;
using CapaLogicaNegocio.Lists;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.recoverDates;
using CapaLogicaNegocio.deletes;
using CapaLogicaNegocio.updates;
using Validaciones.util;
using CapaLogicaNegocio.Exceptions;
namespace CapaLogicaNegocio
{
    public class CarrersService
    {
        private AddCarrer addC = new AddCarrer();
        private ListCarrers listC = new ListCarrers();
        private RecoverDataCarrer recoverDatesC = new RecoverDataCarrer();
        private UpdateCarrer updateC = new UpdateCarrer();
        private DeleteCarrer deleteC = new DeleteCarrer();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Carrer carrer = new Carrer();
                carrer.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "carrera"); ;
                return addC.add(carrer);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public string jsonRecoverData(string strId)
        {
            string jsonRecoerDtes = "";
            if (strId != "")
            {
                var carres = new List<Carrer>();
                carres.Add(recoverDatesC.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(carres);
            }
            return jsonRecoerDtes;
        }
        public string jsonCarrers()
        {
            List<Carrer> carrers = listC.listarCarres();
            return Converter.ToJson(carrers);
        }
        public bool updateCarrer(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Carrer carrer = new Carrer();
                carrer.idCarrera = Convert.ToInt32(strId);
                carrer.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "carrera");
                return updateC.update(carrer);
            }
            else
            {
                foreach (var item in camposEmptysOrNull)
                {
                    if (item.Value)
                    {
                        throw new ServiceException(item.Key + " esta vacío");
                    }
                }
            }
            return ban;
        }
        public bool deleteCarrers(string strIds)
        {
            return deleteC.delete(strIds);
        }
    }
}
