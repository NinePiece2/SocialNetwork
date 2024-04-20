using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class MessageController : Controller
    {
        private SocialNetworkEntities socialNetworkEntities = new SocialNetworkEntities();

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a way to get the current user's ID
                message.SenderId = GetCurrentUserId();
                socialNetworkEntities.Messages.Add(message);
                socialNetworkEntities.SaveChanges();
                return RedirectToAction("Index", "Home"); // Adjust as needed
            }
            return View(message);
        }

        private int GetCurrentUserId()
        {
            // Implement logic to get current user's ID
            return 1; // Placeholder
        }
    }
}