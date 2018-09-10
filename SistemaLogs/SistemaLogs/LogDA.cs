using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaLogs
{
    public class LogDA
    {
        #region singleton
        private static readonly LogDA _instancia = new LogDA();
        public static LogDA Instancia
        {
            get { return LogDA._instancia; }
        }
        #endregion singleton
        public Boolean Insertar(string prmstrMensaje)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("usp_LOGInsertarLog", cn);
                cmd.Parameters.AddWithValue("@@prmstrMensaje", prmstrMensaje);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
                return inserto;
            }
            catch (Exception e) { throw e; }
            finally { if (cmd != null) { cmd.Connection.Close(); } }
        }
    }
}
