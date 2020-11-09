using ArtMin.Application.Interfaces;
using ArtMin.Application.ViewModels;
using ArtMin.Infra.Data.Context;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;

namespace ArtMin.MVC.Controllers
{
    public class MarcacaoController : Controller
    {
        private readonly IMarcacaoAppService _marcacaoAppService;

        public MarcacaoController(IMarcacaoAppService marcacaoAppService)
        {
            _marcacaoAppService = marcacaoAppService;
        }

        // GET: Marcacao
        public ActionResult Index() => View();

        //POST: Marcacao/ObterMarcacoes
        [HttpPost]
        public ActionResult ObterMarcacoes() => Json(_marcacaoAppService.GetAll().ToList(), JsonRequestBehavior.AllowGet);

        // GET: Marcacao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marcacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marcacao/Create
        [HttpPost]
        public ActionResult Create(MarcacaoViewModel marcacaoViewModel)
        {
            try
            {
                _marcacaoAppService.Create(marcacaoViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CadastrarMarcacao(MarcacaoViewModel marcacaoViewModel)
        {
            _marcacaoAppService.Create(marcacaoViewModel);

            if (marcacaoViewModel.Resultado == true)
            {
                return Json(new { success = true, marcacaoViewModel.Mensagem }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, marcacaoViewModel.Mensagem }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Marcacao/Edit/5
        public ActionResult Edit(int id)
        {
            var marcacaoViewModel = _marcacaoAppService.GetById(id);

            return View(marcacaoViewModel);
        }

        // POST: Marcacao/Edit/5
        [HttpPost]
        public ActionResult Edit(MarcacaoViewModel marcacaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _marcacaoAppService.Edit(marcacaoViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Marcacao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marcacao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
