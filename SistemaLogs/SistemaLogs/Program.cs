using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLogs
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            try
            {
                LogBL _LogBL = new LogBL();
                ConfiguracionEL Config = _LogBL.InicializarConfiguracion();
                MensajeLogEL ObjMsj = new MensajeLogEL();
                Console.WriteLine("Ingrese Mensaje");
                ObjMsj.Mensaje = Console.ReadLine();

                Console.WriteLine(_LogBL.RegistraLog(Config, ObjMsj));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        
    }
}
