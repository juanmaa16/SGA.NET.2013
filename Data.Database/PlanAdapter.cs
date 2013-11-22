using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter:Adapter
    {
        public List<Plan> GetAll()
        {       
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes pla inner join especialidades esp on pla.id_especialidad=esp.id_especialidad", sqlConn);
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan pl = new Plan();
                    pl.IdPlan= (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IdEspecialidad =(int)drPlanes["id_especialidad"];
                    pl.DescEspecialidad = (string)drPlanes["desc_especialidad"];
                    planes.Add(pl);
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;
        }



        public Entidades.Plan GetOne(int ID)
        {
            Plan pl = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes pla inner join especialidades esp on pla.id_especialidad=esp.id_especialidad where id_plan=@id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    pl.IdPlan = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    pl.DescEspecialidad = (string)drPlanes["desc_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return pl;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes set desc_plan= @desc_plan, id_especialidad=@id_especialidad WHERE id_plan=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.IdPlan;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into planes(desc_plan, id_especialidad)" +
                    "values( @desc_plan, @id_especialidad) select @@identity AS id_plan", sqlConn);
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IdEspecialidad;
                plan.IdPlan = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.IdPlan);
            }
            else if (plan.State == BusinessEntity.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                this.Update(plan);
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
