using Newtonsoft.Json;
using Notatnik_Kinomana_v2.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik_Kinomana_v2.Models
{
    public class Premiere : INotifyPropertyChanged
    {
        [JsonProperty("Title")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _title;

        [JsonProperty("Category")]
        public EMovieCategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Category));
            }
        }
        private EMovieCategory _category;

        [JsonProperty("Date")]
        public DateTime PremiereDate
        {
            get
            {
                return _premiereDate;
            }
            set
            {
                _premiereDate = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(PremiereDate));
            }
        }
        private DateTime _premiereDate;

        [JsonProperty("Watched")]
        public bool AlreadyWatched
        {
            get
            {
                return _alreadyWatched;
            }
            set
            {
                _alreadyWatched = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(AlreadyWatched));
            }
        }
        private bool _alreadyWatched;


        public Premiere()
        {
            Title = string.Empty;
            Category = EMovieCategory.Brak;
            PremiereDate = DateTime.Now.Date;
            AlreadyWatched = false;
        }

        public Premiere(string title, EMovieCategory category, DateTime date, bool watched)
        {
            Title = title;
            Category = category;
            PremiereDate = date;
            AlreadyWatched = watched;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
