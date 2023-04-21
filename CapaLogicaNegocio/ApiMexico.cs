using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogicaNegocio.utils;
using CapaLogicaNegocio.MessageErrors;
namespace CapaLogicaNegocio
{
    public class ApiMexico
    {
        public string recoverDatas(string catalogo,string value)
        {
            string json = "";
            switch (catalogo)
            {
                case "municipios":
                    json=jsonMunicipes(value);
                break;

            }
            return json;
        }
        private string jsonMunicipes(string state)
        {
            return JsonMexico.Municipios(state);
        }
    }
}
