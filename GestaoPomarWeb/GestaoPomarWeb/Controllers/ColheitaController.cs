using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using GestaoPomarWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPomarWeb.Controllers
{
    public class ColheitaController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ColheitaViewModel> colheita;

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP GET
            var responseTask = client.GetAsync("colheita");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ColheitaViewModel>>();
                readTask.Wait();
                colheita = readTask.Result;
            }
            else
            {
                colheita = Enumerable.Empty<ColheitaViewModel>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }

            return View(colheita);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ColheitaViewModel colheita)
        {
            if (colheita == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP POST
            var postTask = client.PostAsJsonAsync<ColheitaViewModel>("colheita", colheita);
            postTask.Wait();

            if (postTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(colheita);
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
            var responseTask = client.GetAsync("colheita/" + id.ToString());
            responseTask.Wait();

            ColheitaViewModel colheita = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ColheitaViewModel>();
                readTask.Wait();
                colheita = readTask.Result;
            }

            return View(colheita);
        }

        [HttpPost]
        public ActionResult Edit(ColheitaViewModel colheita)
        {
            if (colheita == null)
            {
                return View();
            }
            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP PUT
            var putTask = client.PutAsJsonAsync<ColheitaViewModel>("colheita", colheita);
            putTask.Wait();

            if (putTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(colheita);
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

            ColheitaViewModel colheita = null;
            //HTTP DELETE
            var deleteTask = client.DeleteAsync("colheita/" + id.ToString());
            deleteTask.Wait();

            if (deleteTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(colheita);
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
            var responseTask = client.GetAsync("colheita/" + id.ToString());
            responseTask.Wait();

            ColheitaViewModel colheita = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ColheitaViewModel>();
                readTask.Wait();
                colheita = readTask.Result;
            }

            return View(colheita);

        }
    }
}
