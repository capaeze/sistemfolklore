using capaentidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace capadedatos
{
    public class CD_PERMISO
    {

        public List<PERMISO> listar(int ID_usuario)
        {

            List<PERMISO> lista = new List<PERMISO>();

            using (SqlConnection oconexion = new SqlConnection(CONEXION.cadena))
            {

                try
                {

                   StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.ID_rol, p.NombreMenu FROM PERMISO p");
                    query.AppendLine("INNER JOIN ROL r ON r.ID_rol = p.ID_rol");
                    query.AppendLine("INNER JOIN USUARIO u ON u.ID_rol = r.ID_rol");
                    query.AppendLine("WHERE u.ID_usuario = @ID_usuario");

 

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@ID_usuario", ID_usuario);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        while (dr.Read())
                        {

                            lista.Add(new PERMISO()
                            {

                                oROL = new ROL() { ID_rol = Convert.ToInt32(dr["ID_rol"]) },
                                NombreMenu = dr["NombreMenu"].ToString(),


                            });


                        }



                    }
                }
                catch (Exception ex)
                {

                    lista = new List<PERMISO>();




                }

            }

            return lista;

        }
    }

}




