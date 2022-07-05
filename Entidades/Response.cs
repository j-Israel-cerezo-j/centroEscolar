using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Response
    {
        public bool success { get; set; }
        public Dictionary<string, Object> data { get; set; }
        public string error { get; set; }
    }
}
