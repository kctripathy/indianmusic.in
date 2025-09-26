using IndianMusic.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace IndianMusic.WebApp.TagHelpers
{
    [HtmlTargetElement("quotes-carousel")]
    public class QuotesCarouselTagHelper : TagHelper
    {
        public int Interval { get; set; } = 5000;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //TODO: CACHE THIS 
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "quotes.json");
            var json = await System.IO.File.ReadAllTextAsync(filePath);
            var quotes = JsonSerializer.Deserialize<List<MusicQuote>>(json) ?? new();

            var jsonQuotes = JsonSerializer.Serialize(quotes);

            output.TagName = "div";
            output.Attributes.SetAttribute("id", "quoteCarousel");
            output.Attributes.SetAttribute("class", "of-the-day-card");
            
            output.AddClass("quote-carousel", HtmlEncoder.Default);

            output.Content.SetHtmlContent($@"
                <p class='quote-title'></p>
                <p class='quote-author'></p>
                <div class='divider-line'></div>
                <p class='quote-desc'></p>
                <script>
                    (function(){{
                        const carousel = document.getElementById('quoteCarousel');
                        if (!carousel) return;

                        const titleEl = carousel.querySelector('.quote-title');
                        const descEl = carousel.querySelector('.quote-desc');
                        const authorEl = carousel.querySelector('.quote-author');
                        if (!titleEl || !descEl || !authorEl) return;

                        const quotes = {jsonQuotes};
                        let currentIndex = 0;

                        function showQuote(index){{
                            const quote = quotes[index];
                            titleEl.textContent = quote.quote_title;
                            descEl.textContent = quote.quote_desc;
                            authorEl.textContent = ""— "" + quote.quote_by;
                            carousel.classList.add('quote-active');

                            setTimeout(() => {{
                                carousel.classList.remove('quote-active');
                            }}, {Interval - 1000});
                        }}

                        function startCarousel(){{
                            showQuote(currentIndex);
                            setInterval(() => {{
                                currentIndex = (currentIndex + 1) % quotes.length;
                                showQuote(currentIndex);
                            }}, {Interval});
                        }}

                        document.addEventListener('DOMContentLoaded', startCarousel);
                    }})();
                </script>
                <style>
                    .quote-carousel {{
                        color: #f8f9fa;
                        padding: 2rem;
                        margin: 0rem auto;
                        border-radius: 12px;
                        max-width: 800px;
                        font-family: 'Georgia', serif;
                        box-shadow: 0 4px 15px rgba(0,0,0,0.3);
                        text-align: center;
                        min-height: 300px;
                        position: relative;
                    }}
                    .quote-title {{
                        color: var(--hightlight-color);
                        font-size: 1.3rem;
                        font-weight: bold;
                        margin-bottom: 0.5rem;
                        opacity: 0;
                        transition: opacity 1s ease-in-out;
                    }}
                    .quote-desc {{
                        font-size: 0.9rem;
                        margin-bottom: 0.5rem;
                        color: #808080; 
                        transition: opacity 1s ease-in-out;
                    }}
                    .quote-author {{
                        font-size: 1.1rem;
                        color: #adb5bd;
                        opacity: 0;
                        transition: opacity 1s ease-in-out;
                        margin-bottom: 5px;
                    }}
                    .quote-active .quote-title,
                    .quote-active .quote-desc,
                    .quote-active .quote-author {{
                        opacity: 1;
                    }}
                </style>
            ");
        }
    }
}
