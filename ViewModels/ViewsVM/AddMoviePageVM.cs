using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Notatnik_Kinomana_v2.Helpers;
using Notatnik_Kinomana_v2.Models;

namespace Notatnik_Kinomana_v2.ViewModels.ViewsVM
{
    public class AddMoviePageVM : INotifyPropertyChanged
    {
        public Movie Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                _movie = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(Movie));
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(IsCategorySelected));
            }
        }
        private Movie _movie;

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
                OnPropertyChanged(nameof(IsTitleEmpty));
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
                OnPropertyChanged(nameof(IsCategorySelected));
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



        public bool IsTitleEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                    return true;
                return false;
            }
        }

        public bool IsCategorySelected
        {
            get
            {
                if (Category == EMovieCategory.Brak)
                    return true;
                return false;
            }
        }
        public AddMoviePageVM()
        {
            Movie = new Movie();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
