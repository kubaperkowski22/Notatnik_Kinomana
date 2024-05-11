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
    public partial class AdonisWindow : Window
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
        public AdonisWindow()
        {
            ViewModel = new MainWindowVM();

            this.DataContext = ViewModel;
        }
    }
}