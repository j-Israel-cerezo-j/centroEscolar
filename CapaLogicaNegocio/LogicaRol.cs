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
using CapaLogicaNegocio.tablesInner;
using System.IO;

namespace CapaLogicaNegocio
{
    public class LogicaRol
    {
        private RecoverDataRoles recoverDatesRoles = new RecoverDataRoles();
        private ListarRoles listRoles = new ListarRoles();
        private AddRol addRol = new AddRol();
        private DeleteRol deleteRol = new DeleteRol();        
        private UpdateRol updateRol = new UpdateRol();
        private ListTypesWorkers listTW = new ListTypesWorkers();
        private TableRoles tbRoles = new TableRoles();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Rol rol = new Rol();
                rol.rol = RetrieveAtributes.values(submit, "rol"); ;
                string strFkTypeWorker= RetrieveAtributes.values(submit, "typeWorker");
                Validate.TypeWorker(strFkTypeWorker);
                rol.fkTypeWorker = strFkTypeWorker;
                return addRol.add(rol);
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
                var roles=new List<Rol>();                
                roles.Add(recoverDatesRoles.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(roles);
            }
            return jsonRecoerDtes;
        }
      
        public string jsonRoles()
        {
            var table= tbRoles.tableRoless();
            return Converter.ToJson(table).ToString();            
        }
        public bool updateRole(Dictionary<string,string> submit, string strId)
        {            
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Rol rol = new Rol();
                rol.idRol = Convert.ToInt32(strId);
                rol.rol = RetrieveAtributes.values(submit, "rol");
                string strFkTypeWorker = RetrieveAtributes.values(submit, "typeWorker");
                Validate.TypeWorker(strFkTypeWorker);
                rol.fkTypeWorker = strFkTypeWorker;
                return updateRol.update(rol);
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
        public bool deleteRoles(string strIds)
        {
            return deleteRol.delete(strIds);
        }
        //regresar todos los registros cuando sea vacio
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = tbRoles.tableRolesBymatchingCharacters(caracteres);
            return Converter.ToList(table);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {        
            var table = tbRoles.tableRolesBymatchingCharacters(caracteres);
            return Converter.ToJson(table);

        }
        public List<TypeWorker> listTypesWorker()
        {
            return listTW.listar();
        }
    }
}
