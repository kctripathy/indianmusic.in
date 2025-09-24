using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;

namespace IndianMusic.Application.Services
{
    public class TranslationService
    {
        private readonly TranslationClient _client;

        public TranslationService(string apiKey)
        {
            _client = TranslationClient.CreateFromApiKey(apiKey);
        }

        public string TranslateText(string text, string targetLanguage = "hi")
        {

            //string name = "Hari Prasad Chaurasia";
            var response1 = _client.TranslateText(
                text: text,
                targetLanguage: targetLanguage,
                sourceLanguage: "en"
            );

            //Console.WriteLine(response1.TranslatedText);
            //var response = _client.TranslateText(text, targetLanguage);
            return response1.TranslatedText;
        }
    }
}
