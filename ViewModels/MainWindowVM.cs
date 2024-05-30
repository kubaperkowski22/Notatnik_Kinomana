using Notatnik_Kinomana_v2.Models;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notatnik_Kinomana_v2.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public AllMovies AllMovies
        {
            get
            {
                return _allMovies;
            }
            set
            {
                _allMovies = value;
            }
        }
        private AllMovies _allMovies;

        public AllPremieres AllPremieres
        {
            get
            {
                return _allPremieres;
            }
            set
            {
                _allPremieres = value;
            }
        }
        private AllPremieres _allPremieres;

        public AddMoviePageVM AddMoviePageVM
        {
            get
            {
                return _addMoviePageVM;
            }
            set
            {
                _addMoviePageVM = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddMoviePageVM));
            }
        }
        private AddMoviePageVM _addMoviePageVM;

        public BrowseMoviesPageVM BrowseMoviesPageVM
        {
            get
            {
                return _browseMoviePageVM;
            }
            set
            {
                _browseMoviePageVM = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddMoviePageVM));
            }
        }
        private BrowseMoviesPageVM _browseMoviePageVM;

        public PlanPremierePageVM PlanPremierePageVM
        {
            get
            {
                return _planPremierePageVM;
            }
            set
            {
                _planPremierePageVM = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(_planPremierePageVM));
            }
        }
        private PlanPremierePageVM _planPremierePageVM;


        public MainWindowVM()
        {
            AllMovies = new AllMovies();
            AllPremieres = new AllPremieres();
            AddMoviePageVM = new AddMoviePageVM(AllMovies.Movies);
            BrowseMoviesPageVM = new BrowseMoviesPageVM(AllMovies);
            PlanPremierePageVM = new PlanPremierePageVM(AllPremieres);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
