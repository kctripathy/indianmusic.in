using System.ComponentModel;

namespace IndianMusic.Application
{
    public enum MusicGenre
    {
        [Description("Hindustani Classical")]
        Hindustani,

        [Description("Carnatic Classical")]
        Carnatic,

        [Description("Odissi Music")]
        Odissi,

        [Description("Film Music")]
        Film
    }

    // Usage:
    //var genre = MusicGenre.Odissi;
    //Console.WriteLine(genre.GetDescription()); // "Odissi Music"


    //public static class MusicGenres
    //{
    //    public const string Hindustani = "hindustani-classical";
    //    public const string Carnatic = "carnatic-classical";
    //    public const string Odissi = "odissi-music";
    //    public const string Film = "film-music";
    //}

    // use
    //string genre = MusicGenres.Odissi;
}
