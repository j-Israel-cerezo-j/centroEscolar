using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.MessageErrors
{
    public class MessageError
    {        
        public static string noRoleAssigned { get; } = "Ningún rol asignado";
        public static string radiusNotSelected { get; } = "Radio no seleccionado";
        public static string nonexistentAddress { get; } = "Domicilio inexistente";
        public static string nonexistentStudent { get; } = "Alumno inexistente";
        public static string nonexistentUser{ get; } = "Usuario inexistente";
        public static string errorSavingUserImage { get; set; } = "Error al guardar la imagen del usuario,intentarlo mas tarde por favor";
        public static string errorAddUser { get; set; } = "Error al registrar usuario,intentelo mas tarde por favor";
        public static string errorUpdateUser { get; set; } = "Error al actualizar usuario,intentelo mas tarde por favor";
        public static string alreadyApprovedCandidate { get; } = "Candidato ya aprobado";
        public static string failedToAddToGroup { get; } = "Error al agregar al grupo";
        
        public static string incorrectFormatInStartTime { get; } = "Formato no correcto sobre hora de inicio";
        public static string incorrectFormatInEndTime { get; } = "Formato no correcto sobre hora de término";
        public static string incorrectFormatInEndDate { get; } = "Formato no correcto sobre fecha de término";
        public static string incorrectFormatInStartDate{ get; } = "Formato no correcto sobre fecha de inicio";
        public static string curpAlreadyExisting { get; } = "Curp ya existente en alguno de los usuarios divisionales,generales o alumnos";
        public static string existingEmail { get; } = "Correo ya existente en alguno de los usuarios divisionales,generales o alumnos";
        public static string incorrectFormatInEmail { get; } = "Formato no correcto en correo";
        public static string incorrectDateOfBirthFormat { get; } = "Formato no correcto en fecha de nacimiento";

        public static string incorrectFormatInPhoneNumbere { get; } = "Formato no correcto en telefono(solo números)";
        public static string incorrectFormatNumber { get; } = "Formato númerico incorrecto";
        public static string incorrectFormatInRol { get; } = "Seleccione uno o mas roles por favor.";
        public static string incorrectFormatInTypeWorker { get; } = "Seleccione un tipo de trabajador por favor.";
        public static string divisionsNotSelected { get; } = "Divisiones no seleccionadas.";
        public static string privilegesNotSelected { get; } = "Privilegios no seleccionados.";
        public static string questionsNotSelected { get; } = "Preguntas no seleccionadas.";
        public static string responsesNotSelected { get; } = "Respuestas no seleccionadas.";
        public static string carrersNotSelected { get; } = "Carreras no seleccionadas.";
        public static string AnErrorOccurredTryAgainLater { get; } = "Se produjo un error, intentelo mas tarde.";

        public static string nonexistentField(string field="")
        {
            return "El campo " + field + " no exite";
        }
        public static string wrongLength(string campo,string minLength, string maxLength)
        {
            return "La longitud de " + campo + " tiene que ser no menor a " + minLength + " y no mayor a " + maxLength+" caracteres";
        }
        public static string invalidSelectorIn(string campo="")
        {
            if (campo != "")
            {
                return "Selecciona una opción correcta sobre el selector "+ campo;
            }
            else
            {
                return "Selecciona una opción correcta sobre selector";
            }            
        }
        public static string wrongFileExtension(string extensions)
        {
            return "Solamente se permiten archivos "+ extensions;
        }
    }
}
