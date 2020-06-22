using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestaoPomarWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoPomarWeb.Controllers
{
    public class EspeciesController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<EspeciesViewModel> especies;

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP GET
            var responseTask = client.GetAsync("especies");
            responseTask.Wait();
            var result = responseTask.Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EspeciesViewModel>>();
                readTask.Wait();
                especies = readTask.Result;
            }
            else
            {
                especies = Enumerable.Empty<EspeciesViewModel>();
                ModelState.AddModelError(string.Empty, "Erro no servidor. Contate o Administrador.");
            }

            return View(especies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EspeciesViewModel especies)
        {
            if (especies == null)
            {
                return NotFound();
            }

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP POST
            var postTask = client.PostAsJsonAsync<EspeciesViewModel>("especies", especies);
            postTask.Wait();

            if (postTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Erro no Servidor. Contacte o Administrador.");
            return View(especies);
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
            var responseTask = client.GetAsync("especies/" + id.ToString());
            responseTask.Wait();

            EspeciesViewModel especies = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EspeciesViewModel>();
                readTask.Wait();
                especies = readTask.Result;
            }

            return View(especies);
        }

        [HttpPost]
        public ActionResult Edit(EspeciesViewModel especies)
        {
            if (especies == null)
            {
                return View();
            }
            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/api/")
            };

            //HTTP PUT
            var putTask = client.PutAsJsonAsync<EspeciesViewModel>("especies", especies);
            putTask.Wait();

            if (putTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(especies);
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

            EspeciesViewModel especies = null;
            //HTTP DELETE
            var deleteTask = client.DeleteAsync("especies/" + id.ToString());
            deleteTask.Wait();

            if (deleteTask.Result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(especies);
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
            var responseTask = client.GetAsync("especies/" + id.ToString());
            responseTask.Wait();

            EspeciesViewModel especies = null;

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EspeciesViewModel>();
                readTask.Wait();
                especies = readTask.Result;
            }

            return View(especies);
        }
    }
}
