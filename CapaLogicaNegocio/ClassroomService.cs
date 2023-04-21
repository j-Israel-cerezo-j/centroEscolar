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
using CapaLogicaNegocio.Selects;
namespace CapaLogicaNegocio
{
    public class ClassroomService
    {
        private ListClassrooms listClassrooms = new ListClassrooms();
        private ListBuildings listBuildings = new ListBuildings();
        private ListTypeClassroom listTypeClassroom = new ListTypeClassroom();  
        private AddClassroom addClassrooms = new AddClassroom();
        private RecoverDataClassroom recoverDatesClassrooms = new RecoverDataClassroom();
        private UpdateClassroom updateClassrooms = new UpdateClassroom();
        private DeleteClassrooms deleteClassrooms = new DeleteClassrooms();
        private TableClassrom tableClassrooms = new TableClassrom();
        public bool add(Dictionary<string, string> request)
        {
            bool ban = false;
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            if (camposEmptysOrNull.Count == 0)
            {
                validateAttributes(request);
                Classroom classroom = buildClassroomObj(request);
                return addClassrooms.add(classroom);
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
                var clasrooms = new List<Classroom>();
                clasrooms.Add(recoverDatesClassrooms.recoverData(Convert.ToInt32(strId)));
                jsonRecoerDtes = Converter.ToJson(clasrooms);
            }
            return jsonRecoerDtes;
        }

        public string jsonClasrooms()
        {
            return Converter.ToJson(tableClassrooms.tableClassrooms()).ToString();
        }
        public bool updateClassroom(Dictionary<string, string> request, string strId)
        {
            var camposEmptysOrNull = Validation.isNullOrEmptys(request);
            bool ban = false;
            if (camposEmptysOrNull.Count == 0)
            {
                validateAttributes(request);
                Classroom classroom = buildClassroomObj(request);
                classroom.idSalon = Convert.ToInt32(strId);
                return updateClassrooms.update(classroom);
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
        public bool deleteClassroom(string strIds)
        {
            return deleteClassrooms.delete(strIds);
        }
        public List<Building> listarBuildings()
        {
            return listBuildings.listarBuildings();
        }
        public List<TypeClassroom> listarTypeClassroom()
        {
            return listTypeClassroom.listarTypeClassroom();
        }
        private void validateAttributes(Dictionary<string,string> request)
        {            
            string strCupo = RetrieveAtributes.values(request, "cupo");
            string strSelectFkEdif = RetrieveAtributes.values(request, "edificios");
            string strSelectFkTypeCLassroom = RetrieveAtributes.values(request, "tipoSalones");
            if (!Validation.numericalFormat(strCupo))
            {
                throw new ServiceException(MessageError.incorrectFormatNumber);
            }
            else if (!Validation.Select(strSelectFkEdif))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("Edificios"));
            }
            else if (!Validation.Select(strSelectFkTypeCLassroom))
            {
                throw new ServiceException(MessageError.invalidSelectorIn("Tipo de salon"));
            }
        }
        public string classromsByEdif(string strId)
        {
            int id = Convert.ToInt32(strId);
            return Converter.ToJson(tableClassrooms.tableClassroomsByEdif(id)).ToString();

        }
        public string classromsByTypeClassroom(string strId)
        {
            int id = Convert.ToInt32(strId);           
            return Converter.ToJson(tableClassrooms.tableClassroomsByTypeClassroom(id)).ToString();

        }
        public string classromsByCarrers(string strId)
        {
            int id = Convert.ToInt32(strId);
            return Converter.ToJson(tableClassrooms.tableClassroomsByCarrers(id)).ToString();

        }
        public StringBuilder onkeyupSearchTable(string caracteres)
        {
            var table = tableClassrooms.tableClassroomsBymatchingCharacters(caracteres);
            return Converter.ToJson(table);

        }
        public List<string> onkeyupSearch(string caracteres)
        {
            caracteres = "%" + caracteres + "%";
            var table = tableClassrooms.tableClassroomsBymatchingCharacters(caracteres);
            return Converter.ToList(table);

        }
        private Classroom buildClassroomObj(Dictionary<string,string> request)
        {
            Classroom classroom = new Classroom();
            classroom.clave = RetrieveAtributes.values(request, "clave");
            classroom.cupo =
                Convert.ToInt32(RetrieveAtributes.values(request, "cupo"));
            classroom.fkEdificio =
                Convert.ToInt32(RetrieveAtributes.values(request, "edificios"));
            classroom.fkTipoSalon = 
                Convert.ToInt32( RetrieveAtributes.values(request, "tipoSalones"));
            return classroom;
        }
        public string typeClassroomOptions(string strOption)
        {
            string json = "";
            if (strOption== "fkEdificio")
            {
                json = Converter.ToJson(Select.findFromAll("edificios")).ToString();
            }
            else if (strOption == "fkTipoSalon")
            {
                json = Converter.ToJson(Select.findFromAll("tipoSalon")).ToString();
            }
            else if (strOption == "fkCarreras")
            {
                json = Converter.ToJson(Select.findFromAll("carreras")).ToString();
            }
            return json;
        }
        public string responseClassroomOptions(string strOption,string idOption)
        {
            string json = "";
            if (idOption == "-2")
            {
                json = jsonClasrooms();
            }
            else
            {
                if (strOption == "fkEdificio")
                {
                    json = classromsByEdif(idOption);
                }
                else if (strOption == "fkTipoSalon")
                {
                    json = classromsByTypeClassroom(idOption);
                }
                else if (strOption == "fkCarreras")
                {
                    json = classromsByCarrers(idOption);
                }
            }            
            return json;
        }

    }
}
