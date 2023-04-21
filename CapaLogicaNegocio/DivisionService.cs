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
using Newtonsoft.Json;
using CapaLogicaNegocio.MessageErrors;
using CapaLogicaNegocio.Onkeyups;
using CapaLogicaNegocio.tablesInner;
namespace CapaLogicaNegocio
{
    public class DivisionService
    {
        private ListCarrers listCarrers=new ListCarrers();
        private AddDivision addDiv = new AddDivision();
        private ListDivisions listDiv = new ListDivisions();
        private RecoverDataDivision recoverDatesDiv = new RecoverDataDivision();
        private UpdateDivision updateDiv = new UpdateDivision();
        private DeleteDivisons deleteDiv = new DeleteDivisons(); 
        private RecoverDataCarrer recoverDatCarrer=new RecoverDataCarrer();
        private TableDivisions tablesDivisions = new TableDivisions();
        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Division division = new Division();
                division.nombre = RetrieveAtributes.values(submit, "division");
                string strSelectFkCarre = RetrieveAtributes.values(submit, "carrera");
                validateCarreraSelec(strSelectFkCarre);
                division.fkIdCarrera = Convert.ToInt32(strSelectFkCarre);
                return addDiv.add(division);
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
                var divisions = new List<Division>();
                divisions.Add(recoverDatesDiv.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(divisions);
            }
            return jsonRecoerDtes;
        }
        private string jsonDivisions(List<Division> divisiones)
        {
            bool ban = false;
            var campos = new Dictionary<string, string>();
            StringBuilder sbJson = new StringBuilder();
            sbJson.AppendLine("[");
            foreach (var division in divisiones)
            {
                ban = true;
                campos.Add("id", division.idDivision.ToString());
                campos.Add("nombre", division.nombre);
                Carrer carrer = recoverDatCarrer.recoverData(division.fkIdCarrera);
                if (carrer != null)
                {
                    campos.Add("fkCarrera", carrer.nombre);
                }
                else
                {
                    campos.Add("fkCarrera", "");
                }
                sbJson.AppendLine(Converter.ToJson(campos) + ",");
                campos.Clear();
            }
            string strJson = sbJson.ToString();
            if (ban)
            {
                strJson = strJson.Substring(0, strJson.Length - 1);
            }
            strJson += "]";
            return strJson;
        }
        public string jsonDivisions()
        {                       
            List<Division> divisions = listDiv.listarDivisions();
            return jsonDivisions(divisions);


        }
        public bool updateDivision(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Division division = new Division();
                division.idDivision =Convert.ToInt32( strId);
                division.nombre = RetrieveAtributes.values(submit, "division");
                string strSelectFkCarre = RetrieveAtributes.values(submit, "carrera");
                validateCarreraSelec(strSelectFkCarre);
                division.fkIdCarrera = Convert.ToInt32(strSelectFkCarre);
                return updateDiv.update(division);
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
        public bool deleteDivision(string strIds)
        {
            return deleteDiv.delete(strIds);
        }
        public List<Carrer> listarCarrers()
        {
            return listCarrers.listarCarres();
        }
        private void validateCarreraSelec(string select)
        {
            if (!Validation.Select(select))
            {
                throw new ServiceException(MessageError.invalidSelectorIn());
            }
        }
        public string divisionsXcarrer(string strId)
        {
            int id = Convert.ToInt32(strId);
            var divisions=new List<Division>();
            if (id == -2)
            {
                divisions = listDiv.listarDivisions();

            }
            else
            {
                divisions = listDiv.listarDivisionsXcarrer(id);
            }
            return jsonDivisions(divisions);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {          
            var table = tablesDivisions.tableDivisionsBymatchingCharacters(caracteres);
            return Converter.ToJson(table);

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = tablesDivisions.tableDivisionsBymatchingCharacters(caracteres);
            return Converter.ToList(table);

        }
    }
}
