using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CatalogoMvc.Dominio.Testes
{
    [TestClass]
    public class Dado_um_novo_usuario
    {
        [TestMethod]
        [TestCategory("Novo usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_nome()
        {
            var usuario = new Usuario("", "rael@gmail.com", "neguinho", "neguinho");
        }

        [TestMethod]
        [TestCategory("Novo usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_email()
        {
            var usuario = new Usuario("rael", "", "neguinho", "neguinho");
        }

        [TestMethod]
        [TestCategory("Novo usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_nomeusuario()
        {
            var usuario = new Usuario("rael", "rael@gmail.com", "", "neguinho");
        }


        [TestMethod]
        [TestCategory("Novo usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_usuario_deve_conter_um_senha()
        {
            var usuario = new Usuario("rael", "rael@gmail.com", "neguinho", "");
        }
    }

    [TestClass]
    public class Ao_alterar_o_email
    {
        [TestMethod]
        [TestCategory("Alterar E-mail")]
        [ExpectedException(typeof(Exception))]
        public void o_novo_email_deve_ser_valido()
        {
            var usuario = new Usuario("Rael", "rael@gmail.com", "rael santos", "neguinho");
            usuario.AlterarEmail("nada");
        }
    }


    [TestClass]
    public class Ao_alterar_a_senha
    {
        [TestMethod]
        [TestCategory("Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void o_usuario_e_senha_devem_ser_validos()
        {
            var usuario = new Usuario("Rael", "rael@gmail.com", "rael santos", "neguinho");
            usuario.AlterarSenha("nada", "nada", "123456", "123456");
        }

        [TestMethod]
        [TestCategory("Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void a_nova_senha_deve_ser_diferente_da_atual()
        {
            var usuario = new Usuario("Rael", "rael@gmail.com", "rael santos", "neguinho");
            usuario.AlterarSenha("rael santos", "neguinho", "123456", "123456");
        }
    }
}
