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
    public class LogicaRol
    {
        RecoverDataRoles recoverDatesRoles = new RecoverDataRoles();
        ListarRoles listRoles = new ListarRoles();
        AddRol addRol = new AddRol();
        DeleteRol deleteRol = new DeleteRol();        
        UpdateRol updateRol = new UpdateRol();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Rol rol = new Rol();
                rol.rol = RetrieveAtributesValues.retrieveAtributesValues(submit, "rol"); ;
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
            List<Rol> roles= listRoles.listarRoles();
            return Converter.ToJson(roles);            
        }
        public bool updateRole(Dictionary<string,string> submit, string strId)
        {            
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Rol rol = new Rol();
                rol.idRol = Convert.ToInt32(strId);
                rol.rol = RetrieveAtributesValues.retrieveAtributesValues(submit, "rol");
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
    }
}
