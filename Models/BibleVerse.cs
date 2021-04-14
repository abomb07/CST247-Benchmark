using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Models
{
    public class BibleVerse
    {
        [Required]
        public string testament { get; set; }
        [Required]
        public string book { get; set; }
        [Required]
        public int chapter { get; set; }
        [Required]
        public int verse { get; set; }
        [Required]
        public string text { get; set; }

        public BibleVerse(string testament, string book, int chapter, int verse, string text)
        {
            this.testament = testament;
            this.book = book;
            this.chapter = chapter;
            this.verse = verse;
            this.text = text;
        }

        public BibleVerse()
        {
            
        }
    }
}
