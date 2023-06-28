using DogGo.Models.ViewModels;
using DogGo.Models;
using DogGo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DogGo.Controllers
{
    public class WalksController : Controller
    {
        private readonly IOwnerRepository _ownerRepo;
        private readonly IDogRepository _dogRepo;
        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;
        private readonly INeighborhoodRepository _neighborhoodRepo;

        public WalksController(
        IOwnerRepository ownerRepository,
        IDogRepository dogRepository,
        IWalkerRepository walkerRepository,
        IWalkRepository walkRepository,
        INeighborhoodRepository neighborhoodRepository)
        {
            _ownerRepo = ownerRepository;
            _dogRepo = dogRepository;
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
            _neighborhoodRepo = neighborhoodRepository;
        }

        // GET: WalksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WalksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalksController/Create
        public ActionResult Create(int id)
        {
            List<Dog> dogs = _dogRepo.GetAllDogs();
            List<Walker> walkers = _walkerRepo.GetAllWalkers();

            WalkFormViewModel vm = new WalkFormViewModel()
            {
                Walk = new Walk(),
                Dogs = dogs,
                Walkers = walkers,
                SelectedDogIds = new List<int>()
            };

            // Proper date format for the date picker
            vm.Walk.Date = DateTime.Now;

            // Default walkerId to id from walker details
            vm.Walk.WalkerId = id;

            return View(vm);
        }

        // POST: WalksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Walk walk, List<int> SelectedDogIds)
        {
            try
            {
                walk.StatusId = 1;

                _walkRepo.AddWalk(walk, SelectedDogIds);

                return RedirectToAction("Details", "Walkers", new { id = walk.WalkerId });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Walkers");
            }
        }

        // GET: WalksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalksController/Delete/5
        public ActionResult Delete(int id)
        {
            List<Walk> walk = _walkRepo.GetWalksByWalkerId(id);

            DeleteWalksViewModel vm = new DeleteWalksViewModel()
            {
                Walks = walk,
                SelectedWalkIds = new List<int>()
            };

            return View(vm);
        }

        // POST: WalksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, List<int> SelectedWalkIds)
        {
            try
            {
                _walkRepo.DeleteWalk(SelectedWalkIds);

                return RedirectToAction($"Details", "Walkers", new { id = id });
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
