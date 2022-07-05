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
    public class GroupService
    {
        private AddGroup addGroup=new AddGroup();
        private ListGroups listGroups = new ListGroups();
        private RecoverDataGroups recoverDatesGroups = new RecoverDataGroups();
        private UpdateGroup updateGroups = new UpdateGroup();
        private DeleteGroup deleteGroups = new DeleteGroup();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Group group = new Group();
                group.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "grupo"); ;
                return addGroup.add(group);
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
                var groups = new List<Group>();
                groups.Add(recoverDatesGroups.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(groups);
            }
            return jsonRecoerDtes;
        }
        public string jsonGroups()
        {
            List<Group> groups = listGroups.listarGrups();
            return Converter.ToJson(groups);
        }
        public bool updateGroup(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Group group = new Group();
                group.idGrupo = Convert.ToInt32(strId);
                group.nombre = RetrieveAtributesValues.retrieveAtributesValues(submit, "grupo");
                return updateGroups.update(group);
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
        public bool deleteG(string strIds)
        {
            return deleteGroups.delete(strIds);
        }
    }
}
