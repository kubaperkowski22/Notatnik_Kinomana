using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
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

        public string MovieTitle
        {
            get
            {
                return Movie.Title;
            }
            set
            {
                Movie.Title = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(MovieTitle));
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(IsSaveBtnEnabled));
            }
        }
        private string _title;

        public EMovieCategory MovieCategory
        {
            get
            {
                return Movie.Category;
            }
            set
            {
                Movie.Category = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(MovieCategory));
                OnPropertyChanged(nameof(IsCategorySelected));
                OnPropertyChanged(nameof(IsSaveBtnEnabled));
            }
        }
        private EMovieCategory _category;

        public ObservableCollection<Movie> Movies { get; set; }

        public bool IsTitleEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(MovieTitle))
                    return true;
                return false;
            }
        }

        public bool IsCategorySelected
        {
            get
            {
                if (MovieCategory == EMovieCategory.Brak)
                    return true;
                return false;
            }
        }

        public bool IsSaveBtnEnabled
        {
            get
            {
                if (string.IsNullOrEmpty(MovieTitle) && MovieCategory == EMovieCategory.Brak)
                    return false;
                return true;
            }
        }
        public AddMoviePageVM(ObservableCollection<Movie> allMovies)
        {
            Movies = allMovies;
            Movie = new Movie();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddMovieToAllMoviesList()
        {
            Movies.Add(new Movie(Movie.Title, Movie.Category, Movie.Description, Movie.Review, Movie.Rating));

            MessageBox.Show("Pomyślnie dodano nowy film.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
