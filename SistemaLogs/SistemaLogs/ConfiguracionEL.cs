using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogs
{
    public class ConfiguracionEL
    {
        public Boolean EnArchivo { get; set; }
        public Boolean EnConsola { get; set; }
        public Boolean Mensaje { get; set; }
        public Boolean Advertencia { get; set; }
        public Boolean Error { get; set; }
        public Boolean  EnBaseDeDatos { get; set; }
        public Boolean Inicializar { get; set; }
    }
}
