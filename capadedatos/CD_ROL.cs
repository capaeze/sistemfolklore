using capaentidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capadedatos
{
    public class CD_ROL
    {
        public List<ROL> listar()
        {

            List<ROL> lista = new List<ROL>();

            using (SqlConnection oconexion = new SqlConnection(CONEXION.cadena))
            {

                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT ID_rol,Descripcion FROM ROL");




                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        while (dr.Read())
                        {

                            lista.Add(new ROL()
                            { 
                                ID_rol = Convert.ToInt32(dr["ID_rol"]),
                                Descripcion = dr["Descripcion"].ToString(),


                            });


                        }



                    }
                }
                catch (Exception ex)
                {

                    lista = new List<ROL>();




                }

            }

            return lista;

        } 
    }
}
