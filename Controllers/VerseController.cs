using Bible.Models;
using Bible.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Controllers
{
    public class VerseController : Controller
    {
        public IActionResult Index()
        {
            VerseBusinessService vbs = new VerseBusinessService();
            List<BibleVerse> verses = vbs.getAllVerses();

            return View("Views/Verse/Index.cshtml", verses);
        }

        public IActionResult VerseForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVerse(BibleVerse bv)
        {
            VerseBusinessService vbs = new VerseBusinessService();

            if(vbs.createVerse(bv))
            {
                return Index();
            }
            else
            {
                ErrorViewModel ev = new ErrorViewModel();
                ev.RequestId = "Verse creation failed";
                return View("Views/Shared/Error.cshtml", ev);
            }
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindVerse(BibleVerse bv)
        {
            VerseBusinessService vbs = new VerseBusinessService();

            if(vbs.findVerse(bv) == null)
            {
                ErrorViewModel ev = new ErrorViewModel();
                ev.RequestId = "No verse found";
                return View("Views/Shared/Error.cshtml", ev);
            }
            else
            {
                BibleVerse bibleV = vbs.findVerse(bv);
                return View("Views/Verse/SearchResults.cshtml", bibleV);
            }
        }
    }
}
