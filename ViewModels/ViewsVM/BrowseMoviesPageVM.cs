using Notatnik_Kinomana_v2.Helpers;
using Notatnik_Kinomana_v2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik_Kinomana_v2.ViewModels.ViewsVM
{
    public class BrowseMoviesPageVM : INotifyPropertyChanged
    {
        public AllMovies AllMovies { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }

        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                if (_selectedMovie is null) return;

                _selectedMovie = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(MovieTitle));
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(MovieCategory));
                OnPropertyChanged(nameof(IsCategorySelected));
                OnPropertyChanged(nameof(IsMovieSelected));

            }
        }
        private Movie _selectedMovie;

        public string MovieTitle
        {
            get
            {
                if(SelectedMovie is null)
                    return string.Empty;

                return SelectedMovie.Title;
            }
            set
            {
                if (_selectedMovie is null) return;

                SelectedMovie.Title = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(MovieTitle));
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }
        private string _title;

        public EMovieCategory MovieCategory
        {
            get
            {
                if (SelectedMovie is null)
                    return EMovieCategory.Brak;

                return SelectedMovie.Category;
            }
            set
            {
                if (_selectedMovie is null) return;

                SelectedMovie.Category = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(MovieCategory));
                OnPropertyChanged(nameof(IsCategorySelected));
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }
        private EMovieCategory _category;

        public bool IsEditMode
        {
            get
            {
                return _isEditMode;
            }
            set
            {
                _isEditMode = value;

                OnPropertyChanged();
            }
        }
        private bool _isEditMode;

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

        public bool IsMovieSelected
        {
            get
            {
                if (SelectedMovie is null )
                    return false;
                return true;
            }
        }

        public BrowseMoviesPageVM(AllMovies movies)
        {
            AllMovies = movies;
            Movies = movies.Movies;
            SelectedMovie = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SelectionChanged()
        {
            IsEditMode = false;

            OnPropertyChanged(nameof(SelectedMovie));
            OnPropertyChanged(nameof(MovieTitle));
            OnPropertyChanged(nameof(MovieCategory));
            OnPropertyChanged(nameof(IsTitleEmpty));
            OnPropertyChanged(nameof(IsCategorySelected));
            OnPropertyChanged(nameof(IsMovieSelected));
        }

        public void DeleteMovie()
        {
            if(SelectedMovie is null)
                return;

            Movies.Remove(SelectedMovie);

            MessageBox.Show("Pomyślnie usunięto film.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedMovie = null;

            OnPropertyChanged(nameof(Movies));
            OnPropertyChanged(nameof(SelectedMovie));
            OnPropertyChanged(nameof(MovieTitle));
            OnPropertyChanged(nameof(MovieCategory));
            OnPropertyChanged(nameof(IsTitleEmpty));
            OnPropertyChanged(nameof(IsCategorySelected));
            OnPropertyChanged(nameof(IsMovieSelected));
        }
    }
}
