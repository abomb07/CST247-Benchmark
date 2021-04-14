using Bible.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Services
{
    public class VerseBusinessService
    {
        VerseDataService vds = new VerseDataService();

        public bool createVerse(BibleVerse bv)
        {
            return vds.createVerse(bv);
        }

        public List<BibleVerse> getAllVerses()
        {
            return vds.readAll();
        }

        public BibleVerse findVerse(BibleVerse bv)
        {
            return vds.searchVerses(bv);
        }
    }
}
