using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Domain.ViewModels
{
    public class SearchViewModel
    {
        public string QueryText { get; set; } = string.Empty;

        public List<string> SelectedCategories { get; set; } = new List<string>();

        public List<string> AllCategories { get; set; } = new List<string> { "Artists", "Articles", "Music" };
    }

}
