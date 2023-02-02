using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppConcept.Models;

namespace LibraryAppConcept.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        private List<Client> clients = new List<Client>
        {
            new Client(1,"Kristijan", 21, "4552")
        };

        // GET: Client
        public ActionResult Index()
        {
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                clients.Add(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client client)
        {
            if (id != client.Id)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                Client clientToUpdate = clients.FirstOrDefault(c => c.Id == id);
                if (clientToUpdate != null)
                {
                    clientToUpdate.Name = client.Name;
                    clientToUpdate.Age = client.Age;
                    clientToUpdate.LibraryId = client.LibraryId;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
            {
                clients.Remove(client);
            }
            return RedirectToAction("Index");
        }
    }
    }