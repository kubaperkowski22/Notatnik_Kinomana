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

        public int None { get; set; } = 0;
        public int Action { get; set; } = 0;
        public int Animation { get; set; } = 0;
        public int Document { get; set; } = 0;
        public int Drama { get; set; } = 0;
        public int Family { get; set; } = 0;
        public int Fantasy { get; set; } = 0;
        public int Horror { get; set; } = 0;
        public int Comedy { get; set; } = 0;
        public int Romance { get; set; } = 0;
        public int ScienceFiction { get; set; } = 0;
        public int Thriller { get; set; } = 0;

        private const int _categoryNum = 12;

        public StatisticsPageVM(AllMovies allMovies, AllPremieres allPremieres)
        {
            Movies = allMovies.Movies;
            Premieres = allPremieres.Premieres;
            UpdateMoviesNumberInEachCategory();
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
                switch((int)movie.Category)
                {
                    case 0:
                        None++;
                        break;
                    case 1:
                        Action++;
                        break;
                    case 2:
                        Animation++;
                        break;
                    case 3:
                        Document++;
                        break;
                    case 4:
                        Drama++;
                        break;
                    case 5:
                        Family++;
                        break;
                    case 6:
                        Fantasy++;
                        break;
                    case 7:
                        Horror++;
                        break;
                    case 8:
                        Comedy++;
                        break;
                    case 9:
                        Romance++;
                        break;
                    case 10:
                        ScienceFiction++;
                        break;
                    case 11:
                        Thriller++;
                        break;
                }

                OnPropertyChanged();
            }
        }
        private void SetCategoriesNumToZero()
        {
            None = 0;
            Action = 0;
            Animation = 0;
            Document = 0;
            Drama = 0;
            Family = 0;
            Fantasy = 0;
            Horror = 0;
            Comedy = 0;
            Romance = 0;
            ScienceFiction = 0;
            Thriller = 0;
        }
    }
}
