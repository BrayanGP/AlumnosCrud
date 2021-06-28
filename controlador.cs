using System.Configuration;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AlumnosCrud
{
    class controlador
    {
        private string _conexion;
        public controlador()
        {
            _conexion = ConfigurationManager.ConnectionStrings["practica"].ConnectionString;


        }
      public List<alumnos> mostrarAlumnos()
        {
            List<alumnos> alum = new List<alumnos>();
            string consulta = $"select id,nombre,correo from Alumnos";
            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    SqlCommand comando = new SqlCommand(consulta, con);
                    comando.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader leer = comando.ExecuteReader();
                    while (leer.Read())
                    {
                        alumnos alumno = new alumnos();
                        alumno.id = Convert.ToInt32(leer["id"]);
                        alumno.nombre = Convert.ToString(leer["nombre"]);
                        alumno.correo = Convert.ToString(leer["correo"]);
                        alum.Add(alumno);
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error al consultar", ex);
            }
            return alum;
        }



    }
}
