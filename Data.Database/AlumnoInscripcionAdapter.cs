using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones ai inner join personas p on p.id_persona=ai.id_alumno inner join cursos c on c.id_curso=ai.id_curso", sqlConn);
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion alin = new AlumnoInscripcion();
                    alin.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    alin.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                    alin.Condicion = (string)drAlumnosInscripciones["condicion"];
                    alin.Nota = (int)drAlumnosInscripciones["nota"];
                    alumnosInscripciones.Add(alin);
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnosInscripciones;
        }


        public List<AlumnoInscripcion> GetAllByIdCurso(int IdCurso)
        {
            List<AlumnoInscripcion> alumnosInscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones ai inner join personas p on p.id_persona=ai.id_alumno inner join cursos c on c.id_curso=ai.id_curso where c.id_curso=@id_curso", sqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id_curso", SqlDbType.Int).Value = IdCurso;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion alin = new AlumnoInscripcion();
                    alin.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    alin.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                    alin.Condicion = (string)drAlumnosInscripciones["condicion"];
                    alin.Nota = (int)drAlumnosInscripciones["nota"];
                    alin.NombreAlumno = (string)drAlumnosInscripciones["nombre"];
                    alin.ApellidoAlumno = (string)drAlumnosInscripciones["apellido"];
                    alumnosInscripciones.Add(alin);
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alumnosInscripciones;
        }

        public Entidades.AlumnoInscripcion GetOne(int IdAlumno, int IdCurso)
        {
            AlumnoInscripcion alin = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones ai inner join personas p on p.id_persona=ai.id_alumno inner join cursos c on c.id_curso=ai.id_curso where ai.id_alumno=@id_alumno and ai.id_curso=@id_curso", sqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IdAlumno;
                cmdAlumnosInscripciones.Parameters.Add("@id_curso", SqlDbType.Int).Value = IdCurso;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                if (drAlumnosInscripciones.Read())
                {
                    alin.IdAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    alin.IdCurso = (int)drAlumnosInscripciones["id_curso"];
                    alin.Condicion = (string)drAlumnosInscripciones["condicion"];
                    alin.Nota = (int)drAlumnosInscripciones["nota"];
                    alin.NombreAlumno = (string)drAlumnosInscripciones["nombre"];
                    alin.ApellidoAlumno = (string)drAlumnosInscripciones["apellido"];
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alin;
        }

        public void Delete(int IdAlumno, int IdCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_alumno=@id_alumno and id_curso=@id_curso", sqlConn);
                cmdDelete.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IdAlumno;
                cmdDelete.Parameters.Add("@id_curso", SqlDbType.Int).Value = IdCurso;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion alumnoInscripcion)
        {
            if (alumnoInscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(alumnoInscripcion.IdAlumno, alumnoInscripcion.IdCurso);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(alumnoInscripcion);
            }
            else if (alumnoInscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(alumnoInscripcion);
            }
            alumnoInscripcion.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones set nota=@nota, condicion=@condicion WHERE id_alumno=@id_alumno and id_curso=@id_curso", sqlConn);
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IdCurso;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion alumnoInscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones(id_curso,id_alumno,nota,condicion)" +
                    "values( @id_curso,@id_alumno,@nota,@condicion)", sqlConn);
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = alumnoInscripcion.Nota;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = alumnoInscripcion.Condicion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumnoInscripcion.IdAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alumnoInscripcion.IdCurso;
                cmdSave.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
