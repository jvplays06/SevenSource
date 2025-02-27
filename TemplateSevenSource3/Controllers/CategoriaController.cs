﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TemplateSevenSource3.Dominio;
using TemplateSevenSource3.Metodos;
using TemplateSevenSource3AcessoDados;
using TemplateSevenSource3Dominio;

namespace TemplateSevenSource3.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var metodoscategoria = new MetodosBDCATEG();
            var todascategorias = metodoscategoria.ListarCategoria();
            return View(todascategorias);
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoscategoria = new MetodosBDCATEG();
                    metodoscategoria.CadastrarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Editar(int id)
        {
            var metodoscategoria = new MetodosBDCATEG();
            var categoria = metodoscategoria.ListaId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }
        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var metodoscategoria = new MetodosBDCATEG();
                    metodoscategoria.AtualizarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Apagar(int id)
        {
            try
            {
                var metodoscategoria = new MetodosBDCATEG();
                var categoria = metodoscategoria.ListaId(id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        [HttpPost]
        public ActionResult Apagar(Categoria categoria, int id)
        {
            try
            {
                var metodoscategoria = new MetodosBDCATEG();
                metodoscategoria.DeletarCategoria(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Detalhes(int id)
        {
            try
            {
                var metodoscategoria = new MetodosBDCATEG();
                var categoria = metodoscategoria.ListaId(id);
                if (categoria == null)
                {
                    return HttpNotFound();
                }
                return View(categoria);
            }
            catch (Exception ex)
            {
                Session["erro"] = ex.Message;
                return RedirectToAction("Erro", "erro");
            }
        }
        public ActionResult Lista()
        {
            var metodoscategoria = new MetodosBDCATEG();
            var todascategorias = metodoscategoria.ListarCategoria();
            return View(todascategorias);
        }
        
    }
}