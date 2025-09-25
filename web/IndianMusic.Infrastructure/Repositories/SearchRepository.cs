using IndianMusic.Domain.Models;
using IndianMusic.Domain.ViewModels;
using IndianMusic.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianMusic.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IndianMusicDbContext _context;
        public SearchRepository(IndianMusicDbContext context)
        {
            _context = context;
        }
        public async Task<List<SearchResult>> GetSearchResultAsync(SearchViewModel model)
        {
            var searchResults = new List<SearchResult>();
            foreach (var item in model.SelectedCategories)
            {
                if (item == "Artist")
                {
                    var list = await _context.Artists
                        .Where(a => a.Name.ToLower().Contains(model.QueryText))
                        .Select(a => new SearchResult
                        {
                            Model = "Artist",
                            ID = a.Id,
                            Title = a.Name,
                            Description = a.Bio?? ""
                        })
                        .ToListAsync();
                    searchResults.AddRange(list);
                }
                if (item == "Articles")
                {
                    var list = await _context.Articles
                        .Where(a => a.Title.ToLower().Contains(model.QueryText))
                        .Select(a => new SearchResult
                        {
                            Model = "Article",
                            ID = a.Id,
                            Title = a.Title,
                            Description = a.Author == null? "" : a.Author.Name ?? ""
                        })
                        .ToListAsync();
                    searchResults.AddRange(list);
                }

            }

            return await Task.FromResult(searchResults);
        }
    }
}
