using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NETCore.Encrypt.Extensions;
using ProjeComplatedFull1.Entities;
using ProjeComplatedFull1.Models;

namespace ProjeComplatedFull1.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext databaseContext, IMapper mapper, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _configuration = configuration;

        }
        private readonly IConfiguration _configuration;


        public IActionResult Index()
        {
            List<UserModel> users =
                _databaseContext.Users.ToList()
                    .Select(x => _mapper.Map<UserModel>(x)).ToList();


            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {

            if (ModelState.IsValid)
            {

                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Bu kullanıcı adı zaten kullanılıyor.");
                    return View(model);
                }

                User user = _mapper.Map<User>(model);
                string hashedPassword = DoMD5HashedString(model.Password);
                user.Password = hashedPassword;
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
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

        public IActionResult Edit(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EditUserModel model)
        {

            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Bu kullanıcı adı zaten kullanılıyor.");
                    return View(model);
                }

                User user = _databaseContext.Users.Find(id);

                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


    }
}
