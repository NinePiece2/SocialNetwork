using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class CommentController : Controller
    {
        private SocialNetworkEntities socialNetworkEntities = new SocialNetworkEntities();

        // GET: Comment/Create
        public ActionResult Create(int postId)
        {
            ViewBag.PostId = postId;
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a way to get the current user's ID
                comment.UserId = GetCurrentUserId();
                socialNetworkEntities.Comments.Add(comment);
                socialNetworkEntities.SaveChanges();
                return RedirectToAction("Index", "Home"); // Adjust as needed
            }
            ViewBag.PostId = comment.PostId;
            return View(comment);
        }

        private int GetCurrentUserId()
        {
            // Implement logic to get current user's ID
            return 1; // Placeholder
        }
    }
}