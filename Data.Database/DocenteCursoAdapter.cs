﻿using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("select * from docentes_cursos", sqlConn);
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso doc = new DocenteCurso();
                    doc.IdCurso = (int)drDocentesCursos["id_curso"];
                    doc.IdDocente = (int)drDocentesCursos["id_docente"];
                    doc.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];
                    docentes.Add(doc);
                }
                drDocentesCursos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docentes curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentes;
        }
        public DocenteCurso GetOne(int ID_D, int ID_C)
        {
            DocenteCurso doc = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCurso = new SqlCommand("select * from docentes_cursos where id_docente=@id_d and id_curso=@id_c", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_d", SqlDbType.Int).Value = ID_D;
                cmdDocenteCurso.Parameters.Add("@id_c", SqlDbType.Int).Value = ID_C;
                SqlDataReader drDocentesCursos = cmdDocenteCurso.ExecuteReader();
                if (drDocentesCursos.Read())
                {
                    doc.IdCurso = (int)drDocentesCursos["id_curso"];
                    doc.IdDocente = (int)drDocentesCursos["id_docente"];
                    doc.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];
                }
                drDocentesCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docentes curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return doc;
        }

        public void Delete(int ID_D, int ID_C)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_docente=@id_d and id_curso=@id_c", sqlConn);
                cmdDelete.Parameters.Add("@id_d", SqlDbType.Int).Value = ID_D;
                cmdDelete.Parameters.Add("@id_c", SqlDbType.Int).Value = ID_C;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el docente curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso docenteCurso)
        {
            if (docenteCurso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(docenteCurso.IdDocente, docenteCurso.IdCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.New)
            {
                this.Insert(docenteCurso);
            }
            else if (docenteCurso.State == BusinessEntity.States.Modified)
            {
                this.Update(docenteCurso);
            }
            docenteCurso.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos set cargo=@cargo WHERE id_docente=@id_d and id_curso=@id_c", sqlConn);
                cmdSave.Parameters.Add("@id_c", SqlDbType.Int).Value = docenteCurso.IdCurso;
                cmdSave.Parameters.Add("@id_d", SqlDbType.Int).Value = docenteCurso.IdDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del docente curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(DocenteCurso docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into docentes_cursos(cargo,id_docente,id_curso) values(@cargo, @id_docente, @id_curso)", sqlConn);
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docenteCurso.Cargo;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docenteCurso.IdCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docenteCurso.IdDocente;
                cmdSave.ExecuteScalar();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear el docente curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<DocenteCurso> GetAllByDocente(int idDocente)
        {
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCursos = new SqlCommand("SELECT * FROM cursos INNER JOIN docentes_cursos ON cursos.id_curso = docentes_cursos.id_curso INNER JOIN materias ON cursos.id_materia = materias.id_materia WHERE (docentes_cursos.id_docente = @id_docente)", sqlConn);
                cmdDocentesCursos.Parameters.Add("@id_docente", SqlDbType.Int).Value = idDocente;
                SqlDataReader drDocentesCursos = cmdDocentesCursos.ExecuteReader();
                while (drDocentesCursos.Read())
                {
                    DocenteCurso doc = new DocenteCurso();
                    doc.IdCurso = (int)drDocentesCursos["id_curso"];
                    doc.IdDocente = (int)drDocentesCursos["id_docente"];
                    doc.Cargo = (DocenteCurso.TiposCargo)drDocentesCursos["cargo"];
                    doc.DescMateria = (string)drDocentesCursos["desc_materia"];
                    docentes.Add(doc);
                }
                drDocentesCursos.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de docentes curso", ex);
                return null;
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docentes;
        }
    }



}
