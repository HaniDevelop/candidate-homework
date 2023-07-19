using _3.BonusChallenge.Business_Logic;
using _3.BonusChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3.BonusChallenge.Controllers
{
    public class AnagramListController : Controller
    {
        AnagramListLogic anagramListLogic = new AnagramListLogic();

        // GET: AnagramList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SimpleAnagramsList()
        {
            
            AnagramList simple = new AnagramList();
            simple.Output = anagramListLogic.GetSimpleOutput();
            return View(simple);
        }

        public ActionResult HarderAnagramsList()
        {
            AnagramList harder = new AnagramList();
            harder.Output = anagramListLogic.GetHarderOutput();
            return View(harder);
        }

    }
}