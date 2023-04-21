using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace centroEscolar.gentelella_master.production.messagesErrors
{
    public class MessagesErrors
    {
        public static string blockedAccount { get; set; } = "Cuenta bloqueada";
        public static string accountLockedAndLoggedOut { get; set; } = "Cuenta bloqueada, se ha cerrado tu sesión";
        public static string closedSession { get; set; } = "Sesión cerrada";
    }
}