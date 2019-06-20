using System;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace CatalogoMvc.Dominio
{
    public class Usuario
    {
        protected Usuario()
        {

        }
        public Usuario(string nome, string email, string nomeusuario, string senha)
        {
            Contract.Requires<Exception>(nome.Length < 3, "Nome inválido");
            Contract.Requires<Exception>(Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" ), "E -mail Inválido");
            Contract.Requires<Exception>(nomeusuario.Length < 8, "Nome do usuário inválido");
            Contract.Requires<Exception>(senha.Length < 6, "Senha inválido");

            this.Id = 0;
            this.Nome = nome;
            this.Email = email;
            this.NomeUsuario = nomeusuario;
            this.Senha = senha;
        }

        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }        
        public string NomeUsuario { get; protected set; }
        public string Senha { get; set; }

        public void AlterarEmail(string email)
        {
            Contract.Requires<Exception>(Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"), "E -mail Inválido");
            this.Email = email;
        }

        public void AlterarSenha(string nomeUsuario, string senha, string novaSenha, string confirmarSenha)
        {
            Contract.Requires<Exception>(
                this.NomeUsuario.ToLower() == nomeUsuario
                &&
                this.Senha == senha, 
                "Usuário ou Senha inválidos");
            Contract.Requires<Exception>(novaSenha != this.Senha, "A nova senha deve ser diferente da anterior");
            Contract.Requires<Exception>(novaSenha.Length > 6, "Senha inválido");
            Contract.Requires<Exception>(novaSenha == confirmarSenha, "As senhas digitadas não coincidem ");

            this.Senha = novaSenha;
        }

        public void Altenticar(string nomeUsuario, string senha)
        {
            Contract.Requires<InvalidOperationException>(this.NomeUsuario.ToLower() == nomeUsuario.ToLower(), "Usuário ou senha inválido");
            Contract.Requires<InvalidOperationException>(this.Senha == senha, "Usuário ou senha inválido");
        }

        public void Registrar(string nome, string email, string nomeUsuario, string senha, string confirmarSenha)
        {
            Contract.Requires<InvalidOperationException>(nome.Length > 3, "O nome deve ter mais de 3 chars.");
            Contract.Requires<InvalidOperationException>(Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"), "E -mail Inválido");
            Contract.Requires<InvalidOperationException>(nomeUsuario.Length > 6, "Nome do usuário inválido");
            Contract.Requires<InvalidOperationException>(senha.Length >= 6, "A senha deve conter pelo menos 6 caracteres");
            Contract.Requires<InvalidOperationException>(senha == confirmarSenha, "As senhas informadas não coincidem");

            this.Nome = nome;
            this.Email = email;
            this.NomeUsuario = nomeUsuario;
            this.Senha = senha;
        }

        public void AlterarInfo(string nome, string email, string nomeUsuario, string senha, string confirmarSenha)
        {
            Contract.Requires<InvalidOperationException>(nome.Length > 3, "O nome deve ter mais de 3 chars.");
            Contract.Requires<InvalidOperationException>(Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"), "E -mail Inválido");
            Contract.Requires<InvalidOperationException>(nomeUsuario.Length > 6, "Nome do usuário inválido");
            Contract.Requires<InvalidOperationException>(senha.Length >= 6, "A senha deve conter pelo menos 6 caracteres");
            Contract.Requires<InvalidOperationException>(senha == confirmarSenha, "As senhas informadas não coincidem");

            this.Nome = nome;
            this.Email = email;
            this.NomeUsuario = nomeUsuario;
            this.Senha = senha;
        }
    }
}
