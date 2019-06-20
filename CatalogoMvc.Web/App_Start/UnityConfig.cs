using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using CatalogoMvc.Data.Contexto;
using CatalogoMvc.Dominio.Repositorios;
using CatalogoMvc.Data.Repositorios;

namespace CatalogoMvc.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<CatalogoMvcContextoDados, CatalogoMvcContextoDados>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(new HierarchicalLifetimeManager());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}