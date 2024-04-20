using System.Web.Mvc;
using SocialNetwork.Models;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;

namespace SocialNetwork.Controllers
{
    public class UserController : Controller
    {
        private SocialNetworkEntities socialNetworkEntities = new SocialNetworkEntities();

        // GET: User/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Hash password before storing
                user.PasswordHash = HashPassword(user.PasswordHash);
                user.DateCreated = DateTime.Now;
                socialNetworkEntities.Users.Add(user);
                socialNetworkEntities.SaveChanges();
                return RedirectToAction("Index", "Home"); // Adjust as needed
            }
            return View(user);
        }

        // GET: User/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = HashPassword(model.Password);
                var user = socialNetworkEntities.Users.FirstOrDefault(u => (u.Email == model.EmailorUsername || u.Username == model.EmailorUsername) && u.PasswordHash == hashedPassword);
                if (user != null)
                {
                    // Implement session or authentication logic here
                    return RedirectToAction("Feed", "Home"); // Adjust as needed
                }
                ModelState.AddModelError("", "Invalid email/username or password");
                ViewBag.Error = "Invalid email/username or password";
            }
            return View(model);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}