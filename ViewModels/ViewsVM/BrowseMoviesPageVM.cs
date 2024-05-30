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
        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;
            }
        }
        private ObservableCollection<Movie> _movies;

        public ObservableCollection<Movie> SearchResult
        {
            get
            {
                if (string.IsNullOrEmpty(SearchedText))
                    return Movies;

                _searchResult.Clear();

                foreach (Movie movie in Movies)
                {
                    if (movie.Title.ToLower().Contains(SearchedText.ToLower()))
                        _searchResult.Add(movie);
                }

                return _searchResult;
            }
            set
            {
                _searchResult = value;
            }
        }
        private ObservableCollection<Movie> _searchResult;

        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                _selectedMovie = value;

                if (_selectedMovie == null) return;

                OnPropertyChanged();
                OnPropertyChanged(nameof(MovieTitle));
                OnPropertyChanged(nameof(IsTitleEmpty));
                OnPropertyChanged(nameof(MovieCategory));
                OnPropertyChanged(nameof(IsCategoryNoneSelected));
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
                OnPropertyChanged(nameof(CanExitEditMode));
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
                OnPropertyChanged(nameof(IsCategoryNoneSelected));
                OnPropertyChanged(nameof(SelectedMovie));
                OnPropertyChanged(nameof(CanExitEditMode));
            }
        }
        private EMovieCategory _category;

        public string SearchedText
        {
            get
            {
                if (string.IsNullOrEmpty(_searchedText))
                    return string.Empty;

                return _searchedText;
            }
            set
            {
                _searchedText = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(SearchResult));
            }
        }
        private string _searchedText;

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
        public bool IsCategoryNoneSelected
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

        public bool CanExitEditMode
        {
            get
            {
                if (IsEditMode && (IsCategoryNoneSelected || IsTitleEmpty))
                    return false;
                return true;
            }
        }

        public BrowseMoviesPageVM(AllMovies movies)
        {
            AllMovies = movies;
            Movies = movies.Movies;
            SelectedMovie = null;
            _searchResult = new ObservableCollection<Movie>();
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
            OnPropertyChanged(nameof(IsCategoryNoneSelected));
            OnPropertyChanged(nameof(IsMovieSelected));
        }

        public void DeleteMovie()
        {
            if(SelectedMovie is null)
                return;

            Movies.Remove(SelectedMovie);

            OnPropertyChanged(nameof(_movies));

            MessageBox.Show("Pomyślnie usunięto film.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);

            SelectedMovie = null;

            OnPropertyChanged(nameof(Movies));
            OnPropertyChanged(nameof(SearchResult));
            OnPropertyChanged(nameof(SelectedMovie));
            OnPropertyChanged(nameof(MovieTitle));
            OnPropertyChanged(nameof(MovieCategory));
            OnPropertyChanged(nameof(IsTitleEmpty));
            OnPropertyChanged(nameof(IsCategoryNoneSelected));
            OnPropertyChanged(nameof(IsMovieSelected));
        }
    }
}
