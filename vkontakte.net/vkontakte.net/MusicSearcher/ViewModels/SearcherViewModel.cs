// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearcherViewModel.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MusicSearcher
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    using VKontakteNet;

    using vkontakte.net;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SearcherViewModel : ViewModelBase
    {
        /// <summary>
        /// Адаптер контакта
        /// </summary>
        private readonly IAudioAdapter _adapter;

        /// <summary>
        /// Результат поиска
        /// </summary>
        private AudioCollectionViewModel _searchResult;

        /// <summary>
        /// Признак возможности поиска
        /// </summary>
        private bool _canSearch;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="adapter">Адаптер контакта</param>
        public SearcherViewModel(IAudioAdapter adapter)
        {
            _adapter = adapter;

            OptionImage = new DoubleImageViewModel(Resources.OpenSettingsImage, Resources.CloseTextImage);

            SearchResult = new AudioCollectionViewModel(_adapter.GetUserAudio(), adapter);

            SearchOptions = new AudioSearchOptions();

            CanSearch = true;

            OnPropertyChanged("EmptySearchResult");

            OnPropertyChanged("FullSearchResult");
        }

        #region - Свойства -

        public DoubleImageViewModel OptionImage { get; set; }

        public AudioSearchOptions SearchOptions { get; set; }
        
        public AudioCollectionViewModel SearchResult
        {
            get
            {
                return _searchResult;
            }
            set
            {
                _searchResult = value;

                OnPropertyChanged("SearchResult");
            }
        }

        public bool EmptySearchResult
        {
            get
            {
                return SearchResult.Count == 0;
            }
        }

        public bool FullSearchResult
        {
            get
            {
                return !EmptySearchResult;
            }
        }

        public bool CanSearch
        {
            get
            {
                return _canSearch;
            }

            set
            {
                _canSearch = value;

                this.OnPropertyChanged("CanSearch");
            }
        }

        public string SearchRequest
        {
            set
            {
                SearchOptions.Request = value;
            }
        }

        public string AudioLimit
        {
            get 
            { 
                return SearchOptions.Limit.ToString();
            }

            set 
            { 
                var limit = 0;
                
                if (int.TryParse(value, out limit))
                {
                    SearchOptions.Limit = limit;
                }
            }
        }

        public int AudioSorting
        {
            get { return (int)SearchOptions.Sorting; }
            set { SearchOptions.Sorting = (AudioSorting) value; }
        }

        #endregion

        #region - Комадны -

        /// <summary>
        /// Gets Sets
        /// Команда поиска аудиозаписей
        /// </summary>
        public ImageCommand SearchCommand
        {
            get
            {
                return new ImageCommand(() =>
                {
                    if (SearchOptions.Request == null)
                    {
                        throw new Exception("Request is null.");
                    }

                    CanSearch = false;

                    var audios = new Audio[0];

                    var lyrics = new Lyrics[0];

                    var worker = new BackgroundWorker();

                    worker.DoWork += (sender, e) =>
                    {
                        audios = _adapter.Search(SearchOptions);

                        if (SearchOptions.SearchLyrics)
                        {
                            lyrics = audios.Select(audio => _adapter.GetLyrics(audio.LyricsId)).ToArray();
                        }
                    };

                    worker.RunWorkerCompleted += (sender, e) =>
                        {
                            if (SearchResult != null)
                            {
                                SearchResult.Stop();
                            }

                            SearchResult = SearchOptions.SearchLyrics ? 
                                new AudioCollectionViewModel(audios, lyrics, _adapter) : 
                                new AudioCollectionViewModel(audios, _adapter);

                            CanSearch = true;

                            this.OnPropertyChanged("SearchResult");
                            OnPropertyChanged("EmptySearchResult");
                            OnPropertyChanged("FullSearchResult");                             
                        };

                    worker.RunWorkerAsync();
                }, 
                Resources.SearchImage);
            }
        }

        public RelayCommand OptionsCommand
        {
            get
            {
                return new RelayCommand(() => OptionImage.Change());
            }
        }

        #endregion
    }
}
