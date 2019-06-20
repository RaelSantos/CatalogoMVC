namespace CatalogoMvc.Dominio.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario Obter(string nomeusuario);
        Usuario Obter(string nomeusuario, string senha);
    }
}
