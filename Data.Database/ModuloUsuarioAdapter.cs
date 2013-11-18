using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modulosUsuario = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios", sqlConn);
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario ml = new ModuloUsuario();
                    ml.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    ml.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    ml.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    ml.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    ml.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    ml.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                    modulosUsuario.Add(ml);
                }
                drModulosUsuarios.Close();
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
            return modulosUsuario;
        }



        public Entidades.ModuloUsuario GetOne(int IdModulo, int IdUsuario)
        {
            ModuloUsuario ml = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("select * from modulos_usuarios where id_modulo=@idModulo and id_usuario=@idUsuario", sqlConn);
                cmdModulos.Parameters.Add("@idModulo", SqlDbType.Int).Value = IdModulo;
                cmdModulos.Parameters.Add("@idUsuario", SqlDbType.Int).Value = IdUsuario;
                SqlDataReader drModulosUsuarios = cmdModulos.ExecuteReader();

                if (drModulosUsuarios.Read())
                {
                    ml.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    ml.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    ml.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    ml.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    ml.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    ml.PermiteConsulta = (bool)drModulosUsuarios["consulta"];

                }
                drModulosUsuarios.Close();
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

        public void Delete(int IdModulo, int IdUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete modulos where id_modulo=@idModulo and id_usuario=@idUsuario", sqlConn);
                cmdDelete.Parameters.Add("@idModulo", SqlDbType.Int).Value = IdModulo;
                cmdDelete.Parameters.Add("@idUsuario", SqlDbType.Int).Value = IdUsuario;
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

        protected void Update(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos set alta=@alta, baja=@baja, modificacion=@modificacion, consulta=@consulta WHERE id_modulo=@idModulo and id_usuario=@idUsuario", sqlConn);
                cmdSave.Parameters.Add("@idModulo", SqlDbType.Int).Value = moduloUsuario.IdModulo;
                cmdSave.Parameters.Add("@idUsuarios", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteConsulta;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteModificacion;
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
        protected void Insert(ModuloUsuario moduloUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into modulos_usuarios(id_modulo, id_usuario,alta,baja,modificacion,consulta)" +
                    "values( @id_modulo, @id_usuario,@alta,@baja,@modificacion,@consulta)", sqlConn);
                cmdSave.Parameters.Add("@idModulo", SqlDbType.Int).Value = moduloUsuario.IdModulo;
                cmdSave.Parameters.Add("@idUsuarios", SqlDbType.Int).Value = moduloUsuario.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteBaja;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteConsulta;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit, 50).Value = moduloUsuario.PermiteModificacion;
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

        public void Save(ModuloUsuario moduloUsuario)
        {
            if (moduloUsuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(moduloUsuario.IdModulo, moduloUsuario.IdUsuario);
            }
            else if (moduloUsuario.State == BusinessEntity.States.New)
            {
                this.Insert(moduloUsuario);
            }
            else if (moduloUsuario.State == BusinessEntity.States.Modified)
            {
                this.Update(moduloUsuario);
            }
            moduloUsuario.State = BusinessEntity.States.Unmodified;
        }
    }
}
