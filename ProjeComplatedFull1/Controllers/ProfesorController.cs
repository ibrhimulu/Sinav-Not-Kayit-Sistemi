using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeComplatedFull1.Entities;
using ProjeComplatedFull1.Models;
using System.Security.Claims;

namespace ProjeComplatedFull1.Controllers
{
    [Authorize(Roles = "3,2")]
    public class ProfesorController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public ProfesorController(DatabaseContext databaseContext, IMapper mapper, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _configuration = configuration;

        }
        private readonly IConfiguration _configuration;

        public IActionResult Index(NotModel notModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Oturum açmış kullanıcının Id'sini Guid'e çevirir

                // Giriş yapmış kullanıcının DersId'sini alıyoruz
                var userDersId = _databaseContext.Not.FirstOrDefault(not => not.UserId == userId)?.DersId;

                if (userDersId != null)
                {
                    var sorgu = (from not in _databaseContext.Not
                                 join ders in _databaseContext.Dersler on not.DersId equals ders.DersId
                                 join uye in _databaseContext.Users on not.UserId equals uye.Id
                                 where uye.RolId == 1
                                 where uye.Locked == false // Kullanıcı adını çekmek için
                                 where not.DersId == userDersId // Aynı dersi alan kullanıcıların verilerini seçer
                                 select new NotModel
                                 {
                                     NotId = not.NotId,
                                     UserId = not.UserId, // Kullanıcının Id'sini kullanır
                                     DersId = ders.DersId,
                                     DersAd = ders.DersAd,
                                     Username = uye.Username, // Kullanıcının adını kullanır
                                     Sınav1 = not.Sınav1,
                                     Sınav2 = not.Sınav2,
                                     Sınav3 = not.Sınav3,
                                     Ortalama = Convert.ToDecimal((not.Sınav1 + not.Sınav2 + not.Sınav3) / 3),
                                     Durum = ((not.Sınav1 + not.Sınav2 + not.Sınav3) / 3) >= 50
                                 }).ToList();

                    return View(sorgu);
                }
            }

            return RedirectToAction("Login", "Account"); // Oturum açmamışsa veya ders bulunamazsa giriş sayfasına yönlendir
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateNotModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcıyı kullanıcı adına göre bulun
                var user = _databaseContext.Users.SingleOrDefault(u => u.Username == model.Username);

                // Dersi ders adına göre bulun
                var ders = _databaseContext.Dersler.SingleOrDefault(d => d.DersAd == model.DersAd);

                if (user != null && ders != null)
                {
                    // Kullanıcı ve ders bulunduysa, notu oluşturun
                    var not = new Notlar
                    {
                        UserId = user.Id,
                        DersId = ders.DersId,
                        Sınav1 = model.Sınav1,
                        Sınav2 = model.Sınav2,
                        Sınav3 = model.Sınav3,
                        Durum = model.Durum
                    };

                    _databaseContext.Not.Add(not);
                    _databaseContext.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Kullanıcı adı veya ders adı bulunamazsa hata mesajı ekleyin
                    ModelState.AddModelError("", "Kullanıcı adı veya ders adı bulunamadı.");
                }
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Notlar not = _databaseContext.Not.Find(id);
            EditNotModel model = _mapper.Map<EditNotModel>(not);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditNotModel model)
        {

            if (ModelState.IsValid)
            {


                Notlar not = _databaseContext.Not.Find(id);

                _mapper.Map(model, not);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
