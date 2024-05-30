using Notatnik_Kinomana_v2.Helpers;
using Notatnik_Kinomana_v2.Models;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy PlanPremierePage.xaml
    /// </summary>
    public partial class PlanPremierePage : UserControl
    {
        public PlanPremierePageVM ViewModel
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
        private PlanPremierePageVM _viewModel;

        public PlanPremierePage(AllPremieres premieres)
        {
            InitializeComponent();

            ViewModel = new PlanPremierePageVM(premieres);
            this.DataContext = ViewModel;
            CategoryCB.SelectedItem = EMovieCategory.Brak;
        }

        private void SavePremiere_Button_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleTB.Text;
            EMovieCategory category = (EMovieCategory)CategoryCB.SelectedItem;
            DateTime date = (DateTime)PremiereDatePicker.SelectedDate;
            bool watched = AlreadyWatchedTSW.IsOn;

            TitleTB.Clear();
            CategoryCB.SelectedIndex = 0;
            PremiereDatePicker.SelectedDate = DateTime.Now.Date;
            AlreadyWatchedTSW.IsOn = false;


            ViewModel.AddPremiere(title, category, date, watched);
        }
    }
}
