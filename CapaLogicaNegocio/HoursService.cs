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
    public class HoursService
    {
        private AddHour addHour = new AddHour();
        private ListHours listHour = new ListHours();
        private RecoverDateHour recoverDataHour = new RecoverDateHour();
        private UpdateHour updateHour = new UpdateHour();
        private DeleteHour deleteHour = new DeleteHour();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Hour hour = new Hour();                
                string strStartHour = RetrieveAtributes.values(submit, "horaInicio");
                string strEndHour = RetrieveAtributes.values(submit, "horaTermino");
                vaalidedFormantTimes(strStartHour, strEndHour);
                hour.horaInicio = Convert.ToDateTime(strStartHour);
                hour.horaFinal = Convert.ToDateTime(strEndHour);
                return addHour.add(hour);
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
                var hours = new List<Hour>();
                hours.Add(recoverDataHour.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(hours);
            }
            return jsonRecoerDtes;
        }
        public string jsonHours()
        {
            List<Hour> hours = listHour.listar();
            return Converter.ToJson(hours);
        }
        public bool updateHours(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Hour hour = new Hour();
                hour.idHorario = Convert.ToInt32(strId);                
                string strStartHour = RetrieveAtributes.values(submit, "horaInicio");
                string strEndHour = RetrieveAtributes.values(submit, "horaTermino");
                vaalidedFormantTimes(strStartHour, strEndHour);
                hour.horaInicio = Convert.ToDateTime(strStartHour);
                hour.horaFinal = Convert.ToDateTime(strEndHour);
                return updateHour.update(hour);
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
        public bool deleteHours(string strIds)
        {
            return deleteHour.delete(strIds);
        }      
        private void vaalidedFormantTimes(string strStartTime, string strEndTime)
        {
            if (!Validation.FormantTime(strStartTime))
            {
                throw new ServiceException(MessageError.incorrectFormatInStartTime);
            }
            else if (!Validation.FormantTime(strEndTime))
            {
                throw new ServiceException(MessageError.incorrectFormatInEndTime);
            }
        }
        public List<string> onkeyupSearch(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("", caracteres);          

            var table = Onkeyup.onkeyubSearchh(fields, "horarios");
            return Converter.ToList(table);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var fields = new Dictionary<string, string>();
            fields.Add("nombre", caracteres);
            fields.Add("idHorario", caracteres);

            var table = Onkeyup.onkeyubSearchhTable(fields, "horarios");
            return Converter.ToJson(table, "idHorario", "id");

        }
    }
}
