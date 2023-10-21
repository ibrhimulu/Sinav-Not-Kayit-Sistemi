using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjeComplatedFull1.Entities;
using ProjeComplatedFull1.Models;
using System.Security.Claims;

namespace ProjeComplatedFull1.Controllers
{
    [Authorize(Roles = "1,2")]
    public class OgrenciController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public OgrenciController(DatabaseContext databaseContext, IMapper mapper, IConfiguration configuration)
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

                var sorgu = (from not in _databaseContext.Not
                             join ders in _databaseContext.Dersler on not.DersId equals ders.DersId
                             where not.UserId == userId // Sadece giriş yapmış kullanıcının verilerini seçer
                             select new NotModel
                             {
                                 NotId = not.NotId,
                                 UserId = userId, // Kullanıcının Id'sini Guid olarak kullanır
                                 DersId = ders.DersId,
                                 DersAd = ders.DersAd,
                                 Username = User.Identity.Name, // Kullanıcının adını kullanır
                                 Sınav1 = not.Sınav1,
                                 Sınav2 = not.Sınav2,
                                 Sınav3 = not.Sınav3,
                                 Ortalama = Convert.ToDecimal((not.Sınav1 + not.Sınav2 + not.Sınav3) / 3),
                                 Durum = not.Durum
                             }).ToList();

                return View(sorgu);
            }
            else
            {
                return RedirectToAction("Login", "Account"); // Oturum açmamışsa giriş sayfasına yönlendir
            }
        }
    }
}
