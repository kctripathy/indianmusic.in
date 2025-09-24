using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Domain.ViewModels
{
    public class SearchResult
    {
        public int ID { get; set; } = 0;
        public string Model { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LinkURL { get; set; } = string.Empty;
    }
}
