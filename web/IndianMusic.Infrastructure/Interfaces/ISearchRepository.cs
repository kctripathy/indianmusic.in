using IndianMusic.Domain.Models;
using IndianMusic.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Infrastructure.Interfaces
{
    public interface ISearchRepository
    {
        Task<List<SearchResult>> GetSearchResultAsync(SearchViewModel model);
    }

}
