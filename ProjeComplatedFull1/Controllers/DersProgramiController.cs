//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using ProjeComplatedFull1.Entities;
//using ProjeComplatedFull1.Models;
//using System.Security.Claims;

//namespace ProjeComplatedFull1.Controllers
//{
//    [Authorize] // Sadece oturum açmış kullanıcıların erişimine izin verir
//    public class DersProgramiController : Controller
//    {
//        private readonly DatabaseContext _databaseContext; // DatabaseContext sınıfınıza göre isimlendirilmiş

//        public DersProgramiController(DatabaseContext databaseContext)
//        {
//            _databaseContext = databaseContext;
//        }

//        public IActionResult Index()
//        {
//            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)); // Kullanıcının Id'sini çekin

//            // Kullanıcının not aldığı dersleri çekin (örneğin, Sınav1, Sınav2 veya Sınav3 değeri varsa)
//            var userCourses = _databaseContext.Not
//                .Where(n => n.UserId == userId && (n.Sınav1 != null || n.Sınav2 != null || n.Sınav3 != null))
//                .ToList();

//            if (userCourses.Count == 0)
//            {
//                return View("Hata"); // Kullanıcının not aldığı ders yoksa hata sayfasına yönlendir
//            }

//            // Rastgele bir ders seçin
//            var random = new Random();
//            var randomCourse = userCourses[random.Next(userCourses.Count)];

//            // Ders programını oluşturun
//            var dersProgrami = new NotModel
//            {
//                UserId = userId,
//                DersId = randomCourse.DersId,
//                DersAd = randomCourse.DersAd,
//                // Diğer ders programı bilgilerini burada doldurun
//            };

//            // Ders programı bilgilerini not kaydına ekleyin
//            randomCourse.DersProgramiId = 1; // Ders programının kimliğini ekleyin (istediğiniz bir değeri kullanabilirsiniz)

//            // Değişiklikleri veritabanına kaydedin
//            _databaseContext.SaveChanges();

//            return RedirectToAction("Index", "DersProgramlari"); // Ders programlarının listelendiği sayfaya yönlendir
//        }
//    }
//}
