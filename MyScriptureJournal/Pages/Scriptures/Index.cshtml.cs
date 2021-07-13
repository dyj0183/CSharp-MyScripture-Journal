using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureName { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string Note { get; set; }

        public async Task OnGetAsync()
        {
            var scriptures = from s in _context.Scripture
                         select s;
            if (!string.IsNullOrEmpty(ScriptureName))
            {
                scriptures = scriptures.Where(s => s.ScriptureName.Contains(ScriptureName));
            }

            if (!string.IsNullOrEmpty(Note))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(Note));
            }

            Scripture = await scriptures.ToListAsync();
        }
    }
}
