using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using ProjeComplatedFull1.Entities;
using ProjeComplatedFull1.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;

namespace ProjeComplatedFull1.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;

        public AccountController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = DoMD5HashedString(model.Password);

                User user = _databaseContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                && x.Password == hashedPassword);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.Username), "Kullanıcı kilitli.");
                        return View(model);

                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.NameSurname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.RolId.ToString()));

                    claims.Add(new Claim("Username", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); /*yani "Cookie"*/

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Öğrenci no veya şifre yanlış.");
                }

            }
            return View(model);
        }

        private string DoMD5HashedString(string s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = s + md5Salt;    /*şifreye indirdiğim metodu (md5) ekledim   */
            string hashed = salted.MD5();        /*database hashed olarak yazdırdım (şifrelenmiş hali)*/
            return hashed;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Kullanıcı zaten kayıtlı");
                    View(model);
                }

                string hashedPassword = DoMD5HashedString(model.Password);

                User user = new()
                {
                    Username = model.Username,
                    Password = hashedPassword,
                    RolId = 1,
                    ProfileImageFile = "no-image.jpg"
                };

                _databaseContext.Users.Add(user);
                int affectedRowCount = _databaseContext.SaveChanges(); /*etkilenen satır sayısı*/

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Bu kullanıcı eklenemez.");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }

            }
            return View(model);
        }

        public IActionResult Profile()
        {
            ProfileInfoLoader();

            return View();
        }

        private void ProfileInfoLoader()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

            ViewData["NameSurname"] = user.NameSurname;
            ViewData["ProfileImage"] = user.ProfileImageFile;
        }

        [HttpPost]
        public IActionResult ProfilChangeNameSurname([Required][StringLength(50)] string? namesurname)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

                User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

                user.NameSurname = namesurname;
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }

            ProfileInfoLoader();
            return View("Profile");
        }

        [HttpPost]
        public IActionResult ProfilChangePassword([Required][MinLength(6)][MaxLength(6)] string? password)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

                User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

                string hashedPassword = DoMD5HashedString(password);

                user.Password = hashedPassword;
                _databaseContext.SaveChanges();

                ViewData["result"] = "PasswordChanged";
            }

            ProfileInfoLoader();
            return View("Profile");
        }


        [HttpPost]
        public IActionResult ProfilChangeImage([Required] IFormFile file)
        {
            if (ModelState.IsValid)
            {

                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);


                string filename = $"p_{userid}.jpg";
                Stream stream = new FileStream($"wwwroot/uploads/{filename}", FileMode.OpenOrCreate);

                file.CopyTo(stream);

                stream.Close();
                stream.Dispose();

                user.ProfileImageFile = filename;
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }

            ProfileInfoLoader();
            return View("Profile");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
