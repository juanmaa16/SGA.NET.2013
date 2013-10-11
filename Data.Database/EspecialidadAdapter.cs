﻿using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
        public class EspecialidadAdapter:Adapter
        {
            public List<Especialidad> GetAll()
            {
                List<Especialidad> especialidades = new List<Especialidad>();
                try
                {
                    this.OpenConnection();
                    SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades", sqlConn);
                    SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();
                    while (drEspecialidades.Read())
                    {
                        Especialidad esp = new Especialidad();
                        esp.IdEspecialidad= (int)drEspecialidades["id_especialidad"];
                        esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                        especialidades.Add(esp);
                    }
                    drEspecialidades.Close();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de especialidades", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }
                return especialidades;
            }

            public Entidades.Especialidad GetOne(int ID)
            {
                Especialidad esp = new Especialidad();
                try
                {
                    this.OpenConnection();
                    SqlCommand cmdEspecialidades = new SqlCommand("select * from especialidades where id_especialidad=@id", sqlConn);
                    cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    SqlDataReader drEspecialidades = cmdEspecialidades.ExecuteReader();

                    if (drEspecialidades.Read())
                    {
                        esp.IdEspecialidad = (int)drEspecialidades["id_especialidad"];
                        esp.Descripcion = (string)drEspecialidades["desc_especialidad"];
                       
                    }
                    drEspecialidades.Close();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de especialidades", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }
                return esp;
            }

            public void Delete(int ID)
            {
                try
                {
                    this.OpenConnection();
                    SqlCommand cmdDelete = new SqlCommand("delete especialidades where id_especialidad=@id", sqlConn);
                    cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    cmdDelete.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al eliminar el especialidad", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            public void Save(Especialidad especialidad)
            {
                if (especialidad.State == BusinessEntity.States.Deleted)
                {
                    this.Delete(especialidad.IdEspecialidad);
                }
                else if (especialidad.State == BusinessEntity.States.New)
                {
                    this.Insert(especialidad);
                }
                else if (especialidad.State == BusinessEntity.States.Modified)
                {
                    this.Update(especialidad);
                }
                especialidad.State = BusinessEntity.States.Unmodified;
            }


            protected void Update(Especialidad especialidad)
            {
                try
                {
                    this.OpenConnection();
                    SqlCommand cmdSave = new SqlCommand("UPDATE especialidad set desc_especialidad=@desc_especialidad WHERE id_especialidad=@id", sqlConn);
                    cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.IdEspecialidad;
                    cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                    cmdSave.ExecuteNonQuery();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al modificar datos de la especialidad", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }
            }
            protected void Insert(Especialidad especialidad)
            {
                try
                {
                    this.OpenConnection();
                    SqlCommand cmdSave = new SqlCommand("insert into especialidades(desc_especialidad) values( @desc_especialidad) select @@identity AS id_especialidad", sqlConn);
                    cmdSave.Parameters.Add("@desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                    especialidad.IdEspecialidad = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al crear la especialidad", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }
            }


        }
}
