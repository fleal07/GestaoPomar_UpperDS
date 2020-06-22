using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using GestaoPomarWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPomarWeb.Controllers
{
    public class ArvoresController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ArvoresViewModel> arvores;

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP GET
            var responseTask = client.GetAsync("arvores");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ArvoresViewModel>>();
                readTask.Wait();
                arvores = readTask.Result;
            }
            else
            {
                arvores = Enumerable.Empty<ArvoresViewModel>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }

            return View(arvores);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArvoresViewModel arvores)
        {
            if (arvores == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP POST
            var postTask = client.PostAsJsonAsync<ArvoresViewModel>("arvores", arvores);
            postTask.Wait();
            
            if (postTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(arvores);
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
            var responseTask = client.GetAsync("arvores/" + id.ToString());
            responseTask.Wait();

            ArvoresViewModel arvores = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ArvoresViewModel>();
                readTask.Wait();
                arvores = readTask.Result;
            }

            return View(arvores);
        }

        [HttpPost]
        public ActionResult Edit(ArvoresViewModel arvores)
        {
            if (arvores == null)
            {
                return View();
            }
            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP PUT
            var putTask = client.PutAsJsonAsync<ArvoresViewModel>("arvores", arvores);
            putTask.Wait();

            if (putTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(arvores);
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

            ArvoresViewModel arvores = null;
            //HTTP DELETE
            var deleteTask = client.DeleteAsync("arvores/" + id.ToString());
            deleteTask.Wait();

            if (deleteTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(arvores);
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
            var responseTask = client.GetAsync("arvores/" + id.ToString());
            responseTask.Wait();

            ArvoresViewModel arvores = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ArvoresViewModel>();
                readTask.Wait();
                arvores = readTask.Result;
            }

            return View(arvores);
        }
    }
}
