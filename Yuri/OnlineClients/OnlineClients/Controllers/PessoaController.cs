using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClients.Models;

namespace OnlineClients.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ufnprojeto2019Context _context;

        public PessoaController(ufnprojeto2019Context context)
        {
            _context = context;
        }

        // GET: Pessoa
        [HttpGet]
        public ActionResult Index()
        {
            var pessoas = _context.Pessoa.ToList();
            return View(pessoas);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = _context.Pessoa.First(c => c.Idpessoa == id);
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                // TODO: Add insert logic here

                pessoa.Idusuario = 1;

                _context.Pessoa.Add(pessoa);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = _context.Pessoa.First(c => c.Idpessoa == id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}