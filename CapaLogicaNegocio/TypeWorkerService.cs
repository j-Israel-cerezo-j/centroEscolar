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
using CapaLogicaNegocio.validateDuplicateField;

namespace CapaLogicaNegocio
{
    public class TypeWorkerService
    {
        private AddTypeWorker addTw = new AddTypeWorker();
        private ListTypesWorkers listTW = new ListTypesWorkers();
        private RecoverDataTypeWorker recoverDatesTW = new RecoverDataTypeWorker();
        private UpdateTypeWorker updateTW = new UpdateTypeWorker();
        private DeleteTypeWorker deleteTW = new DeleteTypeWorker();
        private RecoverDataRoles recoverRol = new RecoverDataRoles();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                TypeWorker typeWorker = new TypeWorker();
                typeWorker.typeWorker = RetrieveAtributes.values(submit, "typeWorker");
                typeWorker.descripcion = RetrieveAtributes.values(submit, "typeWorker"); ;
                return addTw.add(typeWorker);
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
        public string jsonRecoverData(string strtypeWorker)
        {
            string jsonRecoerDtes = "";
            if (strtypeWorker != "")
            {
                var typesWorkers = new List<TypeWorker>();
                typesWorkers.Add(recoverDatesTW.recoverData(strtypeWorker));
                jsonRecoerDtes = Converter.ToJson(typesWorkers);
            }
            return jsonRecoerDtes;
        }
        public string jsonTypesWorkers()
        {
            List<TypeWorker> tyupesWorkers = listTW.listar();
            return Converter.ToJson(tyupesWorkers);
        }
        public bool updateTypesWorkers(Dictionary<string, string> submit, string strtypeWorker)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                TypeWorker typeWorkers = new TypeWorker();
                typeWorkers.typeWorker = strtypeWorker;
                typeWorkers.descripcion = RetrieveAtributes.values(submit, "typeWorker");
                return updateTW.update(typeWorkers);
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
        public bool deleteTypesWorkers(string strIds)
        {
            return deleteTW.delete(strIds);
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("descripcion", caracteres);

            var table = Onkeyup.onkeyubSearchh(fields, "tipoTrabajador");
            return Converter.ToList(table);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("descripcion", caracteres);
            fields.Add("typeWorker", caracteres);

            var table = Onkeyup.onkeyubSearchhTable(fields, "tipoTrabajador");
            return Converter.ToJson(table);

        }
        public string jsonRolesBytypeWorker(string strIdTypeWorker)
        {
            Validate.TypeWorker(strIdTypeWorker);
            var campos =new Dictionary<string, string>();
            campos.Add("fkTypeWorker", strIdTypeWorker);
            var typeWorker = recoverRol.roleByTypeWorker(campos, "roles");
            if (typeWorker != null)
            {              
                return Converter.ToJson(typeWorker).ToString();
            }
            else
            {
                return "";
            }
        }
       
    }
}
