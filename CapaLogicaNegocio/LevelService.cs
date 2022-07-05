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
    public class LevelService
    {
        private AddLevel addL = new AddLevel();
        private ListLevel listL = new ListLevel();
        private RecoverDataLevel recoverDatesL = new RecoverDataLevel();
        private UpdateLevel updateL = new UpdateLevel();
        private DeleteLevel deleteL = new DeleteLevel();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Level level = new Level();
                level.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "cuatrimestre"); ;
                return addL.add(level);
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
                var levels = new List<Level>();
                levels.Add(recoverDatesL.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(levels);
            }
            return jsonRecoerDtes;
        }
        public string jsonLevels()
        {
            List<Level> levels = listL.listar();
            return Converter.ToJson(levels);
        }
        public bool updateLevel(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Level level = new Level();
                level.idCuatrimestre = Convert.ToInt32(strId);
                level.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "cuatrimestre");
                return updateL.update(level);
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
        public bool deleteLev(string strIds)
        {
            return deleteL.delete(strIds);
        }
    }
}
