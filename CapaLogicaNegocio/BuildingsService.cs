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
    public class BuildingsService
    {
        private ListCarrers listCarrers = new ListCarrers();
        private AddBuilding addBuilding = new AddBuilding();
        private ListBuildings listBuild = new ListBuildings();
        private RecoverDataBuilding recoverDatesBuilding = new RecoverDataBuilding();
        private UpdateBuilding updateBuilding = new UpdateBuilding();
        private DeleteBuildings deleteBuilding = new DeleteBuildings();
        private RecoverDataCarrer recoverDatCarrer = new RecoverDataCarrer();
        private TableBuildings tableBuildigns = new TableBuildings();
        public List<Carrer> listarCarrers()
        {
            return listCarrers.listarCarres();
        }

        public bool add(Dictionary<string, string> submit)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            if (camposEmptysOrNull.Count == 0)
            {
                Building building = new Building();
                building.nombre = RetrieveAtributes.values(submit, "edificio");
                string strSelectFkCarre = RetrieveAtributes.values(submit, "carrera");
                validateCarreraSelec(strSelectFkCarre);
                building.fkIdCarrera = Convert.ToInt32(strSelectFkCarre);
                return addBuilding.add(building);
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
                var buildings = new List<Building>();
                buildings.Add(recoverDatesBuilding.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(buildings);
            }
            return jsonRecoerDtes;
        }
        private string jsonBuilding(List<Building> boundings)
        {
            bool ban = false;
            var campos = new Dictionary<string, string>();
            StringBuilder sbJson = new StringBuilder();
            sbJson.AppendLine("[");
            foreach (var building in boundings)
            {
                ban = true;
                campos.Add("id", building.idEdificio.ToString());
                campos.Add("nombre", building.nombre);
                Carrer carrer = recoverDatCarrer.recoverData(building.fkIdCarrera);
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
        public string jsonBuildings()
        {
            List<Building> buildings = listBuild.listarBuildings();
            return jsonBuilding(buildings);


        }
        public bool updateDivision(Dictionary<string, string> submit, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(submit);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                Building building = new Building();
                building.idEdificio = Convert.ToInt32(strId);
                building.nombre = RetrieveAtributes.values(submit, "edificio");
                string strSelectFkCarre = RetrieveAtributes.values(submit, "carrera");
                validateCarreraSelec(strSelectFkCarre);
                building.fkIdCarrera = Convert.ToInt32(strSelectFkCarre);
                return updateBuilding.update(building);
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
        public bool deleteBuildings(string strIds)
        {
            return deleteBuilding.delete(strIds);
        }       
        private void validateCarreraSelec(string select)
        {
            if (!Validation.Select(select))
            {
                throw new ServiceException(MessageError.invalidSelectorIn());
            }
        }
        public string buildingBycarrer(string strId)
        {
            var buildings=new List<Building>();
            int id = Convert.ToInt32(strId);
            if (id == -2)
            {
                buildings = listBuild.listarBuildings();

            }
            else
            {
                buildings = listBuild.listarBuildingsXcarrer(id);
            }             
            return jsonBuilding(buildings);

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var table = tableBuildigns.tableBuildingsBymatchingCharacters(caracteres);
            return Converter.ToJson(table);

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = tableBuildigns.tableBuildingsBymatchingCharacters(caracteres);
            return Converter.ToList(table);

        }
    }
}
