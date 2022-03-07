using System.Data.SqlClient;
using System.Data;
using SystemSchool.Models;


namespace SystemSchool.Data
{
    public class SchoolDAL
    {
        readonly string connectionString = "Server=.;Database=SchoolSytstemComplete;Trusted_Connection=True;";

        //Mostrar Todos los Alumnos
        public IEnumerable<Alumno> MostrarAlumnos()
        {
            IList<Alumno> ListaAlumnos = new List<Alumno>();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_MostrarEstudiantes", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var Alumno = new Alumno();

                    Alumno.Matricula_Alumno = Convert.ToInt32(dr["Matricula_Alumno"].ToString());
                    Alumno.Nombre_Alumno = dr["Nombre_Alumno"].ToString();
                    Alumno.Edad_Alumno = Convert.ToInt32(dr["Edad_Alumno"].ToString());
                    Alumno.Semestre_Alumno = dr["Semestre_Alumno"].ToString();
                    Alumno.Genero_Alumno = dr["Genero_Alumno"].ToString();

                    ListaAlumnos.Add(Alumno);

                }
                con.Close();
            }
            

            return ListaAlumnos;

        }

        //Crear Alumno
        public void CrearAlumno(Alumno Alumno)
        {
           using(SqlConnection con  = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CrearEstudiante", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre_Alumno", Alumno.Nombre_Alumno);
                cmd.Parameters.AddWithValue("@Edad_Alumno", Alumno.Edad_Alumno);
                cmd.Parameters.AddWithValue("@Semestre_Alumno", Alumno.Semestre_Alumno);
                cmd.Parameters.AddWithValue("@Genero_Alumno", Alumno.Genero_Alumno);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Editar Alumno
        public void EditarAlumno(Alumno Alumno)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EditarAlumno", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Matricula_Alumno", Alumno.Matricula_Alumno);
                cmd.Parameters.AddWithValue("@Nombre_Alumno", Alumno.Nombre_Alumno);
                cmd.Parameters.AddWithValue("@Edad_Alumno", Alumno.Edad_Alumno);
                cmd.Parameters.AddWithValue("@Semestre_Alumno", Alumno.Semestre_Alumno);
                cmd.Parameters.AddWithValue("@Genero_Alumno", Alumno.Genero_Alumno);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Obtener Estudiante Por Idd
        public Alumno MostraralumnoPorId(int? Matricula_Alumno)
        {
           Alumno Alumno = new Alumno();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerAlumnoPorId", con);

                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.Parameters.AddWithValue("@Matricula_Alumno", Matricula_Alumno);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Alumno.Matricula_Alumno = Convert.ToInt32(dr["Matricula_Alumno"].ToString());
                    Alumno.Nombre_Alumno = dr["Nombre_Alumno"].ToString();
                    Alumno.Edad_Alumno = Convert.ToInt32(dr["Edad_Alumno"].ToString());
                    Alumno.Semestre_Alumno = dr["Semestre_Alumno"].ToString();
                    Alumno.Genero_Alumno = dr["Genero_Alumno"].ToString();

                }
                con.Close();
            }


            return Alumno;

        }


    }
}
