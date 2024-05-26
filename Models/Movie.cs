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
    public class Movie : INotifyPropertyChanged
    {
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

        public string? Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Description));
            }
        }
        private string _description;

        public string? Review
        {
            get
            {
                return _review;
            }
            set
            {
                _review = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Review));
            }
        }
        private string _review;

        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Rating));
            }
        }
        private int _rating;

        public Movie()
        {
            Title = string.Empty;
            Category = EMovieCategory.Brak;
            Description = string.Empty;
            Review = string.Empty;
            Rating = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
