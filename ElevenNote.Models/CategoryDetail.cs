using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Create")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
        public virtual List<Note> Notes { get; set; } = new List<Note>();

    }
}
