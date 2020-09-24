using ArtMin.Application.Interfaces;
using ArtMin.Application.ViewModels;
using System;
using System.Web.Mvc;

namespace ArtMin.MVC.Controllers
{
    public class JogadorController : Controller
    {
        private readonly IJogadorAppService _jogadorAppService;

        public JogadorController(IJogadorAppService jogadorAppService)
        {
            _jogadorAppService = jogadorAppService;
        }

        // GET: Jogador
        public ActionResult Index()
        {
            var jogadorViewModel = _jogadorAppService.GetAll();
            return View(jogadorViewModel);
        }

        public JsonResult GetAll() => 
            Json(_jogadorAppService.GetAll(), JsonRequestBehavior.AllowGet);

        // GET: Jogador/Details/5
        public ActionResult Details(int id)
        {
            var jogador = _jogadorAppService.GetById(id);
            return View(jogador);
        }

        // GET: Jogador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogador/Create
        [HttpPost]
        public ActionResult Create(JogadorViewModel jogadorViewModel)
        {
            if (ModelState.IsValid)
            {
                _jogadorAppService.Create(jogadorViewModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult CadastrarJogador(JogadorViewModel jogadorViewModel)
        {
            _jogadorAppService.Create(jogadorViewModel);

            return Json(jogadorViewModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Jogador/Edit/5
        public ActionResult Edit(int id)
        {
            var jogadorViewModel = _jogadorAppService.GetById(id);

            return View(jogadorViewModel);
        }

        // POST: Jogador/Edit/5
        [HttpPost]
        public ActionResult Edit(JogadorViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _jogadorAppService.Edit(viewModel);

                    return RedirectToAction("Index");
                }

                return View(viewModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        // GET: Jogador/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _jogadorAppService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public ActionResult RemoverJogador(int id)
        {
            _jogadorAppService.Delete(id);

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}
