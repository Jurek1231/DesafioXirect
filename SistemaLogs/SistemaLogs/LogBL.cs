using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogs
{
    public class LogBL
    {
        public ConfiguracionEL InicializarConfiguracion()
        {
            ConfiguracionEL Config = new ConfiguracionEL();
            Config.EnArchivo = true;
            Config.EnConsola = false;
            Config.Mensaje = true;
            Config.Advertencia = false;
            Config.Error = true;
            Config.Inicializar = true;
            return Config;
        }
        public string RegistraLog(ConfiguracionEL prmObjConfig, MensajeLogEL Mensaje)
        {
            try
            {
                string returno = "";
                Mensaje.Mensaje.Trim();
                if (Mensaje == null || Mensaje.Mensaje.Length == 0)
                {
                    return "false";
                }
                if (!prmObjConfig.EnConsola && !prmObjConfig.EnArchivo && !prmObjConfig.EnBaseDeDatos)
                {
                    throw new Exception("Configuracion invalida");
                }
                if ((!Mensaje.Error && Mensaje.Mensaje != null && !Mensaje.Advertencia) || (Mensaje.Mensaje != null && !prmObjConfig.Advertencia && !prmObjConfig.Error))
                {
                    throw new Exception("Debe especificar el nivel de error");
                }
                if (Mensaje.Mensaje != null && Mensaje.Mensaje1)
                {
                    returno = "1";
                }
                if (Mensaje.Error && Mensaje.Error)
                {
                    returno = "2";
                }
                if (Mensaje.Advertencia && prmObjConfig.Advertencia)
                {
                    returno = "3";
                }
                if (Mensaje.Error && prmObjConfig.Error)
                {
                    returno = returno + DateTime.Now.ToShortDateString() + Mensaje.Mensaje;
                }
                if (Mensaje.Advertencia && prmObjConfig.Advertencia)
                {
                    returno = returno + DateTime.Now.ToShortDateString() + Mensaje.Mensaje;
                }
                if (Mensaje.Mensaje1 && prmObjConfig.Mensaje)
                {
                    returno = returno + DateTime.Now.ToShortDateString() + Mensaje.Mensaje;
                }
                if (prmObjConfig.Error && Mensaje.Error)
                {
                    returno = returno + "_red_" + DateTime.Now.ToShortDateString() + Mensaje.Mensaje;
                }
                if (prmObjConfig.Advertencia && Mensaje.Advertencia)
                {
                    returno = returno + "_yellow_" + DateTime.Now.ToShortDateString() + Mensaje.Mensaje;
                }
                if (Mensaje.Mensaje1 && prmObjConfig.Mensaje)
                {
                    returno = returno + "_white_" + DateTime.Now.ToShortDateString() + Mensaje.Mensaje;
                }
                LogDA.Instancia.Insertar(returno);
                return Mensaje.Mensaje;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
