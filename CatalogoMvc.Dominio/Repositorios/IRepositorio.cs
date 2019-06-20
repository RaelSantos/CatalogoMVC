using System;
using System.Collections.Generic;

namespace CatalogoMvc.Dominio.Repositorios
{
    public interface IRepositorio<T>: IDisposable
    {
        IList<T> Get();
        T Get(int id);
        void SaveOrUpdate(T entity);
        void Delete(int id);
    }
}
