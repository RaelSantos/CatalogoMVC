using CatalogoMvc.Data.Contexto;
using CatalogoMvc.Dominio;
using CatalogoMvc.Dominio.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoMvc.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CatalogoMvcContextoDados _contexto;

        public UsuarioRepositorio(CatalogoMvcContextoDados contexto)
        {
            this._contexto = contexto;
        }

        public void Delete(int id)
        {
            _contexto.Usuarios.Remove(_contexto.Usuarios.Find(id));
            _contexto.SaveChanges();
        }

        public IList<Usuario> Get()
        {
            return _contexto.Usuarios.ToList();
        }

        public Usuario Get(int id)
        {
           return  _contexto.Usuarios.Find(id);
        }

        public Usuario Obter(string nomeusuario)
        {
            return _contexto.Usuarios.Where(x => x.NomeUsuario.ToLower() == nomeusuario.ToLower()).FirstOrDefault();
        }

        public Usuario Obter(string nomeusuario, string senha)
        {
            return _contexto.Usuarios
                            .Where(
                                   x => x.NomeUsuario.ToLower() == nomeusuario.ToLower()
                                   && 
                                   x.Senha == senha)
                            .FirstOrDefault();
        }

        public void SaveOrUpdate(Usuario entity)
        {
            if (entity.Id == 0)
                _contexto.Usuarios.Add(entity);
            else
                _contexto.Entry<Usuario>(entity).State = System.Data.Entity.EntityState.Modified;

            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
