using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NETCore.Encrypt.Extensions;
using ProjeComplatedFull1.Entities;
using ProjeComplatedFull1.Models;

namespace ProjeComplatedFull1.Controllers
{
    public class DersController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public DersController(DatabaseContext databaseContext, IMapper mapper, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _configuration = configuration;

        }
        private readonly IConfiguration _configuration;


        public IActionResult Index()
        {
            List<DersModel> ders =
                _databaseContext.Dersler.ToList()
                    .Select(x => _mapper.Map<DersModel>(x)).ToList();


            return View(ders);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDersModel model)
        {

            if (ModelState.IsValid)
            {

                if (_databaseContext.Dersler.Any(x => x.DersAd.ToLower() == model.DersAd.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.DersAd), "Bu ders adı zaten kullanılıyor.");
                    return View(model);
                }

                Dersler ders = _mapper.Map<Dersler>(model);

                _databaseContext.Dersler.Add(ders);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public IActionResult Edit(int id)
        {
            Dersler ders = _databaseContext.Dersler.Find(id);
            EditDersModel model = _mapper.Map<EditDersModel>(ders);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EditDersModel model)
        {

            if (ModelState.IsValid)
            {
                if (_databaseContext.Dersler.Any(x => x.DersAd.ToLower() == model.DersAd.ToLower() && x.DersId != id))
                {
                    ModelState.AddModelError(nameof(model.DersAd), "Bu ders adı zaten kullanılıyor.");
                    return View(model);
                }

                Dersler ders = _databaseContext.Dersler.Find(id);

                _mapper.Map(model, ders);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
