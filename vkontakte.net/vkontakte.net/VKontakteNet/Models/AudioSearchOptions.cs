// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioSearchOptions.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the AudioSearchOptions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace vkontakte.net.Models
{
    using vkontakte.net;

    public class AudioSearchOptions
    {
        public AudioSearchOptions()
        {
            this.AutoComplete = true;

            this.Sorting = AudioSorting.ByFamous;

            this.Limit = 100;
        }

        public string Request { get; set; }
        
        public bool AutoComplete { get; set; }

        public bool SearchLyrics { get; set; }

        public AudioSorting Sorting { get; set; }

        public string SearchCount { get; set; }

        public int Limit { get; set; }
    }
}
