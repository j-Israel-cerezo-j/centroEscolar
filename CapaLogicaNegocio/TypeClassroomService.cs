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
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Onkeyups;
namespace CapaLogicaNegocio
{
    public class TypeClassroomService
    {
        private AddTypeClassroom addTC = new AddTypeClassroom();
        private ListTypeClassroom listTC = new ListTypeClassroom();
        private RecoverDataTypeClassroom recoverDatesTC = new RecoverDataTypeClassroom();
        private UpdateTypeClassroom updateTC = new UpdateTypeClassroom();
        private DeleteTypeClassrooms deleteTC = new DeleteTypeClassrooms();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                TypeClassroom typeClassroom = new TypeClassroom();
                typeClassroom.nombre = RetrieveAtributes.values(submit, "typeClassroom"); ;
                return addTC.add(typeClassroom);
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
                var typeClassrooms = new List<TypeClassroom>();
                typeClassrooms.Add(recoverDatesTC.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(typeClassrooms);
            }
            return jsonRecoerDtes;
        }
        public string jsonTypeClassrooms()
        {
            List<TypeClassroom> typeClassroom = listTC.listarTypeClassroom();
            return Converter.ToJson(typeClassroom);
        }
        public bool updateTypeClassroom(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                TypeClassroom typeClassroom = new TypeClassroom();
                typeClassroom.id = Convert.ToInt32(strId);
                typeClassroom.nombre = RetrieveAtributes.values(submit, "typeClassroom");
                return updateTC.update(typeClassroom);
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
        public bool deleteTypeClassroom(string strIds)
        {
            return deleteTC.delete(strIds);
        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("id", caracteres);
            fields.Add("nombre", caracteres);

            var table = Onkeyup.onkeyubSearchhTable(fields, "tipoSalon");
            return Converter.ToJson(table, "id");

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("nombre", caracteres);

            var table = Onkeyup.onkeyubSearchh(fields, "tipoSalon");
            return Converter.ToList(table);

        }
    }
}
