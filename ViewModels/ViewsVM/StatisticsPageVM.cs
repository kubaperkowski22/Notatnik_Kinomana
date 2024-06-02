using Notatnik_Kinomana_v2.Helpers;
using Notatnik_Kinomana_v2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Notatnik_Kinomana_v2.ViewModels.ViewsVM
{
    public class StatisticsPageVM : INotifyPropertyChanged
    {
        public ObservableCollection<Premiere> Premieres { get; set; }

        public ObservableCollection<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                _movies = value;

                UpdateMoviesNumberInEachCategory();
            }
        }
        private ObservableCollection<Movie> _movies;

        public int AddedMovies
        {
            get => Movies.Count;
        }
        public int AddedPremieres
        {
            get => Premieres.Count;
        }
        public float AverageRating
        {
            get
            {
                _averageRating = 0;
                foreach (var movie in Movies)
                    _averageRating += (float)movie.Rating;

                if(Movies == null || Movies.Count == 0)
                    return 0;
                return _averageRating / Movies.Count;
            }
        }
        private float _averageRating;

        public int WatchedMovies
        {
            get
            {
                _watchedMovies = 0;
                foreach (var premiere in Premieres)
                    if(premiere.AlreadyWatched) _watchedMovies++;

                return _watchedMovies;
            }
        }
        public int UnwatchedMovies
        {
            get
            {
                return Premieres.Count - WatchedMovies;
            }
        }
        private int _watchedMovies;
        
        public string MostPopularCategory
        {
            get
            {
                return CompareValues();
            }
        }

        private int[] CategoriesNumber = new int[_categoryNum] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};


        private const int _categoryNum = 12;

        public StatisticsPageVM(AllMovies allMovies, AllPremieres allPremieres)
        {
            Movies = allMovies.Movies;
            Premieres = allPremieres.Premieres;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateMoviesNumberInEachCategory()
        {
            SetCategoriesNumToZero();

            foreach (var movie in Movies)
            {
                switch ((int)movie.Category)
                {
                    case 0:
                        CategoriesNumber[0]++;
                        break;
                    case 1:
                        CategoriesNumber[1]++;
                        break;
                    case 2:
                        CategoriesNumber[2]++;
                        break;
                    case 3:
                        CategoriesNumber[3]++;
                        break;
                    case 4:
                        CategoriesNumber[4]++;
                        break;
                    case 5:
                        CategoriesNumber[5]++;
                        break;
                    case 6:
                        CategoriesNumber[6]++;
                        break;
                    case 7:
                        CategoriesNumber[7]++;
                        break;
                    case 8:
                        CategoriesNumber[8]++;
                        break;
                    case 9:
                        CategoriesNumber[9]++;
                        break;
                    case 10:
                        CategoriesNumber[10]++;
                        break;
                    case 11:
                        CategoriesNumber[11]++;
                        break;
                }

                OnPropertyChanged();
            }
        }
        private void SetCategoriesNumToZero()
        {
            for(int i=0; i< _categoryNum; ++i)
                CategoriesNumber[i] = 0;
        }

        private string CompareValues()
        {
            int maxValue = 0;
            int index = 0;

            for(int i=0; i<_categoryNum; ++i)
            {
                if (CategoriesNumber[i] > maxValue)
                {
                    maxValue = CategoriesNumber[i];
                    index = i;
                }
            }

            var movie = Movies.FirstOrDefault(x => (int)x.Category == index);

            if (movie != null)
                return movie.Category.ToString();
            else return "-----";
        }

    }
}
