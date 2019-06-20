using CatalogoMvc.Dominio;
using CatalogoMvc.Dominio.Repositorios;
using CatalogoMvc.Web.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CatalogoMvc.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioController(IUsuarioRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }

        public ActionResult Index()
        {
            return View(_repositorio.Get());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EditarUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // ModelState.AddModelError("ErroDefault", Teste(ViewData.ModelState).ToString());
                ModelState.AddModelError("ErroDefault", "Testesssssssssssss");

                return View(model);
            }             

            try
            {
                var usuario = new Usuario(model.Nome, model.Email, model.NomeUsuario, model.Senha);
                usuario.Registrar(model.Nome, model.Email, model.NomeUsuario, model.Senha, model.ConfirmaSenha);
                _repositorio.SaveOrUpdate(usuario);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ErroDefault", ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return HttpNotFound();

            var usuario = _repositorio.Get(id);

            if (usuario == null)
                return HttpNotFound();

            return View(new EditarUsuarioViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                ConfirmaSenha = "",
                Senha = ""
            });
        }

        [HttpPost]
        public ActionResult Edit(EditarUsuarioViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var usuario = _repositorio.Get(model.Id);
                usuario.AlterarInfo(model.Nome, model.Email, model.NomeUsuario, model.Senha, model.ConfirmaSenha);
                _repositorio.SaveOrUpdate(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ErroDefault", ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(_repositorio.Get(id));
        }

        public ActionResult Delete(int id)
        {
            return View(_repositorio.Get(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                _repositorio.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ErroDefault", ex.Message);
                return View(_repositorio.Get(id));
            }
        }

        protected override void Dispose(bool disposing)
        {
            _repositorio.Dispose();
        }

              

        public string[] Teste(ModelStateDictionary model_stateS)
        {
            string[] s = new string[]{ };

            foreach (ModelState modelstate in model_stateS.Values)
            {
                foreach (ModelError modelerror in modelstate.Errors)
                {
                    //for (int i = 0; i < modelstate.Errors.Count; i++)
                    //{
                        s[0] = modelerror.ErrorMessage;
                    //}
                }
            }

            return s;
        }
    }
}