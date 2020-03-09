using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Warrior.Models;
using Warrior.Repository;

namespace Warrior.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;
        private Random rnd = new Random();

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowWarrior()
        {
            var warrior = _context.Warriors.Include(w => w.Weapon).FirstOrDefault();
            return View(warrior);
        }
        public IActionResult ShowWarriors()
        {
            var warriors = _context.Warriors.Include(w => w.Weapon).ToList();
            return View(warriors);
        }
        public IActionResult ShowWeapons()
        {
            var weapons = _context.Weapons.ToList();
            return View(weapons);
        }

        public IActionResult AddWarrior()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWarrior(Warrior.Models.Warrior warrior)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("WarriorName", "Required");
                return View("AddWarrior");
            }
            var size = _context.Weapons.Count();            
            var weaponId = rnd.Next(1, size + 1);
            Weapon weapon = _context.Weapons.Skip(weaponId).FirstOrDefault();
            warrior.Weapon = weapon;
            _context.Warriors.Add(warrior);
            _context.SaveChanges();
            return View("ShowWarrior", warrior);
        }

        public IActionResult AddWeapon()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWeapon(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
            _context.SaveChanges();
            return View("AddWeapon");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
