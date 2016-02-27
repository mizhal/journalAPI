using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Journal2API.Models.Libs
{
    public class Slugify
    {
        private Regex _AnsiLetters;

        private Slugify() {
            _AnsiLetters = new Regex("[^a-zA-Z0-9\\-_]");
        }

        private static Slugify Singleton = new Slugify();

        public static Slugify GetInstance()
        {
            if (Slugify.Singleton == null)
                Slugify.Singleton = new Slugify();
            return Slugify.Singleton;
        }

        public string slugify(string unslugged)
        {
            lock (Slugify.Singleton)
            {
                return _AnsiLetters.Replace(unslugged, "-");
            }
        }

    }
}