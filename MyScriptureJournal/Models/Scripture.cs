using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Scripture Name")]
        public string ScriptureName { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string Note { get; set; }
    }
}
