using Notatnik_Kinomana_v2.Controls;
using Notatnik_Kinomana_v2.Models;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notatnik_Kinomana_v2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy BrowseMoviesPage.xaml
    /// </summary>
    public partial class BrowseMoviesPage : UserControl
    {
        public BrowseMoviesPageVM ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
            }
        }
        private BrowseMoviesPageVM _viewModel;
        public ObservableCollection<Movie> Movies { get; set; }

        public BrowseMoviesPage(AllMovies movies)
        {
            InitializeComponent();

            ViewModel = new BrowseMoviesPageVM(movies);
            this.DataContext = ViewModel;

            RatingControl.Rating = 1;
        }

        private void EditMode_Toggled(object sender, RoutedEventArgs e)
        {
            ViewModel.IsEditMode = !ViewModel.IsEditMode;
        }

        private void MoviesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditModeTSW.IsOn = false;

            if (ViewModel.SelectedMovie is null) RatingControl.Rating = 1;
            else RatingControl.Rating = (int)ViewModel.SelectedMovie.Rating;

            ViewModel.SelectionChanged();
        }

        private void RatingControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.SelectedMovie.Rating = RatingControl.Rating;
        }

        private void DeleteMovieButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteMovie();
        }

    }
}
