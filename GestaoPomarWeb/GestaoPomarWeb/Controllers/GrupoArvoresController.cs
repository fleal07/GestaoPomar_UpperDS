using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using GestaoPomarWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPomarWeb.Controllers
{
    public class GrupoArvoresController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<GrupoArvoresViewModel> grupoarvores;

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP GET
            var responseTask = client.GetAsync("grupoarvores");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<GrupoArvoresViewModel>>();
                readTask.Wait();
                grupoarvores = readTask.Result;
            }
            else
            {
                grupoarvores = Enumerable.Empty<GrupoArvoresViewModel>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }

            return View(grupoarvores);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GrupoArvoresViewModel grupoarvores)
        {
            if (grupoarvores == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP POST
            var postTask = client.PostAsJsonAsync<GrupoArvoresViewModel>("grupoarvores", grupoarvores);
            postTask.Wait();

            if (postTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(grupoarvores);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP GET
            var responseTask = client.GetAsync("grupoarvores/" + id.ToString());
            responseTask.Wait();

            GrupoArvoresViewModel grupoarvores = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<GrupoArvoresViewModel>();
                readTask.Wait();
                grupoarvores = readTask.Result;
            }

            return View(grupoarvores);
        }

        [HttpPost]
        public ActionResult Edit(GrupoArvoresViewModel grupoarvores)
        {
            if (grupoarvores == null)
            {
                return View();
            }
            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP PUT
            var putTask = client.PutAsJsonAsync<GrupoArvoresViewModel>("grupoarvores", grupoarvores);
            putTask.Wait();

            if (putTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(grupoarvores);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            GrupoArvoresViewModel grupoarvores = null;
            //HTTP DELETE
            var deleteTask = client.DeleteAsync("grupoarvores/" + id.ToString());
            deleteTask.Wait();

            if (deleteTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(grupoarvores);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP GET
            var responseTask = client.GetAsync("grupoarvores/" + id.ToString());
            responseTask.Wait();

            GrupoArvoresViewModel grupoarvores = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<GrupoArvoresViewModel>();
                readTask.Wait();
                grupoarvores = readTask.Result;
            }

            return View(grupoarvores);
        }
    }
}
