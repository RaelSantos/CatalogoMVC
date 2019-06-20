using System.ComponentModel.DataAnnotations;

namespace CatalogoMvc.Web.Models.Usuario
{
    public class EditarUsuarioViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Usuário obrigatório")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Senha obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme senha obrigatório")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }
    }
}