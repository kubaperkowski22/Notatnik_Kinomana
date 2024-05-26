using Notatnik_Kinomana_v2.ViewModels;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Logika interakcji dla klasy AddMoviePage.xaml
    /// </summary>
    public partial class AddMoviePage : UserControl, INotifyPropertyChanged
    {
        public AddMoviePageVM ViewModel
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
        private AddMoviePageVM _viewModel;

        public AddMoviePage()
        {
            InitializeComponent();

            ViewModel = new AddMoviePageVM();
            this.DataContext = ViewModel;
        }

        private void RatingControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.Movie.Rating = RatingControl.Rating;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ViewModel.IsTitleEmpty));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
