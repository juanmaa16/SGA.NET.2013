using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Data.Database;


namespace Negocio
{
    public class UsuarioLogic : BusinessLogic
    {
        UsuarioAdapter uData;

        public UsuarioLogic()
        {
           this.uData = new UsuarioAdapter();
        }

        public UsuarioAdapter UsuarioData
        {get;set;}

        public List<Usuario> GetAll()
        {
            return  uData.GetAll();
        }

        public Usuario GetOne(int ID)
        {
            return uData.GetOne(ID);
        }

        public Usuario GetOneUser(string User)
        {
            return uData.GetOneUser(User);
        }

        public void Delete(int ID)
        {
            uData.Delete(ID);
        }

        public void Save(Usuario usuario)
        {
            uData.Save(usuario);
        }




    }
}
