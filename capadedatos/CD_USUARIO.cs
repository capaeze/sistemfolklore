using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using capaentidad;
using System.Reflection;
using System.Collections;
using System.Security.Claims;
using System.Xml.Linq;

namespace capadedatos
{
    public class CD_USUARIO
    {
        public List<USUARIO> listar() {

            List<USUARIO> lista = new List<USUARIO>();

            using (SqlConnection oconexion = new SqlConnection(CONEXION.cadena))
            {

                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("SELECT u.ID_usuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.ID_rol,r.Descripcion FROM USUARIO u");
                    query.AppendLine("INNER JOIN ROL r ON r.ID_rol = u.ID_rol");

                  


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        while (dr.Read())
                        {

                            lista.Add(new USUARIO()
                            {

                                ID_usuario = Convert.ToInt32(dr["ID_usuario"]),
                                Documento = dr["Documento"].ToString(),
                                Nombrecompleto = dr["NombreCompleto"].ToString(),
                                correo = dr["correo"].ToString(),
                                clave = dr["clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oROL = new ROL() { ID_rol= Convert.ToInt32(dr["ID_rol"]), Descripcion = dr["Descripcion"].ToString()}

                            });


                        }



                    }
                }
                catch (Exception ex) { 

                    lista = new List<USUARIO>();
                
                
                
                
                }

            }

            return lista;

            }

        public int Registrar(USUARIO obj, out String Mensaje)
        {
            int IDusuariogenerado = 0;
            Mensaje = String.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(CONEXION.cadena))
                {


                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);

                    cmd.Parameters.AddWithValue("Documento", obj.Documento);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.Nombrecompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.correo);
                    cmd.Parameters.AddWithValue("Clave", obj.clave);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("ID_rol", obj.oROL.ID_rol);
                    cmd.Parameters.Add("IDusuarioResultado",SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();


                    cmd.ExecuteNonQuery();

                    IDusuariogenerado = Convert.ToInt32(cmd.Parameters["IDusuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }



            }
            catch(Exception ex) {

                IDusuariogenerado = 0;
                Mensaje = ex.Message;
            
            
            
            }


            return IDusuariogenerado;

        }



        public bool Editar(USUARIO obj, out String Mensaje)
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(CONEXION.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);

                    cmd.Parameters.AddWithValue("ID_usuario", obj.ID_usuario);
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.Nombrecompleto);
                    cmd.Parameters.AddWithValue("Correo", obj.correo);
                    cmd.Parameters.AddWithValue("Clave", obj.clave);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("ID_rol", obj.oROL.ID_rol);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();


                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["IDusuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }



            }
            catch (Exception ex)
            {

                Respuesta = false;
                Mensaje = ex.Message;



            }


            return Respuesta;

        }



        public bool Eliminar(USUARIO obj, out String Mensaje)
        {
            bool Respuesta = false;
            Mensaje = String.Empty;

            try
            {

                using (SqlConnection oconexion = new SqlConnection(CONEXION.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);

                    cmd.Parameters.AddWithValue("ID_usuario", obj.ID_usuario);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();


                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["IDusuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }



            }
            catch (Exception ex)
            {

                Respuesta = false;
                Mensaje = ex.Message;



            }


            return Respuesta;

        }


    }
}
