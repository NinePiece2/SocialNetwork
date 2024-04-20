using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class PostController : Controller
    {
        private SocialNetworkEntities socialNetworkEntities = new SocialNetworkEntities();

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a way to get the current user's ID
                post.UserId = GetCurrentUserId();
                socialNetworkEntities.Posts.Add(post);
                socialNetworkEntities.SaveChanges();
                return RedirectToAction("Index", "Home"); // Adjust as needed
            }
            return View(post);
        }

        private int GetCurrentUserId()
        {
            // Implement logic to get current user's ID
            return 1; // Placeholder
        }
    }
}