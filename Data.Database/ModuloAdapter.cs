using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloAdapter:Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("select * from modulos", sqlConn);
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo ml = new Modulo();
                    ml.IDModulo = (int)drModulos["id_modulo"];
                    ml.Descripcion= (string)drModulos["desc_modulo"];
                    ml.Ejecuta = (string)drModulos["ejecuta"];
                    modulos.Add(ml);
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return modulos;
        }



        public Entidades.Modulo GetOne(int ID)
        {
            Modulo ml = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("select * from modulos where id_modulo=@id", sqlConn);
                cmdModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                if (drModulos.Read())
                {
                    ml.IDModulo = (int)drModulos["id_modulo"];
                    ml.Descripcion = (string)drModulos["desc_modulo"];
                    ml.Ejecuta = (string)drModulos["ejecuta"];

                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return ml;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete modulos where id_modulo=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminar el modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos set desc_modulo= @desc_modulo, ejecuta=@ejecuta WHERE id_modulo=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.IDModulo;
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                cmdSave.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = modulo.Ejecuta;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al modificar datos del modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Modulo modulo)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into modulos(desc_modulo, ejecuta)" +
                    "values( @desc_modulo, @ejecuta) select @@identity AS id_modulo", sqlConn);
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;
                cmdSave.Parameters.Add("@ejecuta", SqlDbType.VarChar, 50).Value = modulo.Ejecuta;
                modulo.IDModulo = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al crear el modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Modulo modulo)
        {
            if (modulo.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modulo.IDModulo);
            }
            else if (modulo.State == BusinessEntity.States.New)
            {
                this.Insert(modulo);
            }
            else if (modulo.State == BusinessEntity.States.Modified)
            {
                this.Update(modulo);
            }
            modulo.State = BusinessEntity.States.Unmodified;
        }
    }
}
