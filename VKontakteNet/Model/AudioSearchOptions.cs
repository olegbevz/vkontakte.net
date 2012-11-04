using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VKontakteNet
{
    public class AudioSearchOptions
    {
        public AudioSearchOptions()
        {
            AutoComplete = true;

            Sorting = AudioSorting.ByFamous;

            Limit = 100;
        }

        public string Request { get; set; }
        
        public bool AutoComplete { get; set; }

        public bool SearchLyrics { get; set; }

        public AudioSorting Sorting { get; set; }

        public string SearchCount { get; set; }

        public int Limit { get; set; }
    }
}
