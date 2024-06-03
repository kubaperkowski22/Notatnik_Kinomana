using MahApps.Metro.Controls;
using Notatnik_Kinomana_v2.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notatnik_Kinomana_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindowVM ViewModel
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
        private MainWindowVM _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowVM();
            this.DataContext = ViewModel;
        }

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as HamburgerMenuIconItem;
            if(menuItem is not null)
            {
                switch(menuItem.Tag.ToString())
                {
                    case "AddMovieView":
                        HamburgerMenuControl.Content = new Views.AddMoviePage(ViewModel.AllMovies.Movies);
                        this.HamburgerMenuControl.IsPaneOpen = false;
                        break;
                    case "BrowseMoviesView":
                        HamburgerMenuControl.Content = new Views.BrowseMoviesPage(ViewModel.AllMovies);
                        this.HamburgerMenuControl.IsPaneOpen = false;
                        break;
                    case "PlanPremiereView":
                        HamburgerMenuControl.Content = new Views.PlanPremierePage(ViewModel.AllPremieres);
                        this.HamburgerMenuControl.IsPaneOpen = false;
                        break;
                    case "StatisticsView":
                        HamburgerMenuControl.Content = new Views.StatisticsPage(ViewModel.AllMovies, ViewModel.AllPremieres);
                        this.HamburgerMenuControl.IsPaneOpen = false;
                        break;
                    default:
                        return;
                }
            }
        }

        private void HamburgerMenuControl_OptionsItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuControl.Content = new Views.SettingsPage(ViewModel);

            this.HamburgerMenuControl.IsPaneOpen = false;
        }
    }
}