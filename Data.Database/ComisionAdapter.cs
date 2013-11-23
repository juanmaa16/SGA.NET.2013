using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
            public List<Comision> GetAll()
            {
                List<Comision> comisiones = new List<Comision>();
                try
                {
                    this.OpenConnection();
                    SqlCommand cmdComisiones = new SqlCommand("select * from comisiones com inner join planes pla on com.id_plan=pla.id_plan", sqlConn);
                    SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                    while (drComisiones.Read())
                    {
                        Comision com = new Comision();
                        com.IdComision= (int)drComisiones["id_comision"];
                        com.IdPlan = (int)drComisiones["id_plan"];
                        com.DescPlan= (string)drComisiones["desc_plan"];
                        com.Descripcion = (string)drComisiones["desc_comision"];
                        com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                        comisiones.Add(com);
                    }
                    drComisiones.Close();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada =
                    new Exception("Error al recuperar lista de comisiones", Ex);
                    throw ExcepcionManejada;
                }
                finally
                {
                    this.CloseConnection();
                }
                return comisiones;
            }

        public Entidades.Comision GetOne(int ID)
        {
           Comision com = new Comision();
            try
            {
                this.OpenConnection();
                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones com inner join planes pla on com.id_plan=pla.id_plan where id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    com.IdComision = (int)drComisiones["id_comision"]; 
                    com.IdPlan = (int)drComisiones["id_plan"];
                    com.DescPlan = (string)drComisiones["desc_plan"];
                    com.AnioEspecialidad= (int)drComisiones["anio_especialidad"];
                    com.Descripcion = drComisiones["desc_comision"].ToString();
                }
                drComisiones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.IdComision);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones set id_plan= @id_plan," +
                    "anio_especialidad=@anio_especialidad, desc_comision=@desc_comision WHERE id_comision=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comision.IdComision;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.VarChar, 50).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into comisiones(id_plan,anio_especialidad,desc_comision)" +
                    "values( @id_plan,@anio_especialidad,@desc_comision) select @@identity AS id_comision", sqlConn);
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IdPlan;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                comision.IdComision = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
  }
