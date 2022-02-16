using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        { 
            ViewBag.AllWomensLeagues = _context.Leagues
                .Where(w => w.Name.Contains("Women"))
                .ToList();

            ViewBag.AllHockeyLeagues = _context.Leagues
                .Where(h => h.Sport.Contains("Hockey"))
                .ToList();
                
            ViewBag.AllNonFootballLeagues = _context.Leagues
                .Where(f => !f.Sport.Contains("Football"))
                .ToList();

            ViewBag.AllConference = _context.Leagues
                .Where(co => co.Name.Contains("Conference"))
                .ToList();

            ViewBag.AllAtlanticRegionLeagues = _context.Leagues
                .Where(a => a.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.AllDallasBasedTeams = _context.Teams
                .Where(d => d.Location.Contains("Dallas"))
                .ToList();

            ViewBag.AllTeamsNamedRaptors = _context.Teams
                .Where(r => r.TeamName.Contains("Raptors"))
                .ToList();

            ViewBag.TeamsWithCity = _context.Teams
                .Where(ci => ci.Location.Contains("City"))
                .ToList();

            ViewBag.TeamsWithNameT = _context.Teams
                .Where(t => t.TeamName.StartsWith("t"))
                .ToList();
            
            ViewBag.TeamsLocationAlphabetical = _context.Teams
                .OrderBy(lo => lo.Location)
                .ToList();
            
            ViewBag.TeamsReverseAlphabetical = _context.Teams
                .OrderByDescending(rt => rt.TeamName)
                .ToList();
            
            ViewBag.PlayerLastNameCooper = _context.Players
                .Where(pco => pco.LastName.Contains("Cooper"))
                .ToList();
            
            ViewBag.PlayerFirstNameJoshua = _context.Players
                .Where(pjo => pjo.FirstName.Contains("Joshua"))
                .ToList();
            
            ViewBag.LastNameCooperWithoutJoshua = _context.Players
                .Where(pco => pco.LastName.Contains("Cooper"))
                .Where(pjo => !pjo.FirstName.Contains("Joshua"))
                .ToList();            
            
            ViewBag.FirstNameAlexanderOrWyatt = _context.Players
                .Where(pa => pa.FirstName.Contains("Alexander") 
                || pa.FirstName.Contains("Wyatt"))
                .OrderBy(p => p.LastName)
                .OrderBy(p => p.FirstName)
                .ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}